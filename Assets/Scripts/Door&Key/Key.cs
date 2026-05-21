using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Door doorScript;

    // Start is called before the first frame update
    void Start()
    {
        if (doorScript == null)
        {
            doorScript = FindObjectOfType<Door>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        TryFindKey(collision.gameObject);
    }

    private void TryFindKey(GameObject hitObject)
    {
        if (doorScript != null && hitObject.CompareTag("Player"))
        {
            doorScript.hasKey = true;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
