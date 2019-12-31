using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D controller;
    [SerializeField] private readonly float speed = 20f;
    [SerializeField] private readonly float jumpForce = 5f;

    private bool grounded = true;
    public void SetGrounded(bool ground){
        grounded = ground;
    }
    public bool IsGrounded(){
        return grounded;
    }

    private void Start() {
        controller = GetComponent<Rigidbody2D>();
    }

    private void CheckPlayerHorizontalMovement() {
        float movementHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(movementHorizontal, 0);
        controller.AddForce(movement * speed);
    }

    private void CheckPlayerJump(){
        if(IsGrounded()){
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                SetGrounded(false);
                Vector2 movement = new Vector2(0, jumpForce);
                controller.velocity = movement;
            }
        }
    }
    private void FixedUpdate() {
        CheckPlayerHorizontalMovement();
        CheckPlayerJump();
    }

}
