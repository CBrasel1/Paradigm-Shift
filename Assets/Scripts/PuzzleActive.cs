using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleActive : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.transform.tag == "Puzzle") {
            for(int i = 0; i < collision.transform.childCount; i++) {
                collision.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
