namespace DomainForge.Modules.Wallets.Domain.ValueObjects;

public sealed class WalletType : IEquatable<WalletType>
{
    public string Code { get; }

    private WalletType(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("Wallet type code is required.");

        Code = code.ToUpperInvariant();
    }

    public static WalletType Main => Create("MAIN");
    public static WalletType Spot => Create("SPOT");
    public static WalletType Future => Create("FUTURE");

    public static WalletType Create(string code)
        => new(code);

    public bool Equals(WalletType? other)
        => other is not null && Code == other.Code;

    public override bool Equals(object? obj)
        => obj is WalletType other && Equals(other);

    public override int GetHashCode()
        => Code.GetHashCode();
}
