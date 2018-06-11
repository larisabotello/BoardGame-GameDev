using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    private Vector3 velocity = Vector3.zero;

    private  Rigidbody rb;


	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	

    // fixed update loop to control variables ... gets the movement vecotrs
    public void Move (Vector3 _velocity)
    {
        velocity = _velocity;
    }

    //run every physics intration ... will be executed once before each phycis step
    void FixedUpdate()
    {
        PerformMovement();
    }

    void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            // does all the physics check without the add force
            // This performs the movement..
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
   
        }
    }

	void Update ()
    {
		
	}
}
