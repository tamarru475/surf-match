import { createClient } from '@supabase/supabase-js';

// Fallbacks prevent a build crash when env vars are absent during Next.js
// static generation (e.g. /_not-found pre-render in CI). Real values must be
// set as NEXT_PUBLIC_SUPABASE_URL and NEXT_PUBLIC_SUPABASE_ANON_KEY in Vercel
// project settings — without them the app cannot authenticate at runtime.
export const supabase = createClient(
  process.env.NEXT_PUBLIC_SUPABASE_URL      ?? 'https://placeholder.supabase.co',
  process.env.NEXT_PUBLIC_SUPABASE_ANON_KEY ?? 'placeholder-anon-key',
);
