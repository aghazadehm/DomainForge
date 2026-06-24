using DomainForge.Modules.Wallets.Domain.ValueObjects;
using Xunit;

namespace DomainForge.Modules.Wallets.Tests.Unit.Domain;

public class MoneyTests
{
    [Fact]
    public void Should_add_same_currency_money()
    {
        var first = Money.Create(100, "USD");
        var second = Money.Create(50, "USD");

        var result = first.Add(second);

        Assert.Equal(150, result.Amount);
    }

    [Fact]
    public void Should_not_subtract_more_than_available()
    {
        var money = Money.Create(100, "USD");

        Assert.Throws<InvalidOperationException>(() =>
            money.Subtract(Money.Create(200, "USD")));
    }
}
