// Provide stub Supabase env vars so the client module can be imported in tests.
// Tests that exercise auth should mock @/lib/supabase directly.
process.env.NEXT_PUBLIC_SUPABASE_URL = 'https://placeholder.supabase.co';
process.env.NEXT_PUBLIC_SUPABASE_ANON_KEY = 'placeholder-anon-key';
