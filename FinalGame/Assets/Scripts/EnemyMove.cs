using UnityEngine;
using System.Collections;



public class EnemyMove : MonoBehaviour
{

    public Transform player;
    public static EnemyMove Alive;
    public float moveSpeed;
    public float playerDistance;
    public float rotationDamping;
    public float ChaseDistance;
    public static bool isPlayerAlive = true;
    public int isAlive =1;

    void Start ()
	{
        Alive = this;
	}
	
	void Update()
	{
        print(isAlive);
       // if(isAlive == 1 )  
       if(isPlayerAlive)    // should only run when player is not destoryed 
        {
            playerDistance = Vector3.Distance(player.position, transform.position);

            if (playerDistance < ChaseDistance)
            {
                lookAtPlayer();
                if(playerDistance < ChaseDistance && playerDistance > 4.5f)
                {
                    chase();
                }
                else if (playerDistance <= 4.5f)
                {
                    attack();       // stops chasing and attack
                }
           
            }

        }

        else
        {
            // do something so other enemy will not look for gameobject anymore
        }


        
        
	}

    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
        
    }

    void chase()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void attack()
    {
        
        //RaycastHit hit;
        //if(Physics.Raycast( transform.position, transform.forward, out hit))
        //{
        //    print("in attack function");
        //    if ( hit.collider.gameObject.tag == "Player") // check if object has player tag on it to deduct points
        //    {
        // hit.collider.gameObject.GetComponent<health>().guyHealth -= 2f;
        print(" player health deducted---------");
        health.playerHealth.guyHealth -= .25f;
        
        if(health.playerHealth.guyHealth == 0f)
        {
            isPlayerAlive = false;
        }

        //    }
        //}
    }
}
