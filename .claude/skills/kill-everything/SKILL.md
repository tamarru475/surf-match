---
name: kill-everything
description: Kill all SurfMatch processes (backend .NET binary, Next.js dev server) and verify nothing is left running on their ports. Use when the user says "kill everything", "shut it all down", or "stop the servers".
---

Kill every SurfMatch process and confirm the ports are clear. Do all steps even if some commands return nothing — a clean kill should be silent.

1. **Kill by port** (most reliable — catches the compiled binary, not just the dotnet wrapper):
   ```bash
   lsof -ti :5116 | xargs kill -9 2>/dev/null; echo "BE done"
   lsof -ti :3000 | xargs kill -9 2>/dev/null; echo "FE done"
   ```

2. **Kill by process name** (belt-and-suspenders for any leftover processes):
   ```bash
   pkill -f "net10.0/backend" 2>/dev/null
   pkill -f "next dev" 2>/dev/null
   pkill -f "next-server" 2>/dev/null
   ```

3. **Verify the ports are free** — run this and confirm both return nothing:
   ```bash
   lsof -i :5116 -i :3000
   ```
   If anything is still listed, kill the remaining PIDs with `kill -9 <pid>` and re-check.

4. Report to the user: "All clear — ports 5116 and 3000 are free."
