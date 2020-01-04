using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {
    [SerializeField] public GameObject ball;
    private bool hasBall;
    private bool isActive;
    public void SetActive(bool active) {
        isActive = active;
    }
    public bool IsActive() {
        return isActive;
    }

    private void SpawnBall() {
        Instantiate(ball);
    }

    private void CheckBall() {
        if (isActive && !hasBall) {
            SpawnBall();
            hasBall = true;
        }
    }

    private void Start() {
        SetActive(true);
    }

    private void FixedUpdate() {
        CheckBall();
    }
}
