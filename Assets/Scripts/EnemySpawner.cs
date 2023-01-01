using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyPrefabList;

    [SerializeField]
    private Transform leftPos, rightPos;

    private GameObject spawnedEnemy;
    private int randomIndex; // 0 - Ghost, 1 - Zombie 1, 2 - Zombie 2
    private int randomSide; // 0 - left , 1 - right
    
    void Start() {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy() {
        while(true) {
            randomIndex = Random.Range(0, enemyPrefabList.Length);
            randomSide = Random.Range(0, 2);
            Debug.Log("RandomIndex : " + randomIndex + " , RandomSide : " + randomSide);
            // Instantiate the Gameobject
            spawnedEnemy = Instantiate(enemyPrefabList[randomIndex], randomSide == 0 ? leftPos : rightPos);

            // determine the side
            if (randomSide == 0) {
                // left side
                spawnedEnemy.transform.position = new Vector3(leftPos.position.x, leftPos.position.y, 0f);
                spawnedEnemy.GetComponent<SpriteRenderer>().flipX = false;
                spawnedEnemy.GetComponent<EnemyMovement>().speed = Random.Range(4f, 9f);
                Debug.Log("Left Enemy Spawned..");
            } else {
                // right side
                spawnedEnemy.transform.position = new Vector3(rightPos.position.x, rightPos.position.y, 0f);
                spawnedEnemy.GetComponent<SpriteRenderer>().flipX = true;
                spawnedEnemy.GetComponent<EnemyMovement>().speed = -Random.Range(4f, 9f);
                Debug.Log("Right Enemy Spawned...");
            }
            yield return new WaitForSeconds(Random.Range(3f, 7f));
        }
    }
}
