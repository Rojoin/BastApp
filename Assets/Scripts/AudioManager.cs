using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    private string currentTheme;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    void Start()
    {
        currentTheme = "Theme";
        Play(currentTheme);
    }

    private Sound FindSound(string name)
    {
        Sound sound = Array.Find<Sound>(sounds, sound => sound.name == name);
        if (sound == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return null;
        }
        return sound;
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sound sound = FindSound(name);
        if (sound == null) return;

        sound.source.Play();
    }

    public void PlayTheme(string name)
    {
        Sound sound = FindSound(name);
        if (sound == null) return;

        currentTheme = name;
        sound.source.Play();
    }

    public void StopCurrentTheme()
    {
        Sound sound = FindSound(currentTheme);
        sound.source.Stop();
    }

    public void Stop(string name)
    {
        Sound sound = FindSound(name);
        if (sound == null) return;

        sound.source.Stop();
    }
}
