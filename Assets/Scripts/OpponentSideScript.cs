using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentSideScript : MonoBehaviour {
    private OpponentScript opponentScript;
    private bool isActive;
    public void SetActive(bool active) {
        isActive = active;
    }
    public bool IsActive() {
        return isActive;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ball") {
            opponentScript.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Ball") {
            opponentScript.SetActive(false);
        }
    }

    private void Start() {
        opponentScript = gameObject.GetComponentInParent<OpponentScript>();
    }
}
