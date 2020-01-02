using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OponentSideScript : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ball") {
            Debug.Log("ball in opponent side");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Ball") {
            Debug.Log("ball left opponent side");
        }
    }
}
