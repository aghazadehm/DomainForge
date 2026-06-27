namespace DomainForge.Modules.Wallets.Domain.Exceptions;

public sealed class CurrencyMismatchException : Exception
{
    public CurrencyMismatchException()
        : base("Transaction currency does not match the wallet currency.")
    {
    }
}
