'use client';

import { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { supabase } from '@/lib/supabase';
import { saveUserPreferences } from '@/lib/api';
import type { UserPreferences } from '@/lib/types';
import styles from './page.module.css';

const AuthCallbackPage = () => {
  const router = useRouter();

  useEffect(() => {
    supabase.auth.getSession().then(async ({ data }) => {
      if (!data.session) { router.replace('/'); return; }

      const storedResults = sessionStorage.getItem('surfmatch_results');
      if (storedResults) {
        try {
          const { preferences } = JSON.parse(storedResults) as { preferences: UserPreferences };
          if (preferences) await saveUserPreferences(preferences).catch(() => {});
        } catch {}
      }

      const returnTo = sessionStorage.getItem('auth_return_to') || '/profile';
      sessionStorage.removeItem('auth_return_to');
      router.replace(returnTo);
    });
  }, [router]);

  return (
    <main className={styles.root}>
      <p className={styles.message}>Signing you in…</p>
    </main>
  );
};

export default AuthCallbackPage;
