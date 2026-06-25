namespace DomainForge.Modules.Wallets.Domain.ValueObjects;

public sealed class OwnerId : IEquatable<OwnerId>
{
    public Guid Value { get; }

    private OwnerId(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("Owner id cannot be empty.");

        Value = value;
    }

    public static OwnerId New()
        => new(Guid.NewGuid());

    public static OwnerId From(Guid value)
        => new(value);

    public bool Equals(OwnerId? other)
        => other is not null && Value == other.Value;

    public override bool Equals(object? obj)
        => obj is OwnerId other && Equals(other);

    public override int GetHashCode()
        => Value.GetHashCode();
}
