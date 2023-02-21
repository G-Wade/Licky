using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovementController : MonoBehaviour {
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpSpeed;
    private Rigidbody2D rb2D;
    private Vector2 velocity = new Vector2();
    private float currentSpeed = 0;

    private void Awake() {
        Debug.Log("Awake Player");
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        SetWalkOnInput();
        SetJumpOnInput();
    }

    private void SetWalkOnInput() {
        velocity = rb2D.velocity;
        currentSpeed = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            currentSpeed += walkSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            currentSpeed -= walkSpeed;
        }

        velocity.x = currentSpeed;
        rb2D.velocity = velocity;
    }

    private void SetJumpOnInput() {
        velocity = rb2D.velocity;

        if(Input.GetKeyDown(KeyCode.W)) {
            velocity.y = jumpSpeed;
        }

        rb2D.velocity = velocity;
    }
}
