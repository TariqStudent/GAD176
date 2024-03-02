using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

//this script follow single repoinsibilty princple as this base enemy is inherited several times thorughout the other scripts.
//and its only function is make the enemy follow the player.
public class Base_Enemy : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float lineofsite;
    [SerializeField] protected Transform player;

    public virtual void Attack()
    {
        //Defining a virtual method for polymorphism and override.
        Debug.Log("Enemy Attacks");
    }

    void Start()
    {
        //added a tag to the player
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //checking for null
        if (player == null)
        {
            Debug.Log("Error");
        }
    }


    void Update()
    {
        //addition of vectors to make the enemy follow the player, once it follows the player, the console will print the bellow massege
        float distancefromplayer = Vector2.Distance(player.position, transform.position);
        if(distancefromplayer < lineofsite)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            Debug.Log("The Melee enemy is chasing you!");
        }

   
    }

    //created a red line of site , once the player gets near the enemy in certain distance, the enemy starts following the player.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineofsite);
    }

}

