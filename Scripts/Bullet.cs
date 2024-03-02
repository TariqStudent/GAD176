using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
// Added a comment regaring this protected float speed and the rigidboyd2d bulletRB.
    GameObject target;
    [SerializeField] protected float speed;
    Rigidbody2D bulletRB;




    void Start()
    {

        //bullet script, it technically has an indirect subtraction of vectors, applied to the bullet prefab. 
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player"); //all the target will be the player which is the slime.
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed; // <-- Normalisation.
        bulletRB.velocity = new Vector2 (moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);

// check for null if not returns refernece and it will print on console as error.
        if (target != null)
        {
            Debug.Log("Error");
        }
    }


    void Update()
    {
        
    }
}
