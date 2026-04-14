using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeL10 : MonoBehaviour
{
    public int money;
    int bill = 100;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            if (i == 2)
            {
                bill = 20;
            }

            if (i == 5)
            {
                bill = 1;
            }

            int numBills = (money - (money % bill)) / bill;
            Debug.Log(numBills + " $" + bill + " bills");
            money -= numBills*bill;
            bill /= 2;
        }
    }
}
