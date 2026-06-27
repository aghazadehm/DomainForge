using DomainForge.Modules.Wallets.Domain.ValueObjects;
using DomainForge.SharedKernel.Domain.Events;

namespace DomainForge.Modules.Wallets.Domain.Events;

public sealed record WalletUnfrozen(
    WalletId WalletId
) : DomainEvent;
