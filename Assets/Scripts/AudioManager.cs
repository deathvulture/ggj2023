using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    private AudioSource bg1;
    private AudioSource bg2;
    private AudioSource currentSong;
    public bool bgmEnabled = false;
    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)]
        public float volume;

        [HideInInspector]
        public AudioSource source;

    }

    public Sound[] sounds;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
        }

        bg1 = Array.Find(sounds, sound => sound.name == "BG1").source;
        bg2 = Array.Find(sounds, sound => sound.name == "BG2").source;
        currentSong = bg1;
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        s.source.Play();
    }

    public void PlayLevelMusic()
    {
        bgmEnabled = true;
    }

    private void Update()
    {
        if (bgmEnabled)
            LoopBGM();
    }

    private void LoopBGM ()
    {

        if (currentSong == bg1 && !bg1.isPlaying)
        {
            currentSong = bg2;
            bg2.Play();
            return;
        }

        if (currentSong == bg2 && !bg2.isPlaying)
        {
            currentSong = bg1;
            bg1.Play();
            return;
        }
    }
    
}
