using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject target;
    [SerializeField] protected float speed;
    Rigidbody2D bulletRB;




    void Start()
    {

        //bullet script, it technically has an indirect subtraction of vectors, applied to the bullet prefab. 
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed; // <-- Normalisation.
        bulletRB.velocity = new Vector2 (moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);

        if (target != null)
        {
            Debug.Log("Error");
        }
    }


    void Update()
    {
        
    }
}
