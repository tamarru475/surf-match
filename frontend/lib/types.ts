export type SkillLevel = 'NewToSurfing' | 'Beginner' | 'Intermediate' | 'Advanced' | 'Expert';
export const SKILL_LEVELS: SkillLevel[] = ['NewToSurfing', 'Beginner', 'Intermediate', 'Advanced', 'Expert'];

export type CrowdLevel = 'Quiet' | 'Moderate' | 'Busy';
export const CROWD_LEVELS: CrowdLevel[] = ['Quiet', 'Moderate', 'Busy'];

export type Region = 'Northland' | 'Auckland' | 'Coromandel' | 'BayOfPlenty' | 'Waikato' | 'Gisborne' | 'Christchurch' | 'Taranaki' | 'Kaikoura' | 'Wellington' | 'Otago';
export const REGIONS: Region[] = ['Northland', 'Auckland', 'Coromandel', 'BayOfPlenty', 'Waikato', 'Gisborne', 'Christchurch', 'Taranaki', 'Kaikoura', 'Wellington', 'Otago'];

export type WaveType = 'BeachBreak' | 'PointBreak' | 'ReefBreak';
export const WAVE_TYPES: WaveType[] = ['BeachBreak', 'PointBreak', 'ReefBreak'];

export type WaveSize = 'AnkleHigh' | 'KneeHigh' | 'WaistHigh' | 'HeadHigh' | 'DoubleOverhead';
export const WAVE_SIZES: WaveSize[] = ['AnkleHigh', 'KneeHigh', 'WaistHigh', 'HeadHigh', 'DoubleOverhead'];

export type BoardType = 'Rental' | 'Longboard' | 'Shortboard' | 'Fish' | 'Funboard';
export const BOARD_TYPES: BoardType[] = ['Rental', 'Longboard', 'Shortboard', 'Fish', 'Funboard'];

export type Facility = 'Bathrooms' | 'Showers' | 'SurfClub' | 'Rentals' | 'Lifeguard' | 'Campground';
export const FACILITIES: Facility[] = ['Bathrooms', 'Showers', 'SurfClub', 'Rentals', 'Lifeguard', 'Campground'];

export interface UserPreferences {
  skillLevel: SkillLevel;
  crowdTolerance: CrowdLevel;
  preferredRegion?: Region;
  boardTypes: BoardType[];
  preferredWaveTypes: WaveType[];
  preferredWaveSizes: WaveSize[];
  preferredFacilities: Facility[];
}

export interface ScoreBreakdown {
  skillMatch: number;
  boardMatch: number;
  crowdMatch: number;
  regionMatch: number;
  waveTypeMatch: number;
  waveSizeMatch: number;
  facilityMatch: number;
}

export interface SpotRecommendation {
  spotId: string;
  name: string;
  region: Region;
  waveType: WaveType;
  minSkillLevel: SkillLevel;
  typicalCrowd: CrowdLevel;
  facilities: Facility[];
  currentWaveSize: WaveSize;
  description: string;
  score: number;
  notes: string[];
  breakdown: ScoreBreakdown;
}

export interface Profile {
  id: string;
  email: string;
  displayName: string | null;
  avatarUrl: string | null;
  location: string | null;
  bio: string | null;
  instagramHandle: string | null;
  tikTokHandle: string | null;
}

export interface UpdateProfileData {
  displayName: string | null;
  location: string | null;
  bio: string | null;
  instagramHandle: string | null;
  tikTokHandle: string | null;
}

export interface RecommendationResponse {
  preferences: UserPreferences;
  recommendations: SpotRecommendation[];
  warnings: string[];
}

