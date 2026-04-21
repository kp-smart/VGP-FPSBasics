using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeL12 : MonoBehaviour
{
    public int[] playerScores = { 450, 1200, 340, 890, 2100, 150, 780, 1050 };

    // Start is called before the first frame update
    void Start()
    {
        FindMinorMax(playerScores);
    }

    void FindMinorMax(int[] scores)
    {
        int min = 1000000000;
        int max = 0;

        for(int i = 0; i <= scores.Length - 1; i++)
        {
            if (scores[i] < min)
            {
                min = scores[i];
            }

            if (scores[i] > max)
            {
                max = scores[i];
            }
        }

        Debug.Log("MVP Score: " + max);
        Debug.Log("Needs Improvement Score: " + min);
    }
}
