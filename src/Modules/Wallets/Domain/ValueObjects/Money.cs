namespace DomainForge.Modules.Wallets.Domain.ValueObjects;

public sealed class Money : IEquatable<Money>
{
    public decimal Amount { get; }
    public Currency Currency { get; }

    private Money(decimal amount, Currency currency)
    {
        if (amount < 0)
            throw new ArgumentException("Money amount cannot be negative.");

        Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        Amount = amount;
    }

    public static Money Create(decimal amount, Currency currency)
        => new(amount, currency);

    public Money Add(Money other)
    {
        EnsureSameCurrency(other);
        return Create(Amount + other.Amount, Currency);
    }

    public Money Subtract(Money other)
    {
        EnsureSameCurrency(other);

        if (other.Amount > Amount)
            throw new InvalidOperationException("Insufficient money.");

        return Create(Amount - other.Amount, Currency);
    }

    private void EnsureSameCurrency(Money other)
    {
        if (!Currency.Equals(other.Currency))
            throw new InvalidOperationException("Currency mismatch.");
    }

    public bool Equals(Money? other)
        => other is not null && Amount == other.Amount && Currency.Equals(other.Currency);

    public override bool Equals(object? obj)
        => obj is Money other && Equals(other);

    public override int GetHashCode()
        => HashCode.Combine(Amount, Currency);
}
