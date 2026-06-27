namespace DomainForge.Modules.Wallets.Domain.ValueObjects;

public class MoneyTests
{
    [Fact]
    public void Should_add_same_currency_money()
    {
        var first = Money.Create(100, Currency.USD);
        var second = Money.Create(50, Currency.USD);

        var result = first.Add(second);

        Assert.Equal(150m, result.Amount);
    }

    [Fact]
    public void Should_not_subtract_more_than_available()
    {
        var money = Money.Create(100, Currency.USD);

        Assert.Throws<InvalidOperationException>(() =>
            money.Subtract(Money.Create(200, Currency.USD)));
    }

    [Fact]
    public void Should_not_create_negative_money()
    {
        Assert.Throws<ArgumentException>(() =>
            Money.Create(-1, Currency.USD));
    }
}
