# SurfMatch

SurfMatch helps New Zealand surfers find the right wave by matching their skill level, board type, crowd tolerance, and wave preferences to suitable surf spots across New Zealand.

**Live:** https://surf-match.vercel.app

Figma design: https://www.figma.com/make/1zPtZDVsRfjrsyEbO38UZG/SurfMatch?t=9GfOeqqtHAnXZaeC-1

## Project Structure

```
surf-match/
├── backend/        # ASP.NET Core 10 minimal API (C#)
├── backend.Tests/  # xUnit unit tests for the recommendation engine
└── frontend/       # Next.js 16 + React 19 + Tailwind CSS 4 (TypeScript)
```

## What's built

### Backend (`/backend`)

- **37 NZ surf spots** across 11 regions (Northland, Auckland, Coromandel, Bay of Plenty, Waikato, Gisborne, Taranaki, Christchurch, Kaikoura, Wellington, Otago)
- **Filter-first recommendation engine** — hard filters on skill level, region, wave type, and current wave size; soft ranking by board match, crowd tolerance, and facilities. Never returns an empty result set — relaxes filters one at a time with a plain-English warning when it does.
- **`POST /recommendations`** endpoint — accepts user preferences, returns ranked surf spots with scores and per-spot notes
- Swagger UI available in development at `/swagger`

### Tests (`/backend.Tests`)

22 unit tests covering skill filters, region/wave-type/wave-size filters, always-show-results fallback, soft ranking, and per-spot notes.

### Frontend (`/frontend`)

- **4-page flow:** landing → quiz → loading → results
- **8-question quiz** — skill level, crowd tolerance, region, board types, wave type, wave size, facilities
- **Results page** — ranked spot cards with real photos, match percentage, wave info badges, and a warning banner when filters were relaxed
- **Spot modal** — full detail view with description, current wave height, facilities, Google Maps link, and per-spot notes listed individually
- **MVVM pattern** — `SpotCard.viewmodel.ts` and `quiz.viewmodel.ts` separate data logic from rendering
- **Animations** — card hover lift + photo zoom, modal slide-in/out, loading wave pulse

**Tests (`/frontend/__tests__`)**

115 tests across 10 suites (99.5% statement coverage):
- **Hook tests** — full quiz submit flow including API call, sessionStorage, navigation, and error handling
- **Pure function tests** — `computeMatchPercent`, `buildPreferences`, `isQuestionAnswered`, `cx`
- **Component tests** — Button, ProgressIndicator, AnswerButton, Tooltip, SpotCard, SpotModal, QuestionScreen, InfoModal

Run with:

```bash
cd frontend
npm test
```

## Deployment

| Service | Platform | URL |
|---|---|---|
| Frontend | Vercel | https://surf-match.vercel.app |
| Backend API | Google Cloud Run (`australia-southeast1`) | https://surf-match-api-518426856978.australia-southeast1.run.app |

## Running locally

**Backend**

```bash
cd backend
dotnet run
# API at http://localhost:5116
# Swagger at http://localhost:5116/swagger
```

**Frontend**

```bash
cd frontend
npm run dev
# http://localhost:3000
```

## Example request

`POST /recommendations`

```json
{
  "skillLevel": "Intermediate",
  "crowdTolerance": "Moderate",
  "preferredRegion": "Wellington",
  "boardTypes": ["Shortboard", "Fish"],
  "preferredWaveTypes": ["BeachBreak", "ReefBreak"],
  "preferredWaveSizes": ["WaistHigh", "HeadHigh"],
  "preferredFacilities": []
}
```
