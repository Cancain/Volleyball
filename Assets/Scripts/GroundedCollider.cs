using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll) {
        Debug.Log(coll.tag == "Player");
    }
}
