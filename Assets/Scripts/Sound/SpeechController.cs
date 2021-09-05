using UnityEngine;
using TMPro;

public class SpeechController: MonoBehaviour
{   
    public static SpeechController instance;
    private static bool muteAud;

    // beforeGameStartClip is attached to aud
    private AudioSource aud;

    [SerializeField]
    private AudioClip afterGameStartClip;

    [SerializeField]
    private TextAsset speechTextAsset;
    private string beforeGameStartText, afterGameStartText;

    [SerializeField]
    private TextMeshProUGUI transcriptText;

    void Start()
    {
        instance = this;

        aud = GetComponent<AudioSource>();   
        aud.mute = muteAud;

        string[] textParts = speechTextAsset.ToString().Split('*');
        
        beforeGameStartText = textParts[1];
        afterGameStartText = textParts[0];

        if(FindObjectOfType<GameController>().isItfirstGame)
        {
            aud.Play();
            transcriptText.SetText(beforeGameStartText);
        }
        else
        {
            transcriptText.SetText("Try Again");
        }
    }

    public void StartInGameSpeech()
    {
        aud.clip = afterGameStartClip;
        aud.Play();

        transcriptText.SetText(afterGameStartText);
    }

    public void SetSpeechMuteState()
    {
        muteAud = !muteAud;
        aud.mute = muteAud;
    }
}