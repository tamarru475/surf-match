'use client';

import Button from '@/components/ui/Button';
import MultiSelect from '@/components/ui/MultiSelect';
import { LinesIcon } from '@/components/ui/Icons';
import { SKILL_LEVELS, CROWD_LEVELS, BOARD_TYPES, WAVE_TYPES, WAVE_SIZES, FACILITIES } from '@/lib/types';
import type { UserPreferences, SkillLevel, CrowdLevel, Region } from '@/lib/types';
import { usePreferencesViewModel, REGION_OPTIONS } from './preferences.viewmodel';
import { formatEnum } from '../profile.viewmodel';
import styles from './PreferencesCard.module.css';

interface Props {
  preferences: UserPreferences | null;
}

const PreferencesCard = ({ preferences }: Props) => {
  const vm = usePreferencesViewModel(preferences);

  return (
    <div className={styles.card}>
      <div className={styles.header}>
        <p className={styles.title}>Surf Preferences</p>
        <span className={styles.subLabel}>
          <LinesIcon />
          from your quiz
        </span>
      </div>

      {preferences ? (
        <>
          <div className={styles.grid}>
            <div className={styles.item}>
              <span className={styles.label}>Skill Level</span>
              <div className={styles.selectWrap}>
                <select
                  className={styles.selectPill}
                  value={vm.skillLevel}
                  onChange={e => vm.setSkillLevel(e.target.value as SkillLevel)}
                >
                  {SKILL_LEVELS.map(v => <option key={v} value={v}>{formatEnum(v)}</option>)}
                </select>
                <span className={styles.selectArrow}>▾</span>
              </div>
            </div>

            <div className={styles.item}>
              <span className={styles.label}>Crowd Tolerance</span>
              <div className={styles.selectWrap}>
                <select
                  className={styles.selectPill}
                  value={vm.crowdTolerance}
                  onChange={e => vm.setCrowdTolerance(e.target.value as CrowdLevel)}
                >
                  {CROWD_LEVELS.map(v => <option key={v} value={v}>{formatEnum(v)}</option>)}
                </select>
                <span className={styles.selectArrow}>▾</span>
              </div>
            </div>

            <div className={styles.item}>
              <span className={styles.label}>Search Region</span>
              <div className={styles.selectWrap}>
                <select
                  className={styles.selectPill}
                  value={vm.prefRegion}
                  onChange={e => vm.setPrefRegion(e.target.value as Region | '')}
                >
                  <option value="">Any region</option>
                  {REGION_OPTIONS.map(r => <option key={r} value={r}>{formatEnum(r)}</option>)}
                </select>
                <span className={styles.selectArrow}>▾</span>
              </div>
            </div>

            <div className={styles.item}>
              <span className={styles.label}>Board Types</span>
              <MultiSelect
                options={BOARD_TYPES}
                selected={vm.boardTypes}
                onToggle={vm.toggleBoardType}
                formatLabel={formatEnum}
              />
            </div>

            <div className={styles.item}>
              <span className={styles.label}>Wave Types</span>
              <MultiSelect
                options={WAVE_TYPES}
                selected={vm.waveTypes}
                onToggle={vm.toggleWaveType}
                formatLabel={formatEnum}
              />
            </div>

            <div className={styles.item}>
              <span className={styles.label}>Wave Sizes</span>
              <MultiSelect
                options={WAVE_SIZES}
                selected={vm.waveSizes}
                onToggle={vm.toggleWaveSize}
                formatLabel={formatEnum}
              />
            </div>

            <div className={`${styles.item} ${styles.itemFull}`}>
              <span className={styles.label}>Facilities</span>
              <MultiSelect
                options={FACILITIES}
                selected={vm.facilities}
                onToggle={vm.toggleFacility}
                formatLabel={formatEnum}
              />
            </div>
          </div>

          <div className={styles.saveRow}>
            {vm.prefsSaveSuccess ? (
              <span className={styles.savedText}>Saved!</span>
            ) : vm.isPreferencesDirty ? (
              <Button variant="primary" size="sm" onClick={vm.handleSavePreferences} disabled={vm.savingPreferences}>
                {vm.savingPreferences ? 'Saving…' : 'Save preferences'}
              </Button>
            ) : null}
            {vm.error && <span className={styles.error}>{vm.error}</span>}
          </div>
        </>
      ) : (
        <p className={styles.noPrefs}>No preferences saved yet — take the quiz first.</p>
      )}
    </div>
  );
};

export default PreferencesCard;
