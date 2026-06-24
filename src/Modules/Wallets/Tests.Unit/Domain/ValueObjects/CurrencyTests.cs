using DomainForge.Modules.Wallets.Domain.ValueObjects;
using Xunit;

public class CurrencyTests
{
    [Fact]
    public void Should_create_currency()
    {
        var currency = Currency.Create("usd");
        Assert.Equal("USD", currency.Code);
    }
}
