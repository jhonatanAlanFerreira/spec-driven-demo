<!--
Sync Impact Report:
- Version change: 0.0.0 -> 1.0.0
- Modified principles: N/A (new constitution created from template)
- Added sections: Core Principles, Technology and Security Constraints, Development Workflow and Quality Gates, Governance
- Removed sections: placeholder template scaffolding and unresolved tokens
- Deferred items: RATIFICATION_DATE -> TODO(RATIFICATION_DATE): add the formal adoption date when this constitution is approved
-->

# RSS Feed Reader Constitution

## Core Principles

### I. MVP-Scoped Delivery
All work must remain within the approved MVP definition unless a formal amendment adds new scope. For this project, the current target is a single-user local proof of concept that can add a subscription URL and display the resulting subscription list. No feed fetching, parsing, persistence, or background polling may be introduced before the subscription-management MVP is accepted.

This rule prevents feature creep and keeps the project focused on demonstrating the smallest valuable workflow in a maintainable way.

### II. Secure-by-Default Configuration
Every application configuration point that touches network origins, API routes, or local environment setup must be explicit and reviewed. The backend and frontend must use consistent localhost ports, valid CORS configuration, and no hard-coded secrets or sensitive values in source files.

This protects local development, reduces deployment risk, and keeps the application safe as features expand beyond the initial proof of concept.

### III. Maintainable Architecture
The ASP.NET Core API and Blazor WebAssembly UI must remain separated by clear responsibilities. The backend owns API contracts, data flow, and service logic; the frontend owns user interaction and display state. New code must be small, named clearly, and easy to reason about without hidden coupling between layers.

This keeps the project understandable for future enhancements such as parsing, persistence, and background processing without requiring a rewrite.

### IV. Test-First Validation
Every user-visible behavior and API contract change must be backed by a failing test or an explicit verification step before implementation proceeds. For the MVP, verification includes confirming that a subscription can be added and the UI reflects the updated list. For later phases, tests should cover parsing, error handling, and configuration correctness.

This makes the project reliable and ensures regressions are caught before they become expensive to fix.

### V. Incremental Quality and Simplicity
The project must prefer the simplest implementation that satisfies the approved phase. No speculative features, background jobs, or rich content rendering may be added before the current phase is stable and verified. The Extended-MVP and post-MVP features remain explicit follow-up work, not hidden requirements.

This preserves code quality and keeps delivery fast without compromising long-term maintainability.

## Technology and Security Constraints

- Architecture: the project uses ASP.NET Core Web API for backend services and Blazor WebAssembly for the frontend UI.
- Cross-platform support: the application must run on Windows, macOS, and Linux without OS-specific dependencies in core logic.
- Configuration integrity: API base URLs, frontend app settings, backend ports, and CORS allowlists must remain aligned during local development.
- Security: do not hardcode secrets, expose internal configuration, or render untrusted content without sanitization when feed content is added.
- Data handling: the MVP stores subscriptions in memory only; persistence and long-term storage require an explicit future phase and approval.
- Error handling: user input must be treated as a boundary concern, with explicit handling for malformed or missing requests rather than silent failure.
- Future-proofing: architecture choices must remain compatible with eventual feed parsing, EF Core persistence, background services, and improved error handling.

## Development Workflow and Quality Gates

- Scope review: before implementation, confirm the work belongs to the active phase and does not violate the MVP boundary.
- Build verification: all changes must compile cleanly and pass the relevant local checks for the API and UI.
- Local integration checks: verify the frontend and backend can communicate on the configured ports and that no routing or connection errors appear in the browser console.
- Review standard: every pull request must confirm the change aligns with the constitution, especially the MVP scope, security constraints, and maintainability requirements.
- Phase progression: do not begin Extended-MVP features until the subscription-management MVP is working and demonstrates the required behavior end to end.
- Documentation expectation: any design decision that affects architecture, scope, security, or testing must be recorded in project documentation before implementation proceeds.

## Governance

This constitution governs all work for the RSS Feed Reader project. It supersedes ad hoc shortcuts, unreviewed scope expansion, and undocumented development practices. All project work must protect configuration integrity, maintain clear architectural separation, and keep the project aligned with the approved delivery phases.

Amendments to this constitution must:

1. Document the reason and business impact of the change.
2. Update the version using semantic versioning and record the new last amended date.
3. Explain any shift in scope, security controls, or quality gates.
4. Confirm that the architecture remains compatible with the MVP-first development plan.

Compliance review expectations:

- Each change must be validated against this constitution before merge.
- Any exception must be documented in the pull request and justified by a clear project need.
- New capabilities must be mapped to the correct project phase rather than silently added to the MVP.

**Version**: 1.0.0 | **Ratified**: TODO(RATIFICATION_DATE): add the formal adoption date when this constitution is approved | **Last Amended**: 2026-09-10
