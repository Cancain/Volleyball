using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentScript : MonoBehaviour {
    [SerializeField] private readonly float speed = 2f;
    [SerializeField] private readonly float jumpForce = 20f;

    private Rigidbody2D controller;

    private Rigidbody2D targetBall;
    private Vector2 targetPos;

    [SerializeField] public GameObject start;
    private bool isActive;

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

    private bool IsWithinRange(float value, float min, float max) {
        return value >= min && value <= max;
    }

    private void ShouldJump() {
        if (IsActive()) {
            float opponentXPos = transform.position.x;
            float ballXPos = targetPos.x;
            float reach = 0.5f;
            float minRange = ballXPos - reach;
            float maxRange = ballXPos + reach;

            if (IsWithinRange(opponentXPos, minRange, maxRange)) {
                Jump();
            }
        }
    }

    private void Jump() {
        Vector2 movement = controller.velocity;
        movement.y += jumpForce;
        controller.velocity = movement;
    }

    private void FollowBall() {
        Vector2 movement = new Vector2(targetPos.x, controller.position.y);
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
