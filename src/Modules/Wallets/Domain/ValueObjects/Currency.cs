namespace DomainForge.Modules.Wallets.Domain.ValueObjects;

public sealed class Currency : IEquatable<Currency>
{
    public string Code { get; }

    private Currency(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("Currency code is required.");

        Code = code.ToUpperInvariant();
    }

    public static Currency Create(string code)
        => new(code);

    public static Currency USD => Create("USD");
    public static Currency EUR => Create("EUR");

    public bool Equals(Currency? other)
        => other is not null && Code == other.Code;

    public override bool Equals(object? obj)
        => obj is Currency other && Equals(other);

    public override int GetHashCode()
        => Code.GetHashCode();
}
