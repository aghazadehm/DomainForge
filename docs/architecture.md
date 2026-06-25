# DomainForge Architecture

## Goal

DomainForge is a DDD learning and reference project focused on production-oriented design.

## Architecture Style

The system follows a Modular Monolith approach.

Each bounded context owns its domain model, application logic and infrastructure.

## Current Bounded Contexts

- Wallets
- Transfer (planned)
- Accounting (planned)

## Domain Rules

- Aggregates protect their invariants.
- Other aggregates are not modified directly.
- Communication between contexts uses contracts and events.

## Wallet Aggregate

Wallet is the aggregate root responsible for balance rules:

- Deposit
- Withdraw
- Reserve money
- Commit reservation
- Release reservation

## Testing Strategy

- Unit tests for domain behavior.
- Integration tests for infrastructure.
- Acceptance tests through the real application composition root.
