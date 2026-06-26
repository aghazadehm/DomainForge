using DomainForge.Modules.Wallets.Domain.ValueObjects;
using DomainForge.SharedKernel.Domain.Events;

namespace DomainForge.Modules.Wallets.Domain.Events;

public sealed record WalletCreated(
    WalletId WalletId,
    OwnerId OwnerId,
    WalletType WalletType
) : DomainEvent;