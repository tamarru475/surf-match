'use client';

import { useEffect, useState } from 'react';
import { fetchFavorites, logSurfSession, removeFavorite } from '@/lib/api';
import type { FavoriteSpot } from '@/lib/types';

export interface FavoritesViewModel {
  favorites: FavoriteSpot[];
  loading: boolean;
  error: string | null;
  loggedIds: Set<string>;
  handleRemove: (spotId: string) => void;
  handleLogSession: (spotId: string) => void;
}

export function useFavoritesViewModel(): FavoritesViewModel {
  const [favorites, setFavorites] = useState<FavoriteSpot[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [loggedIds, setLoggedIds] = useState<Set<string>>(new Set());

  useEffect(() => {
    fetchFavorites()
      .then(setFavorites)
      .catch(() => setError('Failed to load favourites'))
      .finally(() => setLoading(false));
  }, []);

  const handleRemove = (spotId: string) => {
    setFavorites(prev => prev.filter(f => f.spotId !== spotId));
    removeFavorite(spotId).catch(() => {
      fetchFavorites().then(setFavorites).catch(() => {});
    });
  };

  const handleLogSession = (spotId: string) => {
    setLoggedIds(prev => new Set([...prev, spotId]));
    logSurfSession(spotId)
      .then(session => {
        window.dispatchEvent(new CustomEvent('surfmatch:session-logged', { detail: session }));
      })
      .catch(() => {
        setLoggedIds(prev => {
          const next = new Set(prev);
          next.delete(spotId);
          return next;
        });
      });
  };

  return { favorites, loading, error, loggedIds, handleRemove, handleLogSession };
}
