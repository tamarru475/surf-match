'use client';

import { useState, useCallback } from 'react';
import type { Area } from 'react-easy-crop';
import { getCroppedBlob } from '@/lib/cropImage';

export function useAvatarCropModalViewModel(
  imageSrc: string,
  onConfirm: (blob: Blob) => void
) {
  const [crop, setCrop]   = useState({ x: 0, y: 0 });
  const [zoom, setZoom]   = useState(1);
  const [croppedAreaPixels, setCroppedAreaPixels] = useState<Area | null>(null);
  const [saving, setSaving] = useState(false);

  const handleCropComplete = useCallback((_: Area, pixels: Area) => {
    setCroppedAreaPixels(pixels);
  }, []);

  const handleSave = useCallback(async () => {
    if (!croppedAreaPixels) return;
    setSaving(true);
    try {
      const blob = await getCroppedBlob(imageSrc, croppedAreaPixels);
      onConfirm(blob);
    } finally {
      setSaving(false);
    }
  }, [imageSrc, croppedAreaPixels, onConfirm]);

  return { crop, zoom, setCrop, setZoom, handleCropComplete, handleSave, saving };
}
