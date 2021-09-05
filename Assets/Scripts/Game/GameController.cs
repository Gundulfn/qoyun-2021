using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController: MonoBehaviour
{
    public static GameController instance;
    public static bool isItfirstGame = true; 

    [SerializeField]
    private Animation timeOutLoseAnim;
    
    void Start()
    {
        instance = this;
    }

    public void StartGame()
    {
        if(isItfirstGame)
        {
            isItfirstGame = false;
        }

        SpeechController.instance.StartInGameSpeech();
        Countdown.StartCountdown();
    }

    public IEnumerator RestartGame(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    // This function is attached to EndButton in GadgetUI object
    public void GameWon()
    {
        FindObjectOfType<Player>().DisablePlayer();
        Teleportation.instance.TeleportToHome();
        MuteAllAudios();
    }

    // Time-out lose
    public void GameLose()
    {
        FindObjectOfType<InteractionController>().enabled = false;
        Teleportation.instance.DisableTeleport();

        timeOutLoseAnim.gameObject.SetActive(true);
        StartCoroutine(RestartGame(timeOutLoseAnim[timeOutLoseAnim.clip.name].length));
    }

    public IEnumerator PassToCreditsScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("CreditsScene", LoadSceneMode.Single);
    }

    public void MuteAllAudios()
    {
        AudioSource[] auds = FindObjectsOfType<AudioSource>();

        for(int i = 0; i < auds.Length; i++)
        {
            auds[i].mute = true;
        }
    }
}    