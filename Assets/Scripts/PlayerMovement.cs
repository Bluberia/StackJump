using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool onGround;
    private Rigidbody rb;

    [SerializeField] private Canvas canvas;
    [SerializeField] private CameraMove cameraScript;

    // Start is called before the first frame update
    void Start()
    {
        onGround = true;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onGround && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(0f, 5f , 0f);
            onGround = false;
        }
    }

    // Detect the collision with the player
    void OnCollisionEnter(Collision any) 
    {
        Vector3 validDirection = Vector3.up;
        float contactThreshold = 10;

        if (any.gameObject.CompareTag("Ground")) {
            onGround = true;
        }
        if (any.gameObject.CompareTag("Cube")) {
            onGround = true;
            for (int k=0; k < any.contacts.Length; k++) 
            {
                if (Vector3.Angle(any.contacts[k].normal, validDirection) > contactThreshold)
                {
                    // If the player hit the side of the cube, restart the game
                    GameManager.Restart();
                    break;
                } else {
                    // If the player hit the side of the cube, spawn a new cube
                    canvas.GetComponent<ScoreText>().OnCubeDisappear(1);
                    GameManager.NextCube();
                }
            }
        }
    }
}
