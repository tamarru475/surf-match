export type SkillLevel = 'Beginner' | 'Intermediate' | 'Advanced' | 'Expert';
export type CrowdLevel = 'Quiet' | 'Moderate' | 'Busy';
export type Region = 'Northland' | 'Auckland' | 'Coromandel' | 'BayOfPlenty' | 'Waikato' | 'Gisborne' | 'Christchurch' | 'Taranaki' | 'Kaikoura';
export type WaveType = 'BeachBreak' | 'PointBreak' | 'ReefBreak';
export type WaveSize = 'AnkleHigh' | 'KneeHigh' | 'WaistHigh' | 'HeadHigh' | 'DoubleOverhead';
export type BoardType = 'Rental' | 'Longboard' | 'Shortboard' | 'Fish' | 'Funboard';
export type Facility = 'Bathrooms' | 'Showers' | 'SurfClub' | 'Rentals' | 'Lifeguard' | 'Campground';

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
  summary: string;
  breakdown: ScoreBreakdown;
}

export interface RecommendationResponse {
  preferences: UserPreferences;
  recommendations: SpotRecommendation[];
}

