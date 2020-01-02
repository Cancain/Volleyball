using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
    private bool isActive;
    private bool hasScored = false;
    public void SetActive(bool active) {
        isActive = active;
    }
    public bool IsActive() {
        return isActive;
    }

    private bool isOutOfBounds(Collision2D coll) {
        if (coll.collider.tag == "Ground" && !hasScored) {
            hasScored = true;
            return true;
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D coll) {
        if (isOutOfBounds(coll)) {
            Debug.Log("score");
        }
    }

    private void Start() {
        Debug.Log("spawned");
    }

}
