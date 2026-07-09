import type { Metadata } from 'next';
import './globals.css';
import { AuthProvider } from '@/lib/AuthContext';
import AuthModal from '@/components/auth/AuthModal';

export const metadata: Metadata = {
  title: 'SurfMatch — Find your perfect wave',
  description: 'Match your skill level and preferences to the best New Zealand surf spots for today.',
};

export default function RootLayout({ children }: { children: React.ReactNode }) {
  return (
    <html lang="en" className="h-full antialiased">
      <body className="min-h-full flex flex-col" suppressHydrationWarning>
        <AuthProvider>
          {children}
          <AuthModal />
        </AuthProvider>
      </body>
    </html>
  );
}
