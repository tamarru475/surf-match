import type { SkillLevel } from './types';

export interface SkillQuestion {
  id: string;
  text: string;
  ifNo: SkillLevel;
}

export const SKILL_QUESTIONS: SkillQuestion[] = [
  { id: 'catch_wave',     text: 'Can you catch a wave unassisted?',                                                           ifNo: 'NewToSurfing'  },
  { id: 'down_line',      text: 'Can you surf down the line, ride a green wave, and stay in the pocket?',                     ifNo: 'NewToSurfing'  },
  { id: 'duck_dive',      text: 'Can you duck dive or turtle roll through a breaking wave?',                                  ifNo: 'Beginner'      },
  { id: 'read_wave',      text: 'Do you read waves well — confident when to paddle and whether to go left or right?',         ifNo: 'Beginner'      },
  { id: 'catch_rate',     text: 'Do you catch most of the waves you paddle for?',                                             ifNo: 'Beginner'      },
  { id: 'gear_comfort',   text: 'Are you confident and comfortable with your gear and in the water?',                         ifNo: 'Beginner'      },
  { id: 'crowd_rules',    text: 'Are you comfortable around some crowd and know the rules of priority?',                      ifNo: 'Beginner'      },
  { id: 'waist_high',     text: 'Are you comfortable in above waist-high conditions?',                                        ifNo: 'Intermediate'  },
  { id: 'fast_wave',      text: 'Are you comfortable surfing a fast-breaking wave?',                                          ifNo: 'Intermediate'  },
  { id: 'turns',          text: 'Can you perform turns and manoeuvres to stay in the curl?',                                  ifNo: 'Intermediate'  },
  { id: 'commitment',     text: 'Do you drop into waves with commitment?',                                                    ifNo: 'Intermediate'  },
  { id: 'busy_days',      text: 'Are you confident surfing busier days by yourself?',                                         ifNo: 'Intermediate'  },
  { id: 'point_reef',     text: 'Are you comfortable surfing point and reef breaks?',                                         ifNo: 'Intermediate'  },
  { id: 'head_high',      text: 'Are you comfortable in head-high and above conditions?',                                     ifNo: 'Advanced'      },
  { id: 'hollow_waves',   text: 'Are you comfortable with shallow reef breaks and hollow waves?',                             ifNo: 'Advanced'      },
  { id: 'all_conditions', text: 'Most days, regardless of conditions or crowd, are you confident in the water?',              ifNo: 'Advanced'      },
];

/**
 * Returns the determined SkillLevel if this answer resolves the assessment,
 * or null if the quiz should advance to the next question.
 */
export function evaluateAnswer(index: number, yes: boolean): SkillLevel | null {
  if (!yes) return SKILL_QUESTIONS[index].ifNo;
  if (index === SKILL_QUESTIONS.length - 1) return 'Expert';
  return null;
}

export interface SkillLevelTheme {
  label:       string;
  description: string;
  topBg:       string;
  accent:      string;
  iconBg:      string;
  badgeBg:     string;
}

export const SKILL_LEVEL_THEMES: Record<SkillLevel, SkillLevelTheme> = {
  NewToSurfing: { label: 'New to surfing', description: 'Just getting started — paddling and balance.',         topBg: '#f8fafc', accent: '#475569', iconBg: '#64748b', badgeBg: '#e2e8f0' },
  Beginner:     { label: 'Beginner',       description: 'Catching green waves and learning to trim.',           topBg: '#f0fdf4', accent: '#166534', iconBg: '#16a34a', badgeBg: '#dcfce7' },
  Intermediate: { label: 'Intermediate',   description: 'Riding unbroken waves and working on turns.',          topBg: '#eff6ff', accent: '#1e40af', iconBg: '#2563eb', badgeBg: '#dbeafe' },
  Advanced:     { label: 'Experienced',    description: 'Comfortable in most conditions and lineups.',          topBg: '#fff7ed', accent: '#9a3412', iconBg: '#c2410c', badgeBg: '#fed7aa' },
  Expert:       { label: 'Expert',         description: 'Charging serious surf and chasing performance.',       topBg: '#f5f3ff', accent: '#6b21a8', iconBg: '#7c3aed', badgeBg: '#ede9fe' },
};
