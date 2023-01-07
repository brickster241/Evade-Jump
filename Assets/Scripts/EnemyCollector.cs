using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollector : MonoBehaviour
{
    private string ENEMY_TAG = "Enemy";
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == ENEMY_TAG) {
            Destroy(other.gameObject);
        }
    }
}
