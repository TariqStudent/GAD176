using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Enemy_Ranged : Base_Enemy // <-- polymorphism and inheritance from the base enemy, same movement artibutes.
{

//these data will be able to manage the shooting range and fire rate
    public float shootingrange;
    public GameObject bullet;
    [Serialized field] public GameObject bulletParent;
    private float NextFireTime;
    private float firerate = 1f; //

    public override void Attack()
    {
        //overriding the attack method that was used in the Base_Enemy script, with a new functionality.
        base.Attack(); //Calling the base implementation.
        Debug.Log("ranged enemy is attacking!");
    }


    void Start()
    {
        //The ranged enemy inherited this from the Base enemy.
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

 
    void Update()
    {
        //ranged enemy inherited movement from the base enemy.
        float distancefromplayer = Vector2.Distance(player.position, transform.position);

        if (distancefromplayer < lineofsite && distancefromplayer > shootingrange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            Debug.Log("The Ranged enemy will attack you!");
        }
        else if (distancefromplayer <= shootingrange && NextFireTime < Time.time) // <-- managing firerate.
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            NextFireTime = Time.time + firerate;
        }

    }

    private void OnDrawGizmosSelected()
    {
        //ranged enemy will be using green colored line of site instead of red, as it has inherted from the base enemy.
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineofsite);
        Gizmos.DrawWireSphere(transform.position, shootingrange);
    }

}
