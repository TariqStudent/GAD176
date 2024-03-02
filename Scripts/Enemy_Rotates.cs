using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Enemy_Rotates : Base_Enemy
{
    [SerializeField] protected float distance;
    [SerializeField] protected float distancebetween;

    void Update()
    {
        // code for vector rotationvector rotations and angles implimented.
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.forward - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

//an if statment that if the distance between is higher than distance it self, the character will start rotating. and thats by using quaternion.euler code. 
        if (distance < distancebetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle); // <-- the enemy will rotate
        }


    }
}
