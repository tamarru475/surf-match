'use client';

import { useState, useEffect, useCallback } from 'react';
import { useRouter } from 'next/navigation';
import { supabase } from '@/lib/supabase';
import { useAuth } from '@/lib/AuthContext';
import { saveUserPreferences } from '@/lib/api';
import type { UserPreferences } from '@/lib/types';

export interface AuthModalViewModel {
  mode: 'login' | 'signup';
  email: string;
  password: string;
  error: string | null;
  loading: boolean;
  isClosing: boolean;
  setEmail: (v: string) => void;
  setPassword: (v: string) => void;
  handleSubmit: () => void;
  handleGoogle: () => void;
  handleClose: () => void;
  toggleMode: () => void;
}

export const useAuthModalViewModel = (): AuthModalViewModel => {
  const { authModalOpen, authModalMode, closeAuthModal, user } = useAuth();
  const router = useRouter();

  const [mode, setMode] = useState<'login' | 'signup'>(authModalMode);
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);
  const [isClosing, setIsClosing] = useState(false);

  useEffect(() => { setMode(authModalMode); }, [authModalMode]);

  useEffect(() => {
    if (!user || !authModalOpen) return;
    handlePostAuth();
  }, [user, authModalOpen]);

  const handleClose = useCallback(() => {
    setIsClosing(true);
    setTimeout(() => {
      setIsClosing(false);
      closeAuthModal();
      setError(null);
      setEmail('');
      setPassword('');
    }, 240);
  }, [closeAuthModal]);

  const handlePostAuth = async () => {
    handleClose();

    // If the user just finished the quiz without being logged in, sync those
    // preferences to the backend now so they aren't lost.
    const storedResults = sessionStorage.getItem('surfmatch_results');
    if (storedResults) {
      try {
        const { preferences } = JSON.parse(storedResults) as { preferences: UserPreferences };
        if (preferences) await saveUserPreferences(preferences).catch(() => {});
      } catch {}
    }

    const returnTo = sessionStorage.getItem('auth_return_to') || '/profile';
    sessionStorage.removeItem('auth_return_to');
    router.push(returnTo);
  };

  const handleSubmit = useCallback(async () => {
    setLoading(true);
    setError(null);
    const { error } = mode === 'signup'
      ? await supabase.auth.signUp({ email, password })
      : await supabase.auth.signInWithPassword({ email, password });
    if (error) setError(error.message);
    setLoading(false);
  }, [mode, email, password]);

  const handleGoogle = useCallback(async () => {
    await supabase.auth.signInWithOAuth({
      provider: 'google',
      options: { redirectTo: `${window.location.origin}/auth/callback` },
    });
  }, []);

  const toggleMode = useCallback(() => {
    setMode(m => m === 'login' ? 'signup' : 'login');
    setError(null);
  }, []);

  return {
    mode, email, password, error, loading, isClosing,
    setEmail, setPassword,
    handleSubmit, handleGoogle, handleClose, toggleMode,
  };
};
