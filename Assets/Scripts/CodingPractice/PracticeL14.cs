using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeL14 : MonoBehaviour
{
    // Start is called before the first frame update

    public string input = "";
    void Start()
    {
        string ans = CompressMessage(input.ToUpper());
        Debug.Log(ans);
    }

    string CompressMessage(string transmission)
    {
        string ans = "";

        for (int i = 0; i < transmission.Length; i++)
        {
            ans += transmission[i];
            int repeatNum = 1;

            if (i != transmission.Length - 1)
            {
                while (transmission[i] == transmission[i + 1])
                {
                    repeatNum++;
                    i++;
                }
            }

            ans += Convert.ToString(repeatNum);
        }

        return ans;
    }
}
