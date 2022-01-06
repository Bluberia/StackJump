using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Move the camera with the player
public class CameraMove : MonoBehaviour
{
    public GameObject target;
    private float offset; // Keep initial distance between camera and player

    private void Awake()
    {
        // Define the offset
        offset = transform.position.y - target.transform.position.y;
    }

    void Update () {
        // Move camera smoothly to target height
        Vector3 curPos = transform.position;
        curPos.y = target.transform.position.y + offset;
        transform.position = curPos;
    }
}
