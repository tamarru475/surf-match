import type { FavoriteSpot, Profile, RecommendationResponse, UpdateProfileData, UserPreferences } from './types';
import { supabase } from './supabase';

const API_BASE = process.env.NEXT_PUBLIC_API_URL ?? 'http://localhost:5116';

async function authHeaders(): Promise<HeadersInit> {
  const { data } = await supabase.auth.getSession();
  const token = data.session?.access_token;
  return token
    ? { 'Content-Type': 'application/json', Authorization: `Bearer ${token}` }
    : { 'Content-Type': 'application/json' };
}

// Throws if the user has no saved preferences (404 from backend).
// Used after auth to decide whether to route to profile or home.
export async function fetchUserPreferences(): Promise<UserPreferences> {
  const headers = await authHeaders();
  const res = await fetch(`${API_BASE}/me/preferences`, { headers });
  if (!res.ok) throw new Error(`API error: ${res.status}`);
  return res.json();
}

export async function fetchProfile(): Promise<Profile> {
  const headers = await authHeaders();
  const res = await fetch(`${API_BASE}/me`, { headers });
  if (!res.ok) throw new Error(`API error: ${res.status}`);
  return res.json();
}

export async function updateProfile(data: UpdateProfileData): Promise<Profile> {
  const headers = await authHeaders();
  const res = await fetch(`${API_BASE}/me`, {
    method: 'PUT',
    headers,
    body: JSON.stringify(data),
  });
  if (!res.ok) throw new Error(`API error: ${res.status}`);
  return res.json();
}

export async function saveUserPreferences(prefs: UserPreferences): Promise<void> {
  const headers = await authHeaders();
  const res = await fetch(`${API_BASE}/me/preferences`, {
    method: 'PUT',
    headers,
    body: JSON.stringify(prefs),
  });
  if (!res.ok) throw new Error(`API error: ${res.status}`);
}

export async function fetchRecommendations(prefs: UserPreferences): Promise<RecommendationResponse> {
  const res = await fetch(`${API_BASE}/recommendations`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(prefs),
  });

  if (!res.ok) throw new Error(`API error: ${res.status}`);
  return res.json();
}

export async function fetchFavorites(): Promise<FavoriteSpot[]> {
  const headers = await authHeaders();
  const res = await fetch(`${API_BASE}/me/favorites`, { headers });
  if (!res.ok) throw new Error(`API error: ${res.status}`);
  return res.json();
}

export async function addFavorite(spotId: string): Promise<FavoriteSpot> {
  const headers = await authHeaders();
  const res = await fetch(`${API_BASE}/me/favorites/${spotId}`, { method: 'POST', headers });
  if (!res.ok) throw new Error(`API error: ${res.status}`);
  return res.json();
}

export async function removeFavorite(spotId: string): Promise<void> {
  const headers = await authHeaders();
  const res = await fetch(`${API_BASE}/me/favorites/${spotId}`, { method: 'DELETE', headers });
  if (!res.ok) throw new Error(`API error: ${res.status}`);
}

export function computeMatchPercent(score: number, prefs: UserPreferences): number {
  const maxBoard = prefs.boardTypes.length > 0 ? 20 : 0;
  const maxCrowd = 20;
  const maxFacilities = prefs.preferredFacilities.length;
  const max = maxBoard + maxCrowd + maxFacilities;
  if (max === 0) return 100;
  return Math.min(100, Math.round((score / max) * 100));
}
