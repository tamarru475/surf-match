import type { RecommendationResponse, UserPreferences } from './types';

const API_BASE = process.env.NEXT_PUBLIC_API_URL ?? 'http://localhost:5116';

export async function fetchRecommendations(prefs: UserPreferences): Promise<RecommendationResponse> {
  const res = await fetch(`${API_BASE}/recommendations`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(prefs),
  });

  if (!res.ok) throw new Error(`API error: ${res.status}`);
  return res.json();
}

export function computeMatchPercent(score: number, prefs: UserPreferences): number {
  const maxBoard = prefs.boardTypes.length > 0 ? 20 : 0;
  const maxCrowd = 20;
  const maxFacilities = prefs.preferredFacilities.length;
  const max = maxBoard + maxCrowd + maxFacilities;
  if (max === 0) return 100;
  return Math.min(100, Math.round((score / max) * 100));
}
