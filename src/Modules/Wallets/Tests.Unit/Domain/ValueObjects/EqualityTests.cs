using DomainForge.Modules.Wallets.Domain.ValueObjects;
using Xunit;

public class EqualityTests
{
    [Fact]
    public void Should_compare_value_objects_by_value()
    {
        var id = Guid.NewGuid();
        Assert.Equal(WalletId.From(id), WalletId.From(id));
        Assert.Equal(OwnerId.From(id), OwnerId.From(id));
        Assert.Equal(WalletType.Main, WalletType.Create("main"));
    }
}
