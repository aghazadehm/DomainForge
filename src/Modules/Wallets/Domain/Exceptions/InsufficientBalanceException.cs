namespace DomainForge.Modules.Wallets.Domain.Exceptions;

public sealed class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException()
        : base("Wallet does not have enough available balance.")
    {
    }
}
