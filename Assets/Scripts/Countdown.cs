using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    private const int DEFAULT_MINUTE = 10;
    private const int DEFAULT_SECOND = 60;
    
    private int minute, second;
    private float time;
    private string clockText;

    [SerializeField]
    private TextMeshProUGUI text;

    void Start()
    {
        minute = DEFAULT_MINUTE;
        second = DEFAULT_SECOND;

        time = second;
    }

    void Update()
    {
        if(minute < 0)
        {
            text.SetText("00:00");
            return;    
        }

        if((int)time != second)
        {
            if(time <= 0)
            {
                time = DEFAULT_SECOND;
                second = DEFAULT_SECOND;

                minute--;
            }
            else
            {
                second = (int)time;
            }

            clockText = ((minute < 10)? "0" : "") + minute + ":" + ((second < 10)? "0" : "") + second;
            text.SetText(clockText);
        }

        time -= Time.deltaTime;
    }
}
