using UnityEngine;
using TMPro;

public class GameProgress: MonoBehaviour
{
    public static GameProgress instance;

    [SerializeField]
    private TextMeshProUGUI text;

    private const int ALIVE_CAT_COUNT = 3;
    private float savedCatCount = 0;

    void Start()
    {
        instance = this;
        text.SetText("0/" + ALIVE_CAT_COUNT + " cat saved");
    }

    public void IncreaseSavedCatCount()
    {
        if(savedCatCount + 1 >= ALIVE_CAT_COUNT)
        {
            UIHandler.instance.NotifyGameEnd();

            text.SetText("All cats are saved, RETURN!");
        }
        else
        {
            savedCatCount++;

            if(savedCatCount > 1)
            {
                text.SetText(savedCatCount + "/" + ALIVE_CAT_COUNT + " cats saved");
            }
            else
            {
                text.SetText(savedCatCount + "/" + ALIVE_CAT_COUNT + " cat saved");
            }
        }
    }
}