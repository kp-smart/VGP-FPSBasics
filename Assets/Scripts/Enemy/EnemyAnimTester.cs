using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimTester : MonoBehaviour
{
    private Animator anim;
    public KeyCode attackKey = KeyCode.X;
    public KeyCode runKey = KeyCode.Z;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HandleAnimations();
    }

    void HandleAnimations()
    {
        if (Input.GetKeyDown(attackKey))
        {
            anim.SetTrigger("Attack");
        }

        // 2. Handle Booleans for Idle and Running
        // Logic: If moving and holding Shift, set IsRunning to true.
        bool isRunning = Input.GetKey(runKey);

        if (isRunning)
        {
            anim.SetBool("IsRunning", true);
            anim.SetBool("IsIdle", false);
        } else {
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsIdle", true);
        }
    }
}
