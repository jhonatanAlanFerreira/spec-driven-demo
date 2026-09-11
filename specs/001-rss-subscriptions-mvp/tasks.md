# Tasks: RSS Subscription MVP

**Input**: Design documents from `/specs/001-rss-subscriptions-mvp/`

**Prerequisites**: plan.md, spec.md, research.md, data-model.md, contracts/

**Organization**: Tasks are grouped by user story to enable independent implementation and testing of each story.

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Create the project structure and establish the shared local-development configuration for the backend and frontend.

- [X] T001 Create backend project structure under `backend/RSSFeedReader.Api/` with `Controllers`, `Models`, `Services`, and `Program.cs`
- [X] T002 Create frontend project structure under `frontend/RSSFeedReader.UI/` with `Pages`, `Services`, and `Program.cs`
- [X] T003 [P] Align local development configuration for backend port, frontend port, and `appsettings.json` API base URL in the expected project files

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Build the minimal infrastructure needed before user story work begins.

**Checkpoint**: Foundation ready - user story implementation can now begin in parallel.

- [X] T004 Create `Subscription` model in `backend/RSSFeedReader.Api/Models/Subscription.cs` with URL-based data and basic validation requirements
- [X] T005 [P] Implement in-memory subscription storage in `backend/RSSFeedReader.Api/Services/SubscriptionStore.cs`
- [X] T006 [P] Configure CORS and API middleware in `backend/RSSFeedReader.Api/Program.cs`
- [X] T007 [P] Create the Blazor subscriptions page shell in `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor` for the add form and list display
- [X] T008 Add API client abstraction in `frontend/RSSFeedReader.UI/Services/SubscriptionApiClient.cs` for create and read operations
- [X] T009 Validate startup behavior and confirm the frontend can reach the backend without routing or connection errors

---

## Phase 3: User Story 1 - Add a feed subscription (Priority: P1) 🎯 MVP

**Goal**: Allow a user to submit a feed URL and see it appear in the subscription list immediately.

**Independent Test**: A user can enter a valid feed URL, submit it, and observe that the new subscription is displayed without any feed-fetching behavior.

### Implementation for User Story 1

- [X] T010 [US1] Implement `POST /api/subscriptions` in `backend/RSSFeedReader.Api/Controllers/SubscriptionsController.cs` to accept a URL and return current subscription list
- [X] T011 [US1] Add validation for blank and duplicate submissions in `backend/RSSFeedReader.Api/Services/SubscriptionStore.cs` and the controller layer
- [X] T012 [P] [US1] Implement add-subscription form logic in `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor`
- [X] T013 [US1] Connect the page to `SubscriptionApiClient` and refresh the displayed list after successful submission
- [X] T014 [US1] Verify the UI updates immediately after submission and show the list with the newly added URL

**Checkpoint**: At this point, User Story 1 should be fully functional and independently testable.

---

## Phase 4: User Story 2 - View the current subscription list (Priority: P2)

**Goal**: Let the user review all tracked subscriptions in the current session and see an empty state before any entries exist.

**Independent Test**: A user can open the page, confirm the empty-state message when no subscriptions exist, and inspect the list after adding one or more URLs.

### Implementation for User Story 2

- [ ] T015 [P] [US2] Implement `GET /api/subscriptions` in `backend/RSSFeedReader.Api/Controllers/SubscriptionsController.cs` to return all current subscriptions
- [ ] T016 [P] [US2] Load the current subscription list on page initialization in `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor`
- [ ] T017 [US2] Render empty-state and populated list views in `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor` using the current in-memory data
- [ ] T018 [US2] Confirm list rendering matches the expected session behavior for zero, one, and multiple subscriptions

**Checkpoint**: At this point, User Stories 1 and 2 should both work independently.

---

## Phase 5: User Story 3 - Keep the MVP intentionally minimal (Priority: P3)

**Goal**: Preserve the MVP boundary by preventing feed-fetching, parsing, persistence, or other Extended-MVP concerns from leaking into the implementation.

**Independent Test**: A reviewer can confirm the app only supports adding and viewing subscriptions and does not fetch or parse feed content during this phase.

### Implementation for User Story 3

- [ ] T019 [US3] Document the MVP boundary and confirm no feed retrieval or parsing flow exists in `backend/RSSFeedReader.Api/` and `frontend/RSSFeedReader.UI/`
- [ ] T020 [US3] Ensure in-memory state remains the sole storage model for the project in the current phase and is clearly documented in implementation notes
- [ ] T021 [US3] Run the quickstart validation from `specs/001-rss-subscriptions-mvp/quickstart.md` and record evidence that the app behaves as a subscription-only prototype

**Checkpoint**: All user stories should now be independently functional.

---

## Phase 6: Polish & Cross-Cutting Concerns

**Purpose**: Final cleanup, configuration verification, and end-to-end validation before the MVP is considered ready.

- [ ] T022 [P] Review CORS, port configuration, and `appsettings.json` consistency across backend and frontend projects
- [ ] T023 [P] Remove template demo pages or route conflicts in the Blazor frontend to keep the app focused on the subscription page
- [ ] T024 Run a full end-to-end validation of the MVP flow and confirm the add-subscription behavior matches the acceptance criteria

---

## Dependencies & Execution Order

### Phase Dependencies

- **Setup (Phase 1)**: No dependencies - can start immediately
- **Foundational (Phase 2)**: Depends on Setup completion and blocks all story work
- **User Story phases (Phases 3-5)**: All depend on Foundational completion
- **Polish (Phase 6)**: Depends on all required user stories being functionally complete

### User Story Dependencies

- **User Story 1 (P1)**: Starts after Foundational and is the primary MVP
- **User Story 2 (P2)**: Starts after Foundational and depends on the same API/frontend structure
- **User Story 3 (P3)**: Starts after Foundational and serves as a scope-protection and validation story

### Parallel Opportunities

- Setup tasks T001-T003 can run in parallel
- Foundational tasks T005-T009 can run in parallel within the shared foundation block
- Story 1 tasks T010-T014 can proceed after T004-T009 are complete
- Story 2 tasks T015-T018 can proceed after the API and UI are in place
- Polish tasks T022-T024 are best run after completion of all MVP acceptance scenarios

---

## Implementation Strategy

### MVP First

1. Complete Setup and Foundational phases
2. Complete User Story 1 and validate the add-subscription flow
3. Stop and review whether the proof-of-concept meets the MVP definition
4. Add User Story 2 for list review and edge-state visibility
5. Use User Story 3 to enforce scope discipline and validation before moving past the prototype phase

### Parallel Team Strategy

1. One developer completes backend foundation and endpoint tasks
2. One developer completes frontend foundation and page tasks
3. Both teams align on configuration and end-to-end validation before finishing the MVP
