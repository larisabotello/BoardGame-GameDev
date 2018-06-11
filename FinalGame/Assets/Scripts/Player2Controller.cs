using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]

public class Player2Controller : MonoBehaviour
{

    [SerializeField]
    private float speed = 5f;
    public float RotateSpeed = 100f;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {

        //calculate movement velocity as a 3D vector

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);


        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical2");




        // Below is for moving along x axis instead of rotations
        //Vector3 _movHorizontal = transform.right * 0; // (move,0,0)
        Vector3 _movVertical = transform.forward * _zMov; // (0,0, move)


        // Final movment vector
        Vector3 _velocity = (_movVertical).normalized * speed;

        // Apply movment 
        motor.Move(_velocity);


    }
}
