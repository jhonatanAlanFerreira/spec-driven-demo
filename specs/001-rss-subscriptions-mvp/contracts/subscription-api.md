# Subscription API Contract

## Endpoint: POST /api/subscriptions

### Purpose
Adds a feed URL to the current subscription list.

### Request
- Content-Type: application/json
- Body:
  {
    "url": "https://example.com/feed.xml"
  }

### Response
- Status: 200 OK
- Body:
  {
    "subscriptions": [
      "https://example.com/feed.xml"
    ]
  }

### Error Handling
- Status: 400 Bad Request when the URL is empty or whitespace-only
- Status: 409 Conflict when a duplicate URL is intentionally rejected

## Endpoint: GET /api/subscriptions

### Purpose
Returns the list of subscriptions in the current session.

### Response
- Status: 200 OK
- Body:
  {
    "subscriptions": [
      "https://example.com/feed.xml"
    ]
  }

## Notes

This contract is intentionally minimal and designed for the subscription-only MVP. Feed retrieval, parsing, and item responses are not part of the contract.
