using DomainForge.Modules.Wallets.Domain.Exceptions;
using DomainForge.Modules.Wallets.Domain.States;
using DomainForge.Modules.Wallets.Domain.ValueObjects;

namespace DomainForge.Modules.Wallets.Domain;

public sealed class Wallet
{
    public WalletId Id { get; private set; }
    public OwnerId OwnerId { get; private set; }
    public Money AvailableBalance { get; private set; }
    public Money ReservedBalance { get; private set; }
    public WalletType Type { get; private set; }
    public WalletState State { get; private set; }

    private Wallet()
    {
    }

    private Wallet(WalletId id, OwnerId ownerId, WalletType type, Money initialBalance)
    {
        Id = id;
        OwnerId = ownerId;
        Type = type;
        AvailableBalance = initialBalance;
        ReservedBalance = Money.Create(0, initialBalance.Currency);
        State = WalletState.Active;
    }

    public static Wallet Create(
        OwnerId ownerId,
        WalletType type,
        Money initialBalance)
        => new(WalletId.New(), ownerId, type, initialBalance);

    public void Deposit(Money amount)
    {
        EnsureActive();
        AvailableBalance = AvailableBalance.Add(amount);
    }

    public void Withdraw(Money amount)
    {
        EnsureActive();

        if (amount.Amount > AvailableBalance.Amount)
            throw new InsufficientBalanceException();

        AvailableBalance = AvailableBalance.Subtract(amount);
    }

    public void Freeze()
    {
        State = WalletState.Frozen;
    }

    private void EnsureActive()
    {
        if (State != WalletState.Active)
            throw new InvalidOperationException("Wallet is not active.");
    }
}
