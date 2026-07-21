'use client';

import { useState, useEffect, useCallback, useMemo, useRef } from 'react';
import { updateProfile, uploadAvatar } from '@/lib/api';
import { REGIONS } from '@/lib/types';
import type { Profile } from '@/lib/types';

export interface ProfileCardViewModel {
  avatarUrl: string | null;
  avatarLetter: string;
  uploading: boolean;
  pendingImageSrc: string | null;
  displayName: string;
  location: string;
  bio: string;
  instagramHandle: string;
  tikTokHandle: string;
  isDirty: boolean;
  saving: boolean;
  saveSuccess: boolean;
  error: string | null;
  setDisplayName: (v: string) => void;
  setLocation: (v: string) => void;
  setBio: (v: string) => void;
  setInstagramHandle: (v: string) => void;
  setTikTokHandle: (v: string) => void;
  handleSave: () => void;
  handleFilePicked: (file: File) => void;
  handleCropConfirm: (blob: Blob) => void;
  handleCropCancel: () => void;
}

export const REGION_OPTIONS = REGIONS;

export const useProfileCardViewModel = (profile: Profile | null): ProfileCardViewModel => {
  const saveSuccessTimer = useRef<ReturnType<typeof setTimeout> | null>(null);

  const [saved, setSaved]                     = useState<Profile | null>(profile);
  const [avatarUrl, setAvatarUrl]             = useState<string | null>(profile?.avatarUrl ?? null);
  const [pendingImageSrc, setPendingImageSrc] = useState<string | null>(null);
  const [uploading, setUploading]             = useState(false);
  const [displayName, setDisplayName]         = useState(profile?.displayName ?? '');
  const [location, setLocation]               = useState(profile?.location ?? '');
  const [bio, setBio]                         = useState(profile?.bio ?? '');
  const [instagramHandle, setInstagramHandle] = useState(profile?.instagramHandle ?? '');
  const [tikTokHandle, setTikTokHandle]       = useState(profile?.tikTokHandle ?? '');
  const [saving, setSaving]                   = useState(false);
  const [saveSuccess, setSaveSuccess]         = useState(false);
  const [error, setError]                     = useState<string | null>(null);

  useEffect(() => {
    if (!profile) return;
    setSaved(profile);
    setAvatarUrl(profile.avatarUrl ?? null);
    setDisplayName(profile.displayName ?? '');
    setLocation(profile.location ?? '');
    setBio(profile.bio ?? '');
    setInstagramHandle(profile.instagramHandle ?? '');
    setTikTokHandle(profile.tikTokHandle ?? '');
  }, [profile]);

  const isDirty = useMemo(() => {
    if (!saved) return false;
    return (
      displayName     !== (saved.displayName     ?? '') ||
      location        !== (saved.location        ?? '') ||
      bio             !== (saved.bio             ?? '') ||
      instagramHandle !== (saved.instagramHandle ?? '') ||
      tikTokHandle    !== (saved.tikTokHandle    ?? '')
    );
  }, [displayName, location, bio, instagramHandle, tikTokHandle, saved]);

  const handleSave = useCallback(async () => {
    setSaving(true);
    setError(null);
    setSaveSuccess(false);
    if (saveSuccessTimer.current) clearTimeout(saveSuccessTimer.current);
    try {
      const updated = await updateProfile({
        displayName:     displayName.trim() || null,
        location:        location.trim() || null,
        bio:             bio.trim() || null,
        instagramHandle: instagramHandle.trim() || null,
        tikTokHandle:    tikTokHandle.trim() || null,
      });
      setSaved(updated);
      setSaveSuccess(true);
      saveSuccessTimer.current = setTimeout(() => setSaveSuccess(false), 2500);
    } catch {
      setError('Failed to save. Please try again.');
    } finally {
      setSaving(false);
    }
  }, [displayName, location, bio, instagramHandle, tikTokHandle]);

  const handleFilePicked = useCallback((file: File) => {
    setPendingImageSrc(URL.createObjectURL(file));
  }, []);

  const clearPending = useCallback(() => {
    setPendingImageSrc(prev => { if (prev) URL.revokeObjectURL(prev); return null; });
  }, []);

  const handleCropCancel = useCallback(() => { clearPending(); }, [clearPending]);

  const handleCropConfirm = useCallback(async (blob: Blob) => {
    clearPending();
    setUploading(true);
    setError(null);
    try {
      const file = new File([blob], 'avatar.jpg', { type: 'image/jpeg' });
      const updated = await uploadAvatar(file);
      setAvatarUrl(updated.avatarUrl ?? null);
    } catch {
      setError('Failed to upload photo. Please try again.');
    } finally {
      setUploading(false);
    }
  }, [clearPending]);

  const avatarLetter = ((saved?.displayName ?? saved?.email ?? profile?.email ?? '?')[0]).toUpperCase();

  return {
    avatarUrl, avatarLetter, uploading, pendingImageSrc,
    displayName, location, bio, instagramHandle, tikTokHandle,
    isDirty, saving, saveSuccess, error,
    setDisplayName, setLocation, setBio, setInstagramHandle, setTikTokHandle,
    handleSave, handleFilePicked, handleCropConfirm, handleCropCancel,
  };
};
