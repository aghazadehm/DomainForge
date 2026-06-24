using DomainForge.Modules.Wallets.Domain;
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
    public void Should_deposit_money_into_wallet()
    {
        var wallet = Wallet.Create(OwnerId.New(), WalletType.Main, Money.Create(100, Currency.USD));
        wallet.Deposit(Money.Create(50, Currency.USD));
        Assert.Equal(150, wallet.AvailableBalance.Amount);
    }

    [Fact]
    public void Should_withdraw_money_from_wallet()
    {
        var wallet = Wallet.Create(OwnerId.New(), WalletType.Main, Money.Create(100, Currency.USD));
        wallet.Withdraw(Money.Create(40, Currency.USD));
        Assert.Equal(60, wallet.AvailableBalance.Amount);
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
}
