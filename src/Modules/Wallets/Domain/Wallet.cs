using DomainForge.Modules.Wallets.Domain.Events;
using DomainForge.Modules.Wallets.Domain.Exceptions;
using DomainForge.Modules.Wallets.Domain.States;
using DomainForge.Modules.Wallets.Domain.ValueObjects;
using DomainForge.SharedKernel.Domain;

namespace DomainForge.Modules.Wallets.Domain;

public sealed class Wallet : AggregateRoot
{
    public WalletId Id { get; private set; }
    public OwnerId OwnerId { get; private set; }
    public Money AvailableBalance { get; private set; }
    public Money ReservedBalance { get; private set; }
    public WalletType Type { get; private set; }
    public WalletState State { get; private set; }

    private Wallet() { }

    private Wallet(WalletId id, OwnerId ownerId, WalletType type, Money initialBalance)
    {
        Id = id;
        OwnerId = ownerId;
        Type = type;
        AvailableBalance = initialBalance;
        ReservedBalance = Money.Create(0, initialBalance.Currency);
        State = WalletState.Active;

        Raise(new WalletCreated(id, ownerId, type));
    }

    public static Wallet Create(OwnerId ownerId, WalletType type, Money initialBalance)
        => new(WalletId.New(), ownerId, type, initialBalance);

    public void Deposit(Money amount)
    {
        EnsureActive();
        AvailableBalance = AvailableBalance.Add(amount);
        Raise(new MoneyDeposited(Id, amount, null));
    }

    public void Withdraw(Money amount)
    {
        EnsureActive();

        if (amount.Amount > AvailableBalance.Amount)
            throw new InsufficientBalanceException();

        AvailableBalance = AvailableBalance.Subtract(amount);
        Raise(new MoneyWithdrawn(Id, amount, null));
    }

    public void ReserveMoney(Money amount)
    {
        EnsureActive();

        if (amount.Amount > AvailableBalance.Amount)
            throw new InsufficientBalanceException();

        AvailableBalance = AvailableBalance.Subtract(amount);
        ReservedBalance = ReservedBalance.Add(amount);
        Raise(new MoneyReserved(Id, amount, Guid.NewGuid()));
    }

    public void ReleaseReservation(Money amount)
    {
        EnsureActive();
        ReservedBalance = ReservedBalance.Subtract(amount);
        AvailableBalance = AvailableBalance.Add(amount);
        Raise(new MoneyReservationReleased(Id, Guid.NewGuid(), amount));
    }

    public void CommitReservedMoney(Money amount)
    {
        EnsureActive();
        ReservedBalance = ReservedBalance.Subtract(amount);
        Raise(new MoneyReservationCommitted(Id, Guid.NewGuid(), amount));
    }

    public void Freeze()
    {
        State = WalletState.Frozen;
        Raise(new WalletFrozen(Id, "Wallet frozen."));
    }

    private void EnsureActive()
    {
        if (State != WalletState.Active)
            throw new InvalidOperationException("Wallet is not active.");
    }
}
