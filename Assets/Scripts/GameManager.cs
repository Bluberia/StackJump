using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static Spawner[] spawners;
    private static int spawnerIndex;
    private static Spawner currentSpawner;

    private void Awake() {
        spawners = FindObjectsOfType<Spawner>();
        NextCube();
    }

    public static void Restart() {
        MovingCube.RestartCubes();
        SceneManager.LoadScene(0);
    }

    public static void NextCube() {
        if (MovingCube.CurrentCube != null)
            MovingCube.CurrentCube.Stop();
        spawnerIndex = spawnerIndex == 0 ? 1 : 0;
        currentSpawner = spawners[spawnerIndex];

        currentSpawner.SpawnCube();
    }
}
