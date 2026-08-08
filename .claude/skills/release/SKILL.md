# Release Skill

Cut a new SurfMatch release from `develop` → `main` and **verify both deployments are actually live before declaring success**. Do not say "it's live" until every check passes.

## 1. Pre-flight checks

```bash
# Must be on develop and clean
git checkout develop && git pull origin develop
git status   # must show nothing uncommitted
```

If there are uncommitted changes, stop and ask the user to commit or stash first.

## 2. Decide the version number

Ask the user for the version tag (e.g. `v2.1.0`) if they haven't already specified it.

## 3. Open develop → main PR

```bash
gh pr create \
  --base main \
  --head develop \
  --title "release: <version>" \
  --body "$(cat <<'EOF'
## Changes
<summarise what's in this release — pull from `git log main..develop --oneline`>

## Checklist
- [ ] Tests passing on develop
- [ ] Manual smoke test done locally
EOF
)"
```

## 4. Wait for CI on the PR

```bash
gh pr checks <pr-number> --watch
```

All checks must be green before merging.

## 5. Get explicit user confirmation before merging

Show the user the PR link and ask: "Ready to merge and release?" Do not merge without their explicit go-ahead.

## 6. Merge and tag

```bash
gh pr merge <pr-number> --merge --delete-branch
git checkout main && git pull origin main
git tag <version>
git push origin <version>
gh release create <version> --title "SurfMatch <version>" --generate-notes
```

## 7. Wait for GitHub Actions on main

Find the two workflow runs triggered by the merge and wait for BOTH to finish:

```bash
# Wait up to 10 minutes for runs to appear, then watch them
sleep 30
be_run=$(gh run list --branch main --workflow backend.yml  --limit 1 --json databaseId -q '.[0].databaseId')
fe_run=$(gh run list --branch main --workflow frontend.yml --limit 1 --json databaseId -q '.[0].databaseId')

echo "BE run: $be_run, FE run: $fe_run"
gh run watch "$be_run" --exit-status
gh run watch "$fe_run" --exit-status
```

If either run fails, **stop here** — do NOT declare it live. Report the failure and link to the failed run:
```bash
gh run view "$be_run" --log-failed
gh run view "$fe_run" --log-failed
```

## 8. Verify the backend health endpoint

```bash
status=$(curl -sf -o /dev/null -w "%{http_code}" \
  https://surf-match-api-518426856978.australia-southeast1.run.app/health)
echo "BE health: HTTP $status"
[ "$status" = "200" ] || (echo "BACKEND HEALTH CHECK FAILED" && exit 1)
```

## 9. Verify the frontend is reachable

```bash
status=$(curl -so /dev/null -w "%{http_code}" https://surf-match.vercel.app)
echo "FE status: HTTP $status"
[ "$status" -ge 200 ] && [ "$status" -lt 400 ] \
  || (echo "FRONTEND CHECK FAILED: HTTP $status" && exit 1)
```

## 10. Declare live — only if all checks passed

Tell the user:
- Release tag and GitHub release link
- BE URL: https://surf-match-api-518426856978.australia-southeast1.run.app/health
- FE URL: https://surf-match.vercel.app

If ANY step from 7–9 failed, do NOT say it's live. Say which step failed and what the error was.
