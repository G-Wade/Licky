using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovementController : MonoBehaviour {
    [SerializeField] private float acceleration;
    [SerializeField] private float maxRunSpeed;
    [SerializeField] private float jumpSpeed;
    private Rigidbody2D rb2D;
    private Vector2 velocity = new Vector2();
    private float currentSpeed = 0;
    private bool grounded = false;

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
        currentSpeed = velocity.x;

        if (Input.GetKey(KeyCode.D) && velocity.x < maxRunSpeed) {
            currentSpeed += acceleration;
        }

        if (Input.GetKey(KeyCode.A) && velocity.x > -maxRunSpeed) {
            currentSpeed -= acceleration;
        }

        velocity.x = currentSpeed;
        rb2D.velocity = velocity;
    }

    private void SetJumpOnInput() {
        velocity = rb2D.velocity;

        if(Input.GetKeyDown(KeyCode.W)) {
            if(grounded) {
                velocity.y = jumpSpeed;
            }
        }

        rb2D.velocity = velocity;
    }

    public void OnGroundedChange(bool onGround) {
        grounded = onGround;
    }
}
