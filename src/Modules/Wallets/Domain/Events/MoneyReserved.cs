using DomainForge.Modules.Wallets.Domain.ValueObjects;
using DomainForge.SharedKernel.Domain.Events;

namespace DomainForge.Modules.Wallets.Domain.Events;

public sealed record MoneyReserved(
    WalletId WalletId,
    Money Amount,
    Guid ReservationId
) : DomainEvent;
