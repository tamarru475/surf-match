'use client';

import Cropper from 'react-easy-crop';
import { X } from 'lucide-react';
import Button from '@/components/ui/Button';
import { useAvatarCropModalViewModel } from './AvatarCropModal.viewmodel';
import styles from './AvatarCropModal.module.css';

interface Props {
  imageSrc: string;
  onConfirm: (blob: Blob) => void;
  onClose: () => void;
}

const AvatarCropModal = ({ imageSrc, onConfirm, onClose }: Props) => {
  const vm = useAvatarCropModalViewModel(imageSrc, onConfirm);

  return (
    <div className={styles.backdrop}>
      <div className={styles.overlay} onClick={onClose} />

      <div className={styles.panel}>
        <div className={styles.header}>
          <span className={styles.title}>Adjust photo</span>
          <button className={styles.closeBtn} onClick={onClose}>
            <X size={16} />
          </button>
        </div>

        <div className={styles.cropArea}>
          <Cropper
            image={imageSrc}
            crop={vm.crop}
            zoom={vm.zoom}
            aspect={1}
            cropShape="round"
            showGrid={false}
            onCropChange={vm.setCrop}
            onZoomChange={vm.setZoom}
            onCropComplete={vm.handleCropComplete}
          />
        </div>

        <div className={styles.footer}>
          <div className={styles.zoomRow}>
            <span className={styles.zoomLabel}>Zoom</span>
            <input
              type="range"
              className={styles.slider}
              min={1}
              max={3}
              step={0.01}
              value={vm.zoom}
              onChange={(e) => vm.setZoom(Number(e.target.value))}
            />
          </div>
          <div className={styles.btnRow}>
            <Button variant="ghost" className="flex-1" onClick={onClose}>
              Cancel
            </Button>
            <Button
              variant="primary"
              className="flex-[2]"
              onClick={vm.handleSave}
              disabled={vm.saving}
            >
              {vm.saving ? 'Saving…' : 'Save photo'}
            </Button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default AvatarCropModal;
