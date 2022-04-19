using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float distance = 16f;
    public float height = 0.5f;
    
    void LateUpdate()
    {
        Vector3 pos = player.transform.position;
        pos.z -= distance;
        pos.y += height;
        transform.position = pos;
    }
}
