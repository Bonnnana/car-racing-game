using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class awakeManager : MonoBehaviour
{

    [Header("Camera")]
    public float lerpTime;
    public GameObject CameraObject;
    public GameObject finalCameraPosition , startCameraPosition;

    [Header("Deafault Canvas")]
    public GameObject DeafaultCanvas;
    public Text DeafaultCanvasCurrency;

    [Header("Vehicle Select Canvas")]
    public GameObject vehicleSelectCanvas;
    public GameObject buyButton;
    public GameObject startButton;
    public vehicleList listOfVehicles;
    public Text currency;
    public Text carInfo;



    public GameObject toRotate;
    [HideInInspector]public float rotateSpeed = 10f;
    [HideInInspector]public int vehiclePointer = 0;
    private bool finalToStart,startToFinal;

    private void Awake() {
        DeafaultCanvas.SetActive(true);
        vehicleSelectCanvas.SetActive(false);

        vehiclePointer = PlayerPrefs.GetInt("pointer");
        GameObject childObject = Instantiate(listOfVehicles.vehicles[vehiclePointer],Vector3.zero,toRotate.transform.rotation) as GameObject;
        childObject.transform.parent = toRotate.transform;
        getCarInfo();
        startButton.SetActive(true);
    }

    private void FixedUpdate() {
        toRotate.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        cameraTranzition();
    }

    public void rightButton(){
        if(vehiclePointer < listOfVehicles.vehicles.Length-1){
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            vehiclePointer++;
            PlayerPrefs.SetInt("pointer",vehiclePointer);
            GameObject childObject = Instantiate(listOfVehicles.vehicles[vehiclePointer],Vector3.zero,toRotate.transform.rotation) as GameObject;
            childObject.transform.parent = toRotate.transform;
            getCarInfo();
        }
    }

    public void leftButton(){
        if(vehiclePointer > 0){
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            vehiclePointer--;
            PlayerPrefs.SetInt("pointer",vehiclePointer);
            GameObject childObject = Instantiate(listOfVehicles.vehicles[vehiclePointer],Vector3.zero,toRotate.transform.rotation) as GameObject;
            childObject.transform.parent = toRotate.transform;
            getCarInfo();
        }
    }

    public void startGameButton(){
        DeafaultCanvas.SetActive(false);
        vehicleSelectCanvas.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }

    public void getCarInfo(){
        carInfo.text = listOfVehicles.vehicles[PlayerPrefs.GetInt("pointer")].GetComponent<controller>().carName.ToString();
    }

    public void DeafaultCanvasStartButton(){
        DeafaultCanvas.SetActive(false);
        vehicleSelectCanvas.SetActive(true);
        startToFinal = true;
        finalToStart = false;
    }

    public void vehicleSelectCanvasStartButton(){
        DeafaultCanvas.SetActive(true);
        vehicleSelectCanvas.SetActive(false);
        finalToStart = true;
        startToFinal = false;

    }

    public void cameraTranzition(){
        if(startToFinal){
            CameraObject.transform.position = Vector3.Lerp(CameraObject.transform.position,finalCameraPosition.transform.position,lerpTime * Time.deltaTime); 
        }
        if(finalToStart){
            CameraObject.transform.position = Vector3.Lerp(CameraObject.transform.position,startCameraPosition.transform.position,lerpTime * Time.deltaTime); 
        }

    }
}
