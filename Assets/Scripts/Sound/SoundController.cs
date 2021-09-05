using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundController: MonoBehaviour
{
    private static bool muteAud;
    private AudioSource aud;
    
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip = null)
    {
        if(!aud.isPlaying)
        {
            PlayImmediately(clip);
        }
    }

    public void PlayImmediately(AudioClip clip = null)
    {
        if(!muteAud)
        {
            if(clip)
            {
                aud.clip = clip;
            }
            
            aud.Play();
        }
    }

    public static void SetSoundMuteState()
    {
        muteAud = !muteAud;
    }
}