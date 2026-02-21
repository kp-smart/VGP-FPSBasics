using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour
{
    public Movement myPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            myPlayer.numCoins++;
            Destroy(other.gameObject);
        }
    }
}
