using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D controller;
    [SerializeField] private readonly float speed = 1f;
    [SerializeField] private readonly float jumpForce = 20f;

    private bool grounded = true;
    public void SetGrounded(bool ground){
        grounded = ground;
    }
    public bool IsGrounded(){
        return grounded;
    }

    private void Start() {
        controller = GetComponent<Rigidbody2D>();
        controller.drag = 2;
    }

    private void CheckPlayerHorizontalMovement() {
        Vector2 movement = controller.velocity;
        if(Input.GetKey(KeyCode.RightArrow)){
            movement.x += speed;
            controller.velocity = movement;
        }

        if(Input.GetKey(KeyCode.LeftArrow)){
            movement.x -= speed;
            controller.velocity = movement;
        }
    }

    private void CheckPlayerJump(){
        if(IsGrounded()){
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                SetGrounded(false);
                Vector2 movement = controller.velocity;
                movement.y += jumpForce;
                controller.velocity = movement;
            }
        }
    }
    private void FixedUpdate() {
        CheckPlayerHorizontalMovement();
        CheckPlayerJump();
        Debug.Log(grounded);
    }

}
