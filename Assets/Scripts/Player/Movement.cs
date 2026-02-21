using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public GameObject player;

    private Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        myTransform.Translate(Vector3.forward * verticalInput);
        myTransform.Translate(Vector3.right * horizontalInput);
    }
}
