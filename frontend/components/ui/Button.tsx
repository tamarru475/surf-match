'use client';

import React from 'react';
import { cx } from '@/lib/utils';
import styles from './Button.module.css';

interface ButtonProps extends React.ButtonHTMLAttributes<HTMLButtonElement> {
  variant?: 'primary' | 'secondary' | 'ghost';
  size?: 'sm' | 'md' | 'lg';
}

const Button = ({
  variant = 'primary',
  size = 'md',
  className,
  children,
  ...props
}: ButtonProps) => (
  <button
    className={cx(styles.base, styles[variant], styles[size], className)}
    {...props}
  >
    {children}
  </button>
);

export default Button;
