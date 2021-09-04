using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController: MonoBehaviour
{
    public static GameController instance;
    
    [SerializeField]
    private Animation timeOutLoseAnim;

    void Start()
    {
        instance = this;
    }

    public IEnumerator RestartGame(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    // Couldn't decide how to finish the game, open to ideas
    // This function is attached to EndButton in GadgetUI object
    public void GameWon()
    {

    }

    // Time-out lose
    public void GameLose()
    {
        FindObjectOfType<InteractionController>().enabled = false;
        Teleportation.instance.DisableTeleport();

        timeOutLoseAnim.gameObject.SetActive(true);
        StartCoroutine(RestartGame(timeOutLoseAnim[timeOutLoseAnim.clip.name].length));
    }
}    