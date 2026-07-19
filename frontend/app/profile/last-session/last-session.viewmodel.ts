'use client';

import { useEffect, useState } from 'react';
import { fetchLastSession } from '@/lib/api';
import type { SurfSession } from '@/lib/types';

export interface LastSessionViewModel {
  session: SurfSession | null;
  loading: boolean;
  error: string | null;
  isActive: boolean;
  handleDone: () => void;
}

function isToday(dateStr: string): boolean {
  const d = new Date(dateStr);
  const now = new Date();
  return (
    d.getUTCFullYear() === now.getUTCFullYear() &&
    d.getUTCMonth() === now.getUTCMonth() &&
    d.getUTCDate() === now.getUTCDate()
  );
}

export function useLastSessionViewModel(): LastSessionViewModel {
  const [session, setSession] = useState<SurfSession | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [dismissed, setDismissed] = useState(false);

  useEffect(() => {
    fetchLastSession()
      .then(setSession)
      .catch(() => setError('Failed to load session'))
      .finally(() => setLoading(false));
  }, []);

  useEffect(() => {
    const handler = (e: Event) => {
      setSession((e as CustomEvent<SurfSession>).detail);
      setDismissed(false);
    };
    window.addEventListener('surfmatch:session-logged', handler);
    return () => window.removeEventListener('surfmatch:session-logged', handler);
  }, []);

  const isActive = !dismissed && session !== null && isToday(session.surfedAt);

  return {
    session,
    loading,
    error,
    isActive,
    handleDone: () => setDismissed(true),
  };
}

export { isToday };
