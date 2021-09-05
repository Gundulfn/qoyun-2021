using UnityEngine;
using System.Collections;
using TMPro;

public class Scan: MonoBehaviour
{
    private TextMeshProUGUI text;
    private GameObject buttonObj;

    public static int info = 0;

    [SerializeField]
    private SoundController soundController;

    [SerializeField]
    private AudioClip scanSound;

    public IEnumerator WriteScanResult()
    {
        if(!text)
        {
            text = GetComponent<TextMeshProUGUI>();
            buttonObj = transform.GetChild(0).gameObject;
        }

        soundController.Play(scanSound);
        
        string result = "Scanning";
        
        for(int i = 0; i < 3; i++)
        {
            result += ".";
            text.SetText(result);
            yield return new WaitForSeconds(.5f);
        }

        yield return new WaitForSeconds(1f);
        result += "\nConnected with Gate " + info;
        text.SetText(result);

        buttonObj.SetActive(true);
        info = 0;
    }

    public void ClearText()
    {
        text.SetText("");
        buttonObj.SetActive(false);
    }
}