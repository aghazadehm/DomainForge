namespace DomainForge.Modules.Wallets.Domain.ValueObjects;

public class OwnerIdTests
{
    [Fact]
    public void Should_create_new_owner_id()
    {
        var id = OwnerId.New();

        Assert.NotEqual(Guid.Empty, id.Value);
    }

    [Fact]
    public void Should_not_accept_empty_guid()
    {
        Assert.Throws<ArgumentException>(() => OwnerId.From(Guid.Empty));
    }
}
