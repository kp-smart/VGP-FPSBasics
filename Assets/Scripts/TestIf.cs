using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIf : MonoBehaviour
{
    public int a;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(printFactorial(a) + " = " + calcFactorial(a));
    }

    int calcFactorial(int a)
    {
        int ans = 0;
        for (int i = 1; i <= a; i++)
        {
            ans += i;
        }

        return ans;
    }

    string printFactorial(int a)
    {
        string fullFormula = "";
        for (int i = 1; i <= a; i++)
        {
             fullFormula += i;

            if(i != a)
            {
                fullFormula += "+";
            }
        }

        return fullFormula;
    }
}
