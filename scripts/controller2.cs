using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class controller2 : MonoBehaviour
{

public WheelCollider[] wheels = new WheelCollider[4];
public float torque = 200;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
    if (Input.GetKey(KeyCode.W)){
        for(int i=0; i<wheels.Length; i++){
            wheels[i].motorTorque = torque;
        }
    }else{
        for(int i=0; i<wheels.Length; i++){
            wheels[i].motorTorque = 0;
        }
    }
        
    }
}
