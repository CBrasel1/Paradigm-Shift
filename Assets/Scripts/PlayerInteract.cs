using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.transform.tag == "Item") {
            collision.transform.parent.gameObject.SetActive(false);
        }
    }
}
