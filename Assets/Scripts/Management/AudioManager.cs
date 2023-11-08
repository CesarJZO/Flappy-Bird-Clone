using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Management
{
    public sealed class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource effectSource;

        public float Volume
        {
            get => AudioListener.volume;
            set
            {
                float volume = Mathf.Clamp(value, 0f, 1f);
                AudioListener.volume = volume;
            }
        }

        public float MusicVolume
        {
            get => musicSource.volume;
            set => musicSource.volume = value;
        }

        public float EffectVolume
        {
            get => effectSource.volume;
            set => effectSource.volume = value;
        }

        private void Awake()
        {
            if (Instance)
                Destroy(gameObject);
            else
                Instance = this;
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void Play(AudioClip clip)
        {
            effectSource.pitch = 1f;
            effectSource.PlayOneShot(clip);
        }

        public void PlayPitchVariable(AudioClip clip)
        {
            effectSource.pitch = Random.Range(0.9f, 1.1f);
            effectSource.PlayOneShot(clip);
        }

        public void ToggleMusic()
        {
            musicSource.mute = !musicSource.mute;
        }

        public void ToggleEffect()
        {
            effectSource.mute = !effectSource.mute;
        }
    }
}
