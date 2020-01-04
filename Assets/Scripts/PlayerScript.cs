using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    private Rigidbody2D controller;
    [SerializeField] private readonly float speed = 1f;
    [SerializeField] private readonly float jumpForce = 20f;

    private bool isGrounded = true;

    private void Start() {
        controller = GetComponent<Rigidbody2D>();
        controller.drag = 2;
    }

    private void CheckPlayerHorizontalMovement() {
        Vector2 movement = controller.velocity;
        if (Input.GetKey(KeyCode.RightArrow)) {
            movement.x += speed;
            controller.velocity = movement;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            movement.x -= speed;
            controller.velocity = movement;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Ground") {
            isGrounded = true;
        }
    }

    private void Jump() {
        isGrounded = false;
        Vector2 movement = controller.velocity;
        movement.y += jumpForce;
        controller.velocity = movement;
    }

    private void CheckPlayerJump() {
        if (isGrounded) {
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                Jump();
            }
        }
    }
    private void FixedUpdate() {
        CheckPlayerHorizontalMovement();
        CheckPlayerJump();
    }

}
