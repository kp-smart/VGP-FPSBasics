using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private const string doorTrigger = "CanOpen";
    public bool hasKey = false;
    public Animator doorAnimator;
    private bool doorHasOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        if(doorAnimator == null)
        {
            doorAnimator = GetComponent<Animator>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasKey && collision.gameObject.CompareTag("Player") && !doorHasOpened)
        {
            doorHasOpened = true;
            doorAnimator.SetTrigger(doorTrigger);
        }
    }
}
