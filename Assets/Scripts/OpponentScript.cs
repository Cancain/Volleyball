using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentScript : MonoBehaviour {
    private Rigidbody2D controller;
    private Rigidbody2D targetBall;
    private Vector2 targetPos;
    [SerializeField] private readonly float speed = 10f;
    [SerializeField] private readonly float jumpForce = 20f;
    [SerializeField] public GameObject start;
    private bool isActive;
    private bool isGrounded = true;

    public void Activate(Rigidbody2D ball) {
        isActive = true;
        targetBall = ball;
        targetPos = ball.position;

        Debug.Log("opponent active");
    }

    public void Deactivate() {
        isActive = false;
        targetPos = start.transform.position;
        Debug.Log("opponent deactivated");
    }
    public bool IsActive() {
        return isActive;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Ground") {
            isGrounded = true;
        }
    }

    private bool IsWithinRange(float value, float min, float max) {
        return value >= min && value <= max;
    }

    private void ShouldJump() {
        if (IsActive()) {
            Vector2 opponentPos = transform.position;
            Vector2 ballPos = targetPos;

            float xReach = 2f;
            float minXRange = ballPos.x - xReach;
            float maxXRange = ballPos.x + xReach;

            float yReach = 3f;
            float minYRange = ballPos.y - yReach;
            float maxYRange = ballPos.y + yReach;

            if (IsWithinRange(opponentPos.x, minXRange, maxXRange) &&
                IsWithinRange(opponentPos.y, minYRange, maxYRange)) {
                Jump();
            }
        }
    }

    private void Jump() {
        if (isGrounded) {
            isGrounded = false;
            Vector2 movement = controller.velocity;
            movement.y += jumpForce;
            controller.velocity = movement;
        }
    }

    private void FollowBall() {
        //adjustment is to make the opponent try to have the ball slighty in front
        float adjustment = 0.3f;
        Vector2 movement = new Vector2(targetPos.x + adjustment, controller.position.y);
        transform.position = Vector2.MoveTowards(
            transform.position,
            movement,
            speed * Time.deltaTime
            );
    }

    private void UpdateTarget() {
        if (IsActive()) {
            targetPos = targetBall.position;
        }
    }

    private void Update() {
        Debug.Log(isGrounded);
    }

    private void FixedUpdate() {
        UpdateTarget();
        FollowBall();
        ShouldJump();
    }

    private void Start() {
        targetPos = start.transform.position;
        controller = gameObject.GetComponent<Rigidbody2D>();
    }
}
