using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private Vector3 tempPosition;
    private float maxAbsX = 60f;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        tempPosition = transform.position;
        if (player.position.x > 0) {
            tempPosition.x = Mathf.Min(maxAbsX, player.position.x);
        } else {
            tempPosition.x = Mathf.Max(-maxAbsX, player.position.x);
        }
        transform.position = tempPosition;
    }
}
