using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; //Controls velocity multiplier

    Rigidbody rb; //Tells script there is a rigidbody, we can use variable rb to reference it in further script

    Animator anim; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //rb equals the rigidbody on the player
        anim = GetComponent<Animator>();

    }


    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal"); // d key changes value to 1, a key changes value to -1
        float zMove = Input.GetAxisRaw("Vertical"); // w key changes value to 1, s key changes value to -1

        rb.velocity = new Vector3(xMove, rb.velocity.y, zMove) * speed; // Creates velocity in direction of value equal to keypress (WASD). rb.velocity.y deals with falling + jumping by setting velocity to y. 

        if(Input.GetKey(KeyCode.W)) //moving up
        {
            anim.Play("AndiWalkingDown");
            Debug.Log("Test");
        }

        if(Input.GetKey(KeyCode.A))//moving left
        {
            anim.Play("AndiWalkingLeft");
        }

        if (Input.GetKey(KeyCode.S)) //moving down
        {
            anim.Play("AndiWalkingUp");
        }

        if (Input.GetKey(KeyCode.D))//moving right
        {
            anim.Play("AndiWalkingRight");

        }
    }
}
