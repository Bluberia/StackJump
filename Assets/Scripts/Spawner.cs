using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private MovingCube cubePrefab;
    [SerializeField]
    private MoveDirection moveDirection;
    
    // Spawn a cube in the game
    public void SpawnCube()
    {
        var cube = Instantiate(cubePrefab);
        
        if (MovingCube.LastCube != null && MovingCube.LastCube.gameObject != GameObject.Find("Ground"))
        {
            cube.transform.position = new Vector3(transform.position.x, MovingCube.LastCube.transform.position.y + cubePrefab.transform.localScale.y, transform.position.z);
        }
        else 
        {
            cube.transform.position = transform.position;
        }

        cube.MoveDirection = moveDirection;
    }

    // Draw Gizmos around the spawner 
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, cubePrefab.transform.localScale);
    }
}
