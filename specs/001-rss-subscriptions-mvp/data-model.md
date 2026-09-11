# Data Model: RSS Subscription MVP

## Core Entities

### Subscription

Represents a feed the user is following during the current app session.

**Fields**:
- URL: string
- CreatedAt: datetime (optional; useful for ordering or debugging)

**Relationships**:
- One user may have many subscriptions in the current local session
- The list is displayed in the UI and returned by the API as a collection

## Validation Rules

- URL must be non-empty and trimmed before addition
- Duplicate URLs may be rejected or ignored to keep the list clean
- No feed validation is required at MVP stage because the project explicitly assumes valid feed URLs

## State Model

- Empty state: no subscriptions exist yet
- Active state: one or more subscription URLs exist in memory
- Post-submission state: the list updates immediately and the form resets for the next entry

## Notes

The model is intentionally minimal because the MVP is only proving subscription management, not feed retrieval or parsing.
