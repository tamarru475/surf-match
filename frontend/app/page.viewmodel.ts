'use client';

import { useState, useEffect, useRef, useCallback } from 'react';

const VIDEO_TIMEOUT_MS = 5000;

function isSlowConnection(): boolean {
  if (typeof navigator === 'undefined') return false;
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  const conn = (navigator as any).connection;
  if (!conn) return false;
  return conn.saveData || ['slow-2g', '2g'].includes(conn.effectiveType);
}

export function useHomepageViewModel() {
  const [tryVideo, setTryVideo]     = useState(false);
  const [showVideo, setShowVideo]   = useState(false);
  const [loopFading, setLoopFading] = useState(false);
  const timeoutRef    = useRef<ReturnType<typeof setTimeout> | null>(null);
  const loopFadingRef = useRef(false);

  useEffect(() => {
    if (isSlowConnection()) return;
    setTryVideo(true);
    timeoutRef.current = setTimeout(() => setTryVideo(false), VIDEO_TIMEOUT_MS);
    return () => { if (timeoutRef.current) clearTimeout(timeoutRef.current); };
  }, []);

  const handlePlaying = useCallback(() => {
    if (timeoutRef.current) clearTimeout(timeoutRef.current);
    setShowVideo(true);
  }, []);

  // Fades to deep navy just before the loop, fades back out once past it
  const handleTimeUpdate = useCallback((currentTime: number, duration: number) => {
    if (!duration) return;
    const remaining = duration - currentTime;
    if (!loopFadingRef.current && remaining < 2.0) {
      loopFadingRef.current = true;
      setLoopFading(true);
    } else if (loopFadingRef.current && currentTime < 0.5) {
      loopFadingRef.current = false;
      setLoopFading(false);
    }
  }, []);

  return { tryVideo, showVideo, loopFading, handlePlaying, handleTimeUpdate };
}
