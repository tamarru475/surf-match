export interface QuestionOption {
  label: string;
  value: string;
}

export interface TooltipItem {
  label: string;
  description: string;
  /** Path under /public to a representative photo for this item. */
  image: string;
}

export interface TooltipTerm {
  label: string;
  description: string;
}

export interface Question {
  field: string;
  title: string;
  subtitle: string;
  required: boolean;
  multiSelect: boolean;
  options: QuestionOption[];
  /** Short explainer shown behind an info icon next to the title. */
  tooltip?: string;
  /** A label + description per line, e.g. one row per skill level. */
  tooltipTerms?: TooltipTerm[];
  /** A colored, warning-styled note (e.g. "many spots have no facilities"). */
  tooltipWarning?: string;
  /** Richer alternative shown as a full modal: an image + description per item. */
  tooltipItems?: TooltipItem[];
  /** For multi-select questions: a sentinel option value that's mutually
   *  exclusive with all the others (e.g. "No facilities needed"). */
  noneValue?: string;
}

export const QUESTIONS: Question[] = [
  {
    field: 'skillLevel',
    title: "What's your surf level?",
    subtitle: 'Required · choose one',
    required: true,
    multiSelect: false,
    tooltipTerms: [
      { label: 'New to surfing', description: "Never been on a board." },
      { label: 'Beginner', description: 'Still learning to stand up and catch whitewater.' },
      { label: 'Intermediate', description: 'Can catch unbroken waves and turn.' },
      { label: 'Advanced', description: 'Comfortable in bigger surf and steeper drops.' },
      { label: 'Expert', description: 'Chasing high-performance or heavy waves.' },
    ],
    options: [
      { label: 'New to surfing', value: 'NewToSurfing' },
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
      { label: 'Anywhere in NZ', value: 'Anywhere' },
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
    tooltipItems: [
      {
        label: 'Beach Break',
        description: 'Sand bottom, peels along an open beach — most forgiving.',
        image: '/images/beachbreak.jpg',
      },
      {
        label: 'Point Break',
        description: 'Wraps around a headland, often a longer, easier ride.',
        image: '/images/pointbreak.jpg',
      },
      {
        label: 'Reef Break',
        description: 'Breaks over rock or coral — can be shallow and intense.',
        image: '/images/reefbreak.jpg',
      },
    ],
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
    noneValue: 'None',
    tooltipWarning:
      "Many NZ surf spots are remote beaches with no bathrooms, showers, or shops nearby. Pick what matters and we'll favor spots that have it, but we'll still show you great spots either way.",
    options: [
      { label: 'No facilities needed', value: 'None' },
      { label: 'Bathrooms', value: 'Bathrooms' },
      { label: 'Showers', value: 'Showers' },
      { label: 'Surf Club', value: 'SurfClub' },
      { label: 'Rentals', value: 'Rentals' },
      { label: 'Lifeguard', value: 'Lifeguard' },
      { label: 'Campground', value: 'Campground' },
    ],
  },
];
