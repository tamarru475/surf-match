'use client';

import { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { supabase } from '@/lib/supabase';
import { fetchUserPreferences } from '@/lib/api';
import styles from './page.module.css';

const AuthCallbackPage = () => {
  const router = useRouter();

  useEffect(() => {
    supabase.auth.getSession().then(async ({ data }) => {
      if (!data.session) { router.replace('/'); return; }
      try {
        await fetchUserPreferences();
        router.replace('/profile');
      } catch {
        router.replace('/');
      }
    });
  }, [router]);

  return (
    <main className={styles.root}>
      <p className={styles.message}>Signing you in…</p>
    </main>
  );
};

export default AuthCallbackPage;
