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
    private float moveSpeed = 2f;
    
    private void OnEnable() 
    {
        if (LastCube == null)
            LastCube = GameObject.Find("Ground").GetComponent<MovingCube>();
        CurrentCube = this;
        if (randomColor == true)
            GetComponent<Renderer>().material.color = GetRandomColor();
    }

    private Color GetRandomColor()
    {
        return new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
    }

    internal void Stop() {
        moveSpeed = 0;
        float pos = transform.position.x - LastCube.transform.position.x;
        //Debug.Log(pos);
        LastCube = this;
    }

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
