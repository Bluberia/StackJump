using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private Spawner[] spawners;
    private int spawnerIndex;
    private Spawner currentSpawner;

    private void Awake() {
        spawners = FindObjectsOfType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (MovingCube.CurrentCube != null)
                MovingCube.CurrentCube.Stop();
            spawnerIndex = spawnerIndex == 0 ? 1 : 0;
            currentSpawner = spawners[spawnerIndex];

            currentSpawner.SpawnCube();
            GameObject.Find("Score Text").GetComponent<ScoreText>().OnCubeSpawned();
        }
    }
}
