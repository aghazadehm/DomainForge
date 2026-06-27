namespace DomainForge.Modules.Wallets.Domain.ValueObjects;

public class WalletIdTests
{
    [Fact]
    public void Should_create_new_wallet_id()
    {
        var id = WalletId.New();

        Assert.NotEqual(Guid.Empty, id.Value);
    }

    [Fact]
    public void Should_not_accept_empty_guid()
    {
        Assert.Throws<ArgumentException>(() =>
            WalletId.From(Guid.Empty));
    }
}
