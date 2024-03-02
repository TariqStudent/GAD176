using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class charactermovement : MonoBehaviour
{

    [SerializeField] public float speed = 5f;


    void Update()
    {
        Vector3 pos = transform.position;

        //player will move upward...
        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
            print("Currently moving up");
        }


        //player will move downward...
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
            print("Currently moving down");
        }

        //player will move right...
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
            print("Currently moving right");
        }

        //player will move left...
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
            print("Currently moving left");
        }

        transform.position = pos;
    }
}