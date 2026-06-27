using DomainForge.Modules.Wallets.Domain;
using DomainForge.Modules.Wallets.Domain.Events;
using DomainForge.Modules.Wallets.Domain.Exceptions;
using DomainForge.Modules.Wallets.Domain.States;
using DomainForge.Modules.Wallets.Domain.ValueObjects;
using Xunit;

namespace DomainForge.Modules.Wallets.Tests.Unit.Domain;

public class WalletTests
{
    [Fact]
    public void Should_create_active_wallet()
    {
        var wallet = Wallet.Create(OwnerId.New(), WalletType.Main, Money.Create(100, Currency.USD));
        Assert.Equal(WalletState.Active, wallet.State);
        Assert.Equal(0, wallet.ReservedBalance.Amount);
    }

    [Fact]
    public void Should_raise_WalletCreated_event()
    {
        var wallet = Wallet.Create(OwnerId.New(), WalletType.Main, Money.Create(100, Currency.USD));
        var events = wallet.DomainEvents.OfType<WalletCreated>().ToList();
        Assert.Single(events);
        Assert.Equal(wallet.Id, events[0].WalletId);
        Assert.Equal(wallet.OwnerId, events[0].OwnerId);
    }

    [Fact]
    public void Should_deposit_money_into_wallet()
    {
        var wallet = Wallet.Create(OwnerId.New(), WalletType.Main, Money.Create(100, Currency.USD));
        wallet.Deposit(Money.Create(50, Currency.USD));
        Assert.Equal(150, wallet.AvailableBalance.Amount);
    }

    [Fact]
    public void Should_raise_MoneyDeposited_event()
    {
        var wallet = Wallet.Create(OwnerId.New(), WalletType.Main, Money.Create(100, Currency.USD));
        wallet.ClearDomainEvents();
        wallet.Deposit(Money.Create(50, Currency.USD));
        var events = wallet.DomainEvents.OfType<MoneyDeposited>().ToList();
        Assert.Single(events);
        Assert.Equal(wallet.Id, events[0].WalletId);
        Assert.Equal(50, events[0].Amount.Amount);
    }

    [Fact]
    public void Should_withdraw_money_from_wallet()
    {
        var wallet = Wallet.Create(OwnerId.New(), WalletType.Main, Money.Create(100, Currency.USD));
        wallet.Withdraw(Money.Create(40, Currency.USD));
        Assert.Equal(60, wallet.AvailableBalance.Amount);
    }

    [Fact]
    public void Should_raise_MoneyWithdrawn_event()
    {
        var wallet = Wallet.Create(OwnerId.New(), WalletType.Main, Money.Create(100, Currency.USD));
        wallet.ClearDomainEvents();
        wallet.Withdraw(Money.Create(40, Currency.USD));
        var events = wallet.DomainEvents.OfType<MoneyWithdrawn>().ToList();
        Assert.Single(events);
        Assert.Equal(40, events[0].Amount.Amount);
    }

    [Fact]
    public void Should_not_withdraw_more_than_available_balance()
    {
        var wallet = Wallet.Create(OwnerId.New(), WalletType.Main, Money.Create(100, Currency.USD));
        Assert.Throws<InsufficientBalanceException>(() => wallet.Withdraw(Money.Create(200, Currency.USD)));
    }

    [Fact]
    public void Should_freeze_wallet()
    {
        var wallet = Wallet.Create(OwnerId.New(), WalletType.Main, Money.Create(100, Currency.USD));
        wallet.Freeze();
        Assert.Equal(WalletState.Frozen, wallet.State);
    }

    [Fact]
    public void Should_raise_WalletFrozen_event()
    {
        var wallet = Wallet.Create(OwnerId.New(), WalletType.Main, Money.Create(100, Currency.USD));
        wallet.ClearDomainEvents();
        wallet.Freeze();
        var events = wallet.DomainEvents.OfType<WalletFrozen>().ToList();
        Assert.Single(events);
        Assert.Equal(wallet.Id, events[0].WalletId);
    }

    [Fact]
    public void Should_reserve_money()
    {
        var wallet = Wallet.Create(OwnerId.New(), WalletType.Main, Money.Create(100, Currency.USD));
        wallet.ReserveMoney(Money.Create(30, Currency.USD));
        Assert.Equal(70, wallet.AvailableBalance.Amount);
        Assert.Equal(30, wallet.ReservedBalance.Amount);
    }

    [Fact]
    public void Should_raise_MoneyReserved_event()
    {
        var wallet = Wallet.Create(OwnerId.New(), WalletType.Main, Money.Create(100, Currency.USD));
        wallet.ClearDomainEvents();
        wallet.ReserveMoney(Money.Create(30, Currency.USD));
        var events = wallet.DomainEvents.OfType<MoneyReserved>().ToList();
        Assert.Single(events);
        Assert.Equal(30, events[0].Amount.Amount);
        Assert.NotEqual(Guid.Empty, events[0].ReservationId);
    }

    [Fact]
    public void Should_release_reserved_money()
    {
        var wallet = Wallet.Create(OwnerId.New(), WalletType.Main, Money.Create(100, Currency.USD));
        wallet.ReserveMoney(Money.Create(30, Currency.USD));
        wallet.ReleaseReservation(Money.Create(30, Currency.USD));
        Assert.Equal(100, wallet.AvailableBalance.Amount);
        Assert.Equal(0, wallet.ReservedBalance.Amount);
    }

    [Fact]
    public void Should_raise_MoneyReservationReleased_event()
    {
        var wallet = Wallet.Create(OwnerId.New(), WalletType.Main, Money.Create(100, Currency.USD));
        wallet.ReserveMoney(Money.Create(30, Currency.USD));
        wallet.ClearDomainEvents();
        wallet.ReleaseReservation(Money.Create(30, Currency.USD));
        var events = wallet.DomainEvents.OfType<MoneyReservationReleased>().ToList();
        Assert.Single(events);
        Assert.Equal(30, events[0].Amount.Amount);
    }

    [Fact]
    public void Should_commit_reserved_money()
    {
        var wallet = Wallet.Create(OwnerId.New(), WalletType.Main, Money.Create(100, Currency.USD));
        wallet.ReserveMoney(Money.Create(30, Currency.USD));
        wallet.CommitReservedMoney(Money.Create(30, Currency.USD));
        Assert.Equal(0, wallet.ReservedBalance.Amount);
    }

    [Fact]
    public void Should_raise_MoneyReservationCommitted_event()
    {
        var wallet = Wallet.Create(OwnerId.New(), WalletType.Main, Money.Create(100, Currency.USD));
        wallet.ReserveMoney(Money.Create(30, Currency.USD));
        wallet.ClearDomainEvents();
        wallet.CommitReservedMoney(Money.Create(30, Currency.USD));
        var events = wallet.DomainEvents.OfType<MoneyReservationCommitted>().ToList();
        Assert.Single(events);
        Assert.Equal(30, events[0].Amount.Amount);
    }
}
