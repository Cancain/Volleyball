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

    private void SpawnBall() {
        Instantiate(ball);
    }

    private void CheckPlayerInput() {
        if (Input.GetKeyDown(KeyCode.M)) {
            SpawnBall();
        }
    }

    private void Update() {
        if (active) {
            CheckPlayerInput();
        }
    }
}
