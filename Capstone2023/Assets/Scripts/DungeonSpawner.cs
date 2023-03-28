using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSpawner : MonoBehaviour
{
    //You may as well use transform here rather than gameobjects
    public Transform[] spawnPoints;
 
    public int enemiesCount;
 
    public GameObject enemy;
 
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
 
            Instantiate(enemy, pointToSpawn, Quaternion.identity);
            enemyScript = FindObjectOfType<Enemy>();
            enemyScript.homePos = homePosition;

 
            enemiesCount--;
 
            yield return new WaitForSeconds(waitTime);
        }
        Destroy(gameObject);
    }
}
