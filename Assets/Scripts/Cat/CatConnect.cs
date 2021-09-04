using UnityEngine;
using System.Collections.Generic;

public class CatConnect: MonoBehaviour
{
    private List<int> gateNumbers = new List<int>(){1, 2, 3, 4, 5, 6};
    private const int DEAD_CAT_INT = 0;
    
    [SerializeField]
    private Cat[] cats;

    void Start()
    {
        if(cats.Length == 0)
        {
            Debug.Log("ERROR: There is no cat added to 'cats' array");
            return;
        }

        if(cats.Length % 2 == 0)
        {
            while(gateNumbers.Count > 0)
            {
                int randomIndex = Random.Range(1, gateNumbers.Count);
                int randomLifeState = Random.Range(0, 2);
                bool isCatDead = (randomLifeState == DEAD_CAT_INT)? true : false;

                cats[gateNumbers[0] - 1].SetCatStatus(isCatDead, gateNumbers[randomIndex]);
                cats[gateNumbers[randomIndex] - 1].SetCatStatus(!isCatDead, gateNumbers[0]);

                gateNumbers.RemoveAt(randomIndex);
                gateNumbers.RemoveAt(0);
            }
        }
        else
        {
            Debug.Log("ERROR: Cats' count isn't even ");
        }
    }
}