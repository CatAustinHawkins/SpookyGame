using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(0, 0, -0.01f); //rotate the object in the x

        }
        //when the player presses G
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(-0.01f, 0, 0);
        }
        //when the player presses H
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(0, 0, 0.01f);
        }

        if(Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(0.01f, 0, 0);

        }
    }
}
