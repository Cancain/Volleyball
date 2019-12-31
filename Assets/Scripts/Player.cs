using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody2D controller;
    [SerializeField] private readonly float speed = 20f;

    private void Start() {
        controller = GetComponent<Rigidbody2D>();
    }

    private void CheckPlayerHorizontalMovement() {
        float movementHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(movementHorizontal, 0);
        controller.AddForce(movement * speed);
    }
    private void FixedUpdate() {
        CheckPlayerHorizontalMovement();
    }

}
