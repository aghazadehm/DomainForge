namespace DomainForge.Modules.Wallets.Domain.ValueObjects;

public sealed class WalletId : IEquatable<WalletId>
{
    public Guid Value { get; }

    private WalletId(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("Wallet id cannot be empty.");

        Value = value;
    }

    public static WalletId New()
        => new(Guid.NewGuid());

    public static WalletId From(Guid value)
        => new(value);

    public bool Equals(WalletId? other)
        => other is not null && Value == other.Value;

    public override bool Equals(object? obj)
        => obj is WalletId other && Equals(other);

    public override int GetHashCode()
        => Value.GetHashCode();
}
