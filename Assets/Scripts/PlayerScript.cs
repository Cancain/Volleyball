using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D controller;
    [SerializeField] private readonly float speed = 15f;
    [SerializeField] private readonly float jumpForce = 7f;

    private bool grounded = true;
    private bool isJumping = false;
    public void SetGrounded(bool ground){
        grounded = ground;
        isJumping = false;
    }
    public bool IsGrounded(){
        return grounded;
    }

    private void Start() {
        controller = GetComponent<Rigidbody2D>();
    }

    private void CheckPlayerHorizontalMovement() {
        float movementHorizontal = Input.GetAxis("Horizontal");

        if(isJumping){
            movementHorizontal = movementHorizontal / 2;
        }

        Vector2 movement = new Vector2(movementHorizontal, 0);
        controller.AddForce(movement * speed);
    }

    private void CheckPlayerJump(){
        if(IsGrounded()){
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                SetGrounded(false);
                Vector2 movement = new Vector2(0, jumpForce);
                controller.velocity = movement;
                isJumping = true;
            }
        }
    }
    private void FixedUpdate() {
        CheckPlayerHorizontalMovement();
        CheckPlayerJump();
    }

}
