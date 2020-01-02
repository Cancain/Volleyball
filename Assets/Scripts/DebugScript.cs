using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour {
    [SerializeField] private GameObject ball;
    [SerializeField] private bool active = false;
    public void SetActive(bool enable) {
        active = enable;
    }
    public bool IsActive() {
        return active;
    }

    private void spawnBall() {
        Instantiate(ball);
    }

    private void checkPlayerInput() {
        if (Input.GetKeyDown(KeyCode.M)) {
            spawnBall();
        }
    }

    private void Update() {
        if (active) {
            checkPlayerInput();
        }
    }
}
