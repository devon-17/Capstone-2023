using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSpawner : MonoBehaviour
{
    //You may as well use transform here rather than gameobjects
    public Transform[] spawnPoints;

    public GameObject[] enemy;

    public int enemiesCount;

    [SerializeField]
    private float spawnDelay = 5f;

    private Enemy enemyScript;

    private void Start()
    {
        StartCoroutine(SpawnMonster(spawnDelay));
    }

    IEnumerator SpawnMonster(float waitTime)
    {
        while (enemiesCount >= 1)
        {
            var pointSelected = Random.Range(0, spawnPoints.Length);
            var pointToSpawn = spawnPoints[pointSelected].position;
            var homePosition = spawnPoints[pointSelected];

            var randomEnemy = Random.Range(0, enemy.Length);
            Instantiate(enemy[randomEnemy], pointToSpawn, Quaternion.identity);
            enemyScript = enemy[randomEnemy].GetComponent<Enemy>();
            enemyScript.homePos = homePosition;

            enemiesCount--;

            yield return new WaitForSeconds(waitTime);
        }
        Destroy (gameObject);
    }
}
