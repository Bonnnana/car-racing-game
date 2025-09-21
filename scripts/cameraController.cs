using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    public GameObject Player;
    public GameObject child;

    public float speed;

    private void Awake () {
        Player = GameObject.FindGameObjectWithTag ("Player");
        child = Player.transform.Find("camera constraint").gameObject;
    }

    private void FixedUpdate () {
        follow ();
    }
    private void follow () {
        //speed = RR.KPH / smothTime;
        gameObject.transform.position = Vector3.Lerp (transform.position, child.transform.position ,  Time.deltaTime * speed);
        gameObject.transform.LookAt (Player.gameObject.transform.position);
    }

}