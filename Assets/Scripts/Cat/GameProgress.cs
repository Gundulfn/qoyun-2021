using UnityEngine;

public class GameProgress: MonoBehaviour
{
    public static GameProgress instance;

    private const int ALIVE_CAT_COUNT = 3;
    private float savedCatCount = 0;

    void Start()
    {
        instance = this;
    }

    public void IncreaseSavedCatCount()
    {
        if(savedCatCount + 1 >= ALIVE_CAT_COUNT)
        {
            UIHandler.instance.ShowEndButton();
        }
        else
        {
            savedCatCount++;
        }
    }
}