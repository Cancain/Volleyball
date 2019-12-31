using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCollider : MonoBehaviour
{
    GameObject player;
    PlayerScript playerScript;
    
    private bool playerGrounded;

    private void checkPlayerGrounded(){
        GameObject player = GameObject.Find("Player");
        PlayerScript playerScript = player.GetComponent<PlayerScript>();
        if(playerGrounded){
            playerScript.SetGrounded(true);
            playerGrounded = false;
        }
    }
    private void Update() {
       checkPlayerGrounded();
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.tag == "Player"){
            playerGrounded = true;
        }
    }
}
