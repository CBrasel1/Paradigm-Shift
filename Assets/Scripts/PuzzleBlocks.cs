using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBlocks : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    private float gravityScale = 1f;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) {
            if(myRigidBody.gravityScale == 0) {
                myRigidBody.gravityScale = gravityScale;
            } else {
                myRigidBody.gravityScale = 0;
            }
        }
    }
}
