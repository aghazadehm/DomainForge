using DomainForge.Modules.Wallets.Domain.ValueObjects;
using Xunit;

namespace DomainForge.Modules.Wallets.Tests.Unit.Domain;

public class WalletTypeTests
{
    [Fact]
    public void Should_create_main_wallet_type()
    {
        var type = WalletType.Main;

        Assert.Equal("MAIN", type.Code);
    }

    [Fact]
    public void Should_not_create_wallet_type_without_code()
    {
        Assert.Throws<ArgumentException>(() =>
            WalletType.Create(string.Empty));
    }
}
