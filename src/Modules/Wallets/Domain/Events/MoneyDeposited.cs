using DomainForge.Modules.Wallets.Domain.ValueObjects;
using DomainForge.SharedKernel.Domain.Events;

namespace DomainForge.Modules.Wallets.Domain.Events;

public sealed record MoneyDeposited(
    WalletId WalletId,
    Money Amount,
    string? Reference
) : DomainEvent;