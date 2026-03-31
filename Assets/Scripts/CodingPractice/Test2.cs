using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    public int[] array;
    public int a;
    // Start is called before the first frame update
    void Start()
    {
        PrintNumOddsandNumEvens(array);
    }
    void PrintNumOddsandNumEvens(int[] array)
    {
        int numOdds = 0;
        int numEvens = 0;

        for (int i = 0; i <= array.Length - 1; i++)
        {
            if (array[i] % 2 == 0)
            {
                numEvens++;
            } else
            {
                numOdds++;
            }
        }

        Debug.Log("There are " + numOdds + " odd numbers and " + numEvens + " even numbers in your array.");
    }
}
