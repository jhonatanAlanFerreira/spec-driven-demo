# Quickstart Validation Guide

## Prerequisites

- Backend API project is running locally
- Frontend Blazor project is running locally
- Ports are aligned between the backend, frontend, and configuration files
- Browser access is available for local UI verification

## Validation Steps

1. Start the backend API.
2. Start the frontend application.
3. Open the app in the browser.
4. Confirm the page loads without routing or connection errors.
5. Enter a sample feed URL and submit it.
6. Verify the subscription appears in the list immediately.
7. Add another feed URL and verify both entries are visible.
8. Submit a blank value and confirm the interface rejects it without adding a subscription.

## Expected Results

- The app loads successfully.
- The subscription form accepts valid feed URLs.
- The list updates immediately after each addition.
- Invalid or empty submissions are rejected.
- No feed content is fetched or displayed during the MVP.
