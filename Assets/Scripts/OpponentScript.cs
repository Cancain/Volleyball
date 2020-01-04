using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentScript : MonoBehaviour {
    [SerializeField] private readonly float speed = 1f;
    [SerializeField] private readonly float jumpForce = 20f;

    private Rigidbody2D controller;
    private bool isActive;
    public void SetActive(bool active) {
        isActive = active;

        if (active == true) {
            Debug.Log("opponent active");
        } else {
            Debug.Log("opponent inactive");
        }
    }
    public bool IsActive() {
        return isActive;
    }

    public void Jump() {
        Vector2 movement = controller.velocity;
        movement.y = jumpForce;
        controller.velocity = movement;
        Debug.Log("jump");
    }

    private void Start() {
        controller = gameObject.GetComponent<Rigidbody2D>();
    }
}
