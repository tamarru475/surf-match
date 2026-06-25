export interface QuestionOption {
  label: string;
  value: string;
}

export interface Question {
  field: string;
  title: string;
  subtitle: string;
  required: boolean;
  multiSelect: boolean;
  options: QuestionOption[];
}

export const QUESTIONS: Question[] = [
  {
    field: 'skillLevel',
    title: "What's your surf level?",
    subtitle: 'Required · choose one',
    required: true,
    multiSelect: false,
    options: [
      { label: 'Beginner', value: 'Beginner' },
      { label: 'Intermediate', value: 'Intermediate' },
      { label: 'Advanced', value: 'Advanced' },
      { label: 'Expert', value: 'Expert' },
    ],
  },
  {
    field: 'crowdTolerance',
    title: 'How do you feel about crowds?',
    subtitle: 'Required · choose one',
    required: true,
    multiSelect: false,
    options: [
      { label: 'Quiet', value: 'Quiet' },
      { label: 'Moderate', value: 'Moderate' },
      { label: 'Busy is fine', value: 'Busy' },
    ],
  },
  {
    field: 'preferredRegion',
    title: 'Which region are you in?',
    subtitle: 'Required · choose one',
    required: true,
    multiSelect: false,
    options: [
      { label: 'Northland', value: 'Northland' },
      { label: 'Auckland', value: 'Auckland' },
      { label: 'Coromandel', value: 'Coromandel' },
      { label: 'Bay of Plenty', value: 'BayOfPlenty' },
      { label: 'Waikato', value: 'Waikato' },
      { label: 'Gisborne', value: 'Gisborne' },
      { label: 'Christchurch', value: 'Christchurch' },
      { label: 'Taranaki', value: 'Taranaki' },
      { label: 'Kaikoura', value: 'Kaikoura' },
    ],
  },
  {
    field: 'boardTypes',
    title: 'What boards do you have?',
    subtitle: "Optional · select all that apply, or tap Skip — you don't have to answer",
    required: false,
    multiSelect: true,
    options: [
      { label: 'Rental', value: 'Rental' },
      { label: 'Longboard', value: 'Longboard' },
      { label: 'Shortboard', value: 'Shortboard' },
      { label: 'Fish', value: 'Fish' },
      { label: 'Funboard', value: 'Funboard' },
    ],
  },
  {
    field: 'preferredWaveTypes',
    title: 'What type of waves are you after?',
    subtitle: "Optional · select all that apply, or tap Skip — you don't have to answer",
    required: false,
    multiSelect: true,
    options: [
      { label: 'Beach Break', value: 'BeachBreak' },
      { label: 'Point Break', value: 'PointBreak' },
      { label: 'Reef Break', value: 'ReefBreak' },
    ],
  },
  {
    field: 'preferredWaveSizes',
    title: "What wave sizes are you comfortable with?",
    subtitle: "Optional · select all that apply, or tap Skip — you don't have to answer",
    required: false,
    multiSelect: true,
    options: [
      { label: 'Ankle High', value: 'AnkleHigh' },
      { label: 'Knee High', value: 'KneeHigh' },
      { label: 'Waist High', value: 'WaistHigh' },
      { label: 'Head High', value: 'HeadHigh' },
      { label: 'Double Overhead', value: 'DoubleOverhead' },
    ],
  },
  {
    field: 'preferredFacilities',
    title: 'Any facilities you need?',
    subtitle: "Optional · select all that apply, or tap Skip — you don't have to answer",
    required: false,
    multiSelect: true,
    options: [
      { label: 'Bathrooms', value: 'Bathrooms' },
      { label: 'Showers', value: 'Showers' },
      { label: 'Surf Club', value: 'SurfClub' },
      { label: 'Rentals', value: 'Rentals' },
      { label: 'Lifeguard', value: 'Lifeguard' },
      { label: 'Campground', value: 'Campground' },
    ],
  },
];
