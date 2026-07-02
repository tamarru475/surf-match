---
name: ship-feature
description: Use when the user wants to build a feature or bugfix for SurfMatch end-to-end — create a branch, implement, test, commit, push, open a PR into develop, wait on CI checks, and merge. Triggers on requests like "let's build X as a feature branch" or "let's ship this".
---

Branching model: `feature/*` or `bugfix/*` -> `develop` -> `main`. `develop` is the default branch; never target `main` directly for app features.

1. **Branch.** From an up-to-date `develop`, create `feature/<short-name>` (or `bugfix/<short-name>`).
2. **Implement.** Follow the project's MVVM convention on the frontend (pure functions in a `*.viewmodel.ts`, thin React component) and existing patterns on the backend (filter-first `RecommendationEngine`).
3. **Test locally before committing:**
   - Backend: `cd backend.Tests && dotnet test` (or `dotnet test backend.Tests/backend.Tests.csproj` from repo root).
   - Frontend: `cd frontend && npm test`.
   - Add/update tests for any new logic — table-driven (`it.each`) for multi-scenario cases.
4. **Show the diff for review before committing anything.** Run `git diff` / `git status` and let the user look it over. Do not stage or commit until they explicitly say to proceed.
5. **Commit** with a short, why-focused message (see repo-wide git commit instructions for format/co-author trailer).
6. **Push** the branch: `git push -u origin <branch>`.
7. **Open a PR into `develop`** (not `main`):
   `gh pr create --base develop --title "..." --body "..."`
8. **Wait for required checks** — `backend-test` and `frontend-test` must pass:
   `gh pr checks <pr-number>`
9. **Merge once green and the user has confirmed they reviewed/ran it locally:**
   `gh pr merge <pr-number> --squash --delete-branch`
10. **Sync local develop:** `git checkout develop && git pull`.

Do not skip step 3 — every prior feature on this repo shipped with tests written alongside the change. Do not commit (step 4) or merge (step 9) without the user's explicit go-ahead, even if checks are green.
