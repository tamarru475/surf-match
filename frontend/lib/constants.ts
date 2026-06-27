import type { CrowdLevel, Facility, Region, SkillLevel, WaveSize, WaveType } from './types';

// ── Region display ────────────────────────────────────────────────────────────

export const REGION_LABELS: Record<Region, string> = {
  Northland:    'Northland',
  Auckland:     'Auckland',
  Coromandel:   'Coromandel',
  BayOfPlenty:  'Bay of Plenty',
  Waikato:      'Waikato',
  Gisborne:     'Gisborne',
  Christchurch: 'Christchurch',
  Taranaki:     'Taranaki',
  Kaikoura:     'Kaikoura',
};

export const REGION_GRADIENTS: Record<Region, string> = {
  Northland:    'linear-gradient(135deg, #06b6d4, #1d4ed8)',
  Auckland:     'linear-gradient(135deg, #0ea5e9, #4338ca)',
  Coromandel:   'linear-gradient(135deg, #14b8a6, #0891b2)',
  BayOfPlenty:  'linear-gradient(135deg, #38bdf8, #0284c7)',
  Waikato:      'linear-gradient(135deg, #0284c7, #1e3a5f)',
  Gisborne:     'linear-gradient(135deg, #22d3ee, #0f766e)',
  Christchurch: 'linear-gradient(135deg, #64748b, #1d4ed8)',
  Taranaki:     'linear-gradient(135deg, #10b981, #0369a1)',
  Kaikoura:     'linear-gradient(135deg, #6366f1, #0e7490)',
};

// ── Wave size display ─────────────────────────────────────────────────────────

export const WAVE_SIZE_LABELS: Record<WaveSize, string> = {
  AnkleHigh:      'Ankle High',
  KneeHigh:       'Knee High',
  WaistHigh:      'Waist High',
  HeadHigh:       'Head High',
  DoubleOverhead: 'Double Overhead',
};

// ── Wave type display ─────────────────────────────────────────────────────────

export const WAVE_TYPE_LABELS: Record<WaveType, string> = {
  BeachBreak: 'Beach Break',
  PointBreak: 'Point Break',
  ReefBreak:  'Reef Break',
};

// ── Facility display ──────────────────────────────────────────────────────────

export const FACILITY_LABELS: Record<Facility, string> = {
  Bathrooms:  'Bathrooms',
  Showers:    'Showers',
  SurfClub:   'Surf Club',
  Rentals:    'Rentals',
  Lifeguard:  'Lifeguard',
  Campground: 'Campground',
};

// ── Crowd badge ───────────────────────────────────────────────────────────────

export interface Badge {
  label: string;
  variant: 'badgeGreen' | 'badgeAmber' | 'badgeRed' | 'badgeBlue' | 'badgePurple';
}

export const CROWD_BADGES: Record<CrowdLevel, Badge> = {
  Quiet:    { label: 'Quiet',    variant: 'badgeGreen' },
  Moderate: { label: 'Moderate', variant: 'badgeAmber' },
  Busy:     { label: 'Crowded',  variant: 'badgeRed'   },
};

// ── Skill badge ───────────────────────────────────────────────────────────────

export const SKILL_BADGES: Record<SkillLevel, Badge> = {
  NewToSurfing: { label: 'New to surfing', variant: 'badgeGreen'  },
  Beginner:     { label: 'Beginner',       variant: 'badgeGreen'  },
  Intermediate: { label: 'Intermediate',   variant: 'badgeBlue'   },
  Advanced:     { label: 'Advanced',       variant: 'badgePurple' },
  Expert:       { label: 'Expert',         variant: 'badgeRed'    },
};

// ── Spot photos ───────────────────────────────────────────────────────────────
// Add real photo paths here as they become available.
// Falls back to REGION_GRADIENTS when no image is set.

export const SPOT_IMAGES: Partial<Record<string, string>> = {
  'Ngarunui Beach':  '/images/ngarunui.jpeg',
  'Manu Bay':        '/images/Manu-bay.jpg',
  'Mount Maunganui': '/images/Mount-Maunganui.jpg',
  'Gisborne Town':   '/images/Gisborne-town.jpg',
  'Makorori Point':  '/images/Makarori-Point.jpg',
  'Scarborough':     '/images/Scarborough.jpg',
  'Mangawhai Heads': '/images/Mangawhai-Heads.jpg',
  'Orewa Beach':     '/images/orewa.jpg',
  'Omaha':           '/images/Omaha.jpg',
  'Te Arai':         '/images/te-arai.jpg',
  'Forestry':        '/images/Forestry.jpeg',
  'Muriwai':         '/images/Muriwai.jpg',
  'Piha':            '/images/piha.jpg',
  'Tawharanui':      '/images/Tawharanui.jpg',
  'Waihi Beach':     '/images/Waihi-Beach.JPG',
  'Pauanui':         '/images/pauanui.jpeg',
  'Whangamata':      '/images/Whangamata.jpg',
  'Waipu Cove':      '/images/waipu-cove.jpg',
  'Shipwreck Bay':   '/images/Shipwreck-Bay.JPG',
  'Bethells Beach':  '/images/Bethells-Beach.jpg',
  'Sandy Bay':       '/images/sandy-bay.jpg',
  'Stent Road':      '/images/Stent-Road.jpg',
  'Kumara Patch':    '/images/Kumara-Patch.jpg',
  'Back Beach':      '/images/Back-Beach.jpg',
  'Takapuna Reef':   '/images/Takapuna-Reef.jpg',
  'Daniels Reef':    '/images/Daniels-Reef.jpg',
  'Wainui Beach':    '/images/Pines-Wainui-Beach.jpg',
  'Meatworks':       '/images/meatworks.jpg',
  'Mangamaunu':      '/images/Mangamaunu.jpg',
};
