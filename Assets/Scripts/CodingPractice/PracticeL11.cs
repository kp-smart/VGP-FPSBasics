using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeL11 : MonoBehaviour
{
    public string s = "racecar";
    // Start is called before the first frame update
    void Start()
    {
        if (palindromeCheck(s))
        {
            Debug.Log(s + " is a palindrome!");
        } else
        {
            Debug.Log(s + " is not a palindrome!");
        }
    }

    bool palindromeCheck(string forward)
    {
        char[] splitToChar = forward.ToCharArray();
        string reverse = "";

        for (int i = forward.Length - 1; i >= 0; i--)
        {
            reverse += splitToChar[i];
        }

        if(reverse == forward)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
