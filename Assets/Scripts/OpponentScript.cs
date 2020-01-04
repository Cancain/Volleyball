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

    public void Jump() {
        Vector2 movement = controller.velocity;
        movement.y = jumpForce;
        controller.velocity = movement;
    }

    public void FollowBall() {
        Vector2 movement = new Vector2(targetPos.x, controller.position.y);
        transform.position = Vector2.MoveTowards(
            transform.position,
            movement,
            speed * Time.deltaTime
            );
    }

    public void UpdateTarget() {
        if (IsActive()) {
            targetPos = targetBall.position;
        }
    }

    private void FixedUpdate() {
        FollowBall();
        UpdateTarget();
    }

    private void Start() {
        targetPos = start.transform.position;
        controller = gameObject.GetComponent<Rigidbody2D>();
    }
}
