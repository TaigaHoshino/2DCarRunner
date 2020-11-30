using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelector : MenuCarController
{
    GameObject[] cars;
    int carNumber;
    WheelJoint2D[] wheels;

    public void InitialSetting() {
        cars = new GameObject[2] { GameObject.Find("CarBody"), GameObject.Find("Buggy") };
        carNumber = 0;
        cars[1].SetActive(false);
        //wheels = cars[0].GetComponents<WheelJoint2D>();
        frontWheel = cars[0].GetComponent<WheelJoint2D>();
        //backWheel = wheels[1];
    }

    public void CarSelectLeft()
    {
        carNumber--;
        if(carNumber >= 0)
        {
            cars[carNumber+1].SetActive(false);
            cars[carNumber+1].SetActive(true);
            wheels = cars[carNumber].GetComponents<WheelJoint2D>();
            frontWheel = wheels[0];
            backWheel = wheels[1];
        }
        else
        {
            cars[0].SetActive(false);
            carNumber = 1;
            wheels = cars[carNumber].GetComponents<WheelJoint2D>();
            frontWheel = wheels[0];
            backWheel = wheels[1];

        }
    }

    public void CarSelectRight()
    {
        carNumber++;
        if(carNumber <= 1)
        {
            cars[carNumber].SetActive(false);
            cars[carNumber-1].SetActive(true);
            wheels = cars[carNumber].GetComponents<WheelJoint2D>();
            frontWheel = wheels[0];
            backWheel = wheels[1];
        }
        else
        {
            cars[1].SetActive(false);
            carNumber = 0;
            wheels = cars[carNumber].GetComponents<WheelJoint2D>();
            frontWheel = wheels[0];
            backWheel = wheels[1];
        }
    }
}
