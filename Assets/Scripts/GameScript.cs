using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {
    [SerializeField] private GameObject ball;
    private bool hasBall;
    private bool isActive;
    public void SetActive(bool active) {
        isActive = active;
    }
    public bool IsActive() {
        return isActive;
    }

    private void spawnBall() {
        Instantiate(ball);
    }

    private void checkBall() {
        if (isActive && !hasBall) {
            spawnBall();
            hasBall = true;
        }
    }

    private void Start() {
        SetActive(true);
    }

    private void FixedUpdate() {
        checkBall();
    }
}
