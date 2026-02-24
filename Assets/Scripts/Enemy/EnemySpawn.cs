using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 200; i++)
        {
            var position = new Vector3(Random.Range(-50, 50), 1, Random.Range(-50, 50));
            var enemy = Instantiate(EnemyPrefab, position, Quaternion.identity); //quaternion sets default rotation
            enemy.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
