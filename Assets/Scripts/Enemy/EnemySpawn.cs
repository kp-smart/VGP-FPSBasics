using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Movement myPlayer;
    public int numEnemies;
    public string nextLevelName;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numEnemies; i++)
        {
            var position = new Vector3(Random.Range(-50, 50), 1, Random.Range(-50, 50));
            var enemy = Instantiate(EnemyPrefab, position, Quaternion.identity); //quaternion sets default rotation
            enemy.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (myPlayer.numKills == numEnemies)
        {
            SceneManager.LoadScene(nextLevelName);
        }

    }
}
