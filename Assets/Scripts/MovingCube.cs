using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    public static MovingCube CurrentCube { get; private set; }
    public static MovingCube LastCube { get; private set; }
    public MoveDirection MoveDirection { get; set; }

    public bool randomColor = true;

    [SerializeField]
    private float minimumSpeed = 1f;
    [SerializeField]
    private float maximumSpeed = 5f;
    private float moveSpeed;

    private void Start() {
        moveSpeed = Random.Range(minimumSpeed, maximumSpeed);    
    }

    private void OnEnable() 
    {
        if (LastCube == null)
            LastCube = GameObject.Find("Ground").GetComponent<MovingCube>();
        CurrentCube = this;
        if (randomColor == true)
            GetComponent<Renderer>().material.color = GetRandomColor();
    }

    // Give a random color to the cubes
    private Color GetRandomColor()
    {
        return new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
    }

    internal void Stop() {
        moveSpeed = 0f;
        LastCube = this;
    }

    // Refresh the data for the cubes
    public static void RestartCubes() {
        CurrentCube = null;
        LastCube = null;
    }

    // Update is called once per frame
    private void Update()
    {
        if (MoveDirection == MoveDirection.R) {
            if (transform.position.x < 0)
                transform.position += transform.right * Time.deltaTime * moveSpeed;
        }
        if (MoveDirection == MoveDirection.L) {
            if (transform.position.x > 0)
                transform.position -= transform.right * Time.deltaTime * moveSpeed;
        }
    }
}
