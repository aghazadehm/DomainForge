using DomainForge.Modules.Wallets.Domain.ValueObjects;
using DomainForge.SharedKernel.Domain.Events;

namespace DomainForge.Modules.Wallets.Domain.Events;

public sealed record MoneyReservationCommitted(
    WalletId WalletId,
    Guid ReservationId,
    Money Amount
) : DomainEvent;