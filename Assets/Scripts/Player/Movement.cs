using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public GameObject player;
    private Transform myTransform;
    public float speedMult;

    public float numKills = 0;
    public float numCoins = 0;
    public TextMeshProUGUI numKillsUI;
    public TextMeshProUGUI numCoinsUI;

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
        myTransform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speedMult);
        myTransform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speedMult);

        numKillsUI.text = "Enemies Killed: " + numKills;
        numCoinsUI.text = "Coins Collected: " + numCoins;
    }
}
