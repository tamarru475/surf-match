'use client';

import { X } from 'lucide-react';
import { GoogleIcon } from '@/components/ui/Icons';
import { useAuth } from '@/lib/AuthContext';
import { useAuthModalViewModel } from './AuthModal.viewmodel';
import styles from './AuthModal.module.css';

const AuthModal = () => {
  const { authModalOpen } = useAuth();
  const vm = useAuthModalViewModel();

  if (!authModalOpen) return null;

  return (
    <div className={styles.backdrop}>
      <div className={styles.overlay} onClick={vm.handleClose} />
      <div className={`${styles.panel} ${vm.isClosing ? styles.panelClosing : ''}`}>

        <button className={styles.closeBtn} onClick={vm.handleClose} aria-label="Close">
          <X size={18} />
        </button>

        <h2 key={`title-${vm.mode}`} className={styles.title}>
          {vm.mode === 'login' ? 'Welcome back' : 'Create account'}
        </h2>
        <p key={`sub-${vm.mode}`} className={styles.subtitle}>
          {vm.mode === 'login'
            ? 'Log in to access your favourites and profile.'
            : 'Save your matches, favourite spots, and more.'}
        </p>

        <button className={styles.googleBtn} onClick={vm.handleGoogle}>
          <GoogleIcon className={styles.googleIcon} />
          Continue with Google
        </button>

        <div className={styles.divider}><span>or</span></div>

        <form
          key={vm.mode}
          className={styles.form}
          onSubmit={e => { e.preventDefault(); vm.handleSubmit(); }}
        >
          <input
            type="email"
            placeholder="Email"
            value={vm.email}
            onChange={e => vm.setEmail(e.target.value)}
            className={styles.input}
            required
            autoComplete="email"
          />
          <input
            type="password"
            placeholder="Password"
            value={vm.password}
            onChange={e => vm.setPassword(e.target.value)}
            className={styles.input}
            required
            autoComplete={vm.mode === 'signup' ? 'new-password' : 'current-password'}
          />
          {vm.error && <p className={styles.error} role="alert">{vm.error}</p>}
          <button type="submit" className={styles.submitBtn} disabled={vm.loading}>
            {vm.loading ? 'Please wait…' : vm.mode === 'login' ? 'Log in' : 'Create account'}
          </button>
        </form>

        <p className={styles.toggle}>
          {vm.mode === 'login' ? "Don't have an account? " : 'Already have an account? '}
          <button className={styles.toggleBtn} onClick={vm.toggleMode}>
            {vm.mode === 'login' ? 'Sign up' : 'Log in'}
          </button>
        </p>
      </div>
    </div>
  );
};

export default AuthModal;
