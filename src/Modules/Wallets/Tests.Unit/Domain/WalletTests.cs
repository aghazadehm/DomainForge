using DomainForge.Modules.Wallets.Domain;
using DomainForge.Modules.Wallets.Domain.ValueObjects;
using Xunit;

namespace DomainForge.Modules.Wallets.Tests.Unit.Domain;

public class WalletTests
{
    [Fact]
    public void Should_deposit_money_into_wallet()
    {
        var wallet = Wallet.Create(
            OwnerId.New(),
            WalletType.Main,
            Money.Create(100, Currency.USD));

        wallet.Deposit(Money.Create(50, Currency.USD));

        Assert.Equal(150, wallet.AvailableBalance.Amount);
    }

    [Fact]
    public void Should_not_withdraw_more_than_available_balance()
    {
        var wallet = Wallet.Create(
            OwnerId.New(),
            WalletType.Main,
            Money.Create(100, Currency.USD));

        Assert.Throws<Exception>(() =>
            wallet.Withdraw(Money.Create(200, Currency.USD)));
    }
}
