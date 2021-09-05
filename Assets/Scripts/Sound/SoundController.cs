using UnityEngine;

public class SoundController: MonoBehaviour
{
    private static bool muteAud;
    private AudioSource aud;
    
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip)
    {
        if(!aud.isPlaying)
        {
            PlayImmediately(clip);
        }
    }

    public void PlayImmediately(AudioClip clip)
    {
        if(!muteAud)
        {
            aud.clip = clip;
            aud.Play();
        }
    }

    public static void SetSoundMuteState()
    {
        muteAud = !muteAud;
    }
}