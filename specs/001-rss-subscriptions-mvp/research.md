# Research: RSS Subscription MVP

## Decision

Use a small, two-layer architecture with a Blazor WebAssembly frontend and an ASP.NET Core Web API backend, both configured for local development and backed by an in-memory subscription list.

## Rationale

The project requirements explicitly define the MVP as a single-user, local proof-of-concept with add-subscription and display behavior only. This architecture matches the project stack guidance and keeps responsibilities clean: the API handles the subscription contract, while the frontend manages the user interface and immediate list updates.

## Alternatives considered

- Single-project app with no API boundary: rejected because the project explicitly calls for ASP.NET Core API + Blazor WebAssembly separation and clean future extensibility.
- Persistence-backed storage from day one: rejected because the MVP explicitly stores subscriptions in memory and defers persistence to a later phase.
- Feed fetching and parsing in the MVP: rejected because the feature specification and project goals explicitly exclude those capabilities from the current acceptance criteria.

## Findings

- The backend should expose a minimal endpoint to submit a feed URL and return the current subscription collection.
- The frontend should keep form state and local list state in memory for the current session.
- Configuration must align local ports and allowlists so the app runs reliably without connection errors.
- The plan remains intentionally narrow to preserve the MVP boundary and maintain future upgradeability.
