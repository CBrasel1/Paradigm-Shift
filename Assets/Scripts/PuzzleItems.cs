using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleItems : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.transform.tag == "PuzzleItem") {
            collision.transform.parent.gameObject.SetActive(false);
        }
    }
}
