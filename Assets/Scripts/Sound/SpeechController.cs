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

    [SerializeField]
    private GameObject speechPanelObj;

    void Start()
    {
        instance = this;

        aud = GetComponent<AudioSource>();   
        aud.mute = muteAud;

        string[] textParts = speechTextAsset.ToString().Split('*');
        
        beforeGameStartText = textParts[1];
        afterGameStartText = textParts[0];

        if(GameController.isItfirstGame)
        {
            aud.Play();
            transcriptText.SetText(beforeGameStartText);
        }
        else
        {
            transcriptText.SetText("Try Again");
        }
    }

    // Note: Temporary Code
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            speechPanelObj.SetActive(!speechPanelObj.activeSelf);
        }
    }

    public void StartInGameSpeech()
    {
        if(aud.clip != afterGameStartClip)
        {
            aud.clip = afterGameStartClip;
            aud.Play();

            transcriptText.SetText(afterGameStartText);
        }
    }

    public void StopSpeech()
    {
        aud.Stop();
    }

    public void SetSpeechMuteState()
    {
        muteAud = !muteAud;
        aud.mute = muteAud;
    }
}