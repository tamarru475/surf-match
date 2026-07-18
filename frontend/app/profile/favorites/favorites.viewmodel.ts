'use client';

import { useEffect, useState } from 'react';
import { fetchFavorites, removeFavorite } from '@/lib/api';
import type { FavoriteSpot } from '@/lib/types';

export interface FavoritesViewModel {
  favorites: FavoriteSpot[];
  loading: boolean;
  error: string | null;
  handleRemove: (spotId: string) => void;
}

export function useFavoritesViewModel(): FavoritesViewModel {
  const [favorites, setFavorites] = useState<FavoriteSpot[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

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

  return { favorites, loading, error, handleRemove };
}
