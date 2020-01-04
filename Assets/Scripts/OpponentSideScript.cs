using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentSideScript : MonoBehaviour {
    [SerializeField] private GameObject opponent;
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
            opponentScript.Activate(other.GetComponent<Rigidbody2D>());
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Ball") {
            opponentScript.Deactivate();
        }
    }

    private void Start() {
        opponentScript = opponent.GetComponent<OpponentScript>();
    }
}
