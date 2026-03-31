using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3 : MonoBehaviour
{
    public int input = 5;

    // Start is called before the first frame update
    void Start()
    {
        solution(input);
    }

    void solution(int sec)
    {
        int min = sec * 60;

        Debug.Log(sec + " seconds is " + min + " minutes.");

    }
}
