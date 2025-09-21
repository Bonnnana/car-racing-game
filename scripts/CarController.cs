using UnityEngine;
using System;
using System.Collections.Generic;

public class CarController : MonoBehaviour
{
    public WheelCollider[] wheels = new WheelCollider[4];
    public int motorTorque = 400;
    public float steeringMax = 30;
    public GameObject[] wheelMesh = new GameObject[4];

    void Start()
    {
    }

    private void FixedUpdate()
    {
        animateWheels();

        // Apply motor torque only to the rear wheels
        if (Input.GetKey(KeyCode.W))
        {
            for (int i = 2; i < wheels.Length; i++)  // Rear wheels (index 2 and 3)
            {
                wheels[i].motorTorque = motorTorque;
            }
        }
        else if (Input.GetKey(KeyCode.S))
            {
                for (int i = 2; i < wheels.Length; i++)  // Rear wheels (index 2 and 3)
                {
                    wheels[i].motorTorque = -motorTorque;  // Reverse movement
                }
            }
        else
            {
                // No input, no torque applied
             for (int i = 2; i < wheels.Length; i++)  // Rear wheels (index 2 and 3)
              {
                 wheels[i].motorTorque = 0;
                }
            }

        // Steering input for front wheels
        if (Input.GetAxis("Horizontal") != 0)
            {
                for (int i = 0; i < 2; i++)  // Front wheels (index 0 and 1)
                {
                    wheels[i].steerAngle = Input.GetAxis("Horizontal") * steeringMax;
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)  // Front wheels (index 0 and 1)
                {
                    wheels[i].steerAngle = 0;
                }
            }
    }

    void animateWheels()
    {
        Vector3 wheelPosition = Vector3.zero;
        Quaternion wheelRotation = Quaternion.identity;

        for (int i = 0; i < 4; i++)
        {
            wheels[i].GetWorldPose(out wheelPosition, out wheelRotation);
            wheelMesh[i].transform.position = wheelPosition;
            wheelMesh[i].transform.rotation = wheelRotation;
        }
    }
}
