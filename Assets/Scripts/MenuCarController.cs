using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCarController : MonoBehaviour
{

    //public WheelJoint2D BackWheel;
    //public WheelJoint2D FrontWheel;

    public WheelJoint2D backWheel;
    public WheelJoint2D frontWheel;
    public GameObject mainCamera;
    public static GameObject[] cars;
    public static int carNumber;
    WheelJoint2D[] wheels;

    public static float carPosX;
    Button timeAttackModeButton;
    Button justStopModeButton;

    JointMotor2D motorFront;
    JointMotor2D motorBack;

    float torque = 10000f;

    float speed = 2000f;
    // Start is called before the first frame update
    void Start()
    {

        cars = new GameObject[6] { GameObject.Find("2DCar"),
            GameObject.Find("MiniCar"),
            GameObject.Find("Buggy"),
            GameObject.Find("Truck"),
            GameObject.Find("SportsCar"),
            GameObject.Find("F1Car")};
        int i;
        for (i = 0; i < cars.Length; i++)
        {
            cars[i].SetActive(false);
        }
        Text unlockText = GameObject.Find("unlockConditionText").GetComponent<Text>();
        unlockText.text = "やじるしでクルマを選択";
        justStopModeButton = GameObject.Find("JustStopModeButton").GetComponent<Button>();
        timeAttackModeButton = GameObject.Find("TimeAttackModeButton").GetComponent<Button>();
        carNumber = CarController.selectedCarNumber;
        justStopModeButton.interactable = true;
        timeAttackModeButton.interactable = true;
        cars[carNumber].SetActive(true);
        wheels = cars[carNumber].GetComponentsInChildren<WheelJoint2D>();
        frontWheel = wheels[0];
        backWheel = wheels[1];
        carPosX = cars[carNumber].transform.GetChild(0).position.x;
        RewardLock();
        //posDistance = 0;
    }


    // Update is called once per frame
    void Update()
    {
        carPosX = cars[carNumber].transform.GetChild(0).position.x;
        //allCars.transform.position = new Vector3(cars[carNumber].transform.position.x,
        //    transform.position.y, transform.position.z);

        //runningDistance = cars[carNumber].transform.GetChild(0).position.x;

        motorFront.motorSpeed = speed * -1;
        motorFront.maxMotorTorque = torque;
        frontWheel.motor = motorFront;

        motorBack.motorSpeed = speed * -1;
        motorBack.maxMotorTorque = torque;
        backWheel.motor = motorBack;

        //mainCamera.transform.position = new Vector3(cars[carNumber].transform.GetChild(0).position.x,
        //        mainCamera.transform.position.y, mainCamera.transform.position.z);

        //posDistance = 0;
        //pastPos = cars[carNumber].transform.GetChild(0).position.x;
    }

    public void CarSelectLeftButton()
    {
        carNumber--;
        if (carNumber >= 0)
        {
            cars[carNumber + 1].SetActive(false);
            cars[carNumber].SetActive(true);
            wheels = cars[carNumber].GetComponentsInChildren<WheelJoint2D>();
            frontWheel = wheels[0];
            backWheel = wheels[1];
        }
        else
        {
            cars[0].SetActive(false);
            carNumber = cars.Length - 1;
            cars[carNumber].SetActive(true);
            wheels = cars[carNumber].GetComponentsInChildren<WheelJoint2D>();
            frontWheel = wheels[0];
            backWheel = wheels[1];

        }
        if (cars[carNumber].tag == "Locked")
        {
            justStopModeButton.interactable = false;
            timeAttackModeButton.interactable = false;
        }
        else
        {
            justStopModeButton.interactable = true;
            timeAttackModeButton.interactable = true;
        }
        UnlockConditionText();
        cars[carNumber].transform.GetChild(0).position = new Vector3(carPosX,
            transform.position.y + 1f,
            transform.position.z);
        cars[carNumber].transform.GetChild(1).position = new Vector3(carPosX,
            transform.position.y,
            transform.position.z);
        cars[carNumber].transform.GetChild(2).position = new Vector3(carPosX,
            transform.position.y,
            transform.position.z);

    }

    public void CarSelectRightButton()
    {
        carNumber++;
        if (carNumber < cars.Length)
        {
            cars[carNumber].SetActive(true);
            cars[carNumber - 1].SetActive(false);
            wheels = cars[carNumber].GetComponentsInChildren<WheelJoint2D>();
            frontWheel = wheels[0];
            backWheel = wheels[1];
        }
        else
        {
            cars[cars.Length-1].SetActive(false);
            carNumber = 0;
            cars[carNumber].SetActive(true);
            wheels = cars[carNumber].GetComponentsInChildren<WheelJoint2D>();
            frontWheel = wheels[0];
            backWheel = wheels[1];
        }
        UnlockConditionText();
        cars[carNumber].transform.GetChild(0).position = new Vector3(carPosX,
            transform.position.y + 1f,
            transform.position.z);
        cars[carNumber].transform.GetChild(1).position = new Vector3(carPosX,
            transform.position.y,
            transform.position.z);
        cars[carNumber].transform.GetChild(2).position = new Vector3(carPosX,
            transform.position.y,
            transform.position.z);
    }

    public void RewardLock()
    {
        RewardCar rewards = new RewardCar();
        rewards = rewards.LoadRewards(); ;
        if (rewards.miniCarKey < MenuDirector.miniCarUnlockQuota)
        {
            Renderer[] carColor = cars[1].GetComponentsInChildren<Renderer>();
            int i;
            for (i = 0; i < carColor.Length; i++)
            {
                carColor[i].material.color = Color.black;
            }
            
        }
        else
        {
            cars[1].tag = "Unlocked";
        }

        if (rewards.buggyKey < MenuDirector.buggyUnlockQuota)
        {
            Renderer[] carColor = cars[2].GetComponentsInChildren<Renderer>();
            int i;
            for (i = 0; i < carColor.Length; i++)
            {
                carColor[i].material.color = Color.black;
            }
        }
        else
        {
            cars[2].tag = "Unlocked";
        }

        if (rewards.truckKey < MenuDirector.truckUnlockQuota)
        {
            Renderer[] carColor = cars[3].GetComponentsInChildren<Renderer>();
            int i;
            for (i = 0; i < carColor.Length; i++)
            {
                carColor[i].material.color = Color.black;
            }
        }
        else
        {
            cars[3].tag = "Unlocked";
        }

        if(rewards.sportsCarKey < MenuDirector.sportsCarUnlockQuota)
        {
            Renderer[] carColor = cars[4].GetComponentsInChildren<Renderer>();
            int i;
            for (i = 0; i < carColor.Length; i++)
            {
                carColor[i].material.color = Color.black;
            }
        }
        else
        {
            cars[4].tag = "Unlocked";
        }

        if (rewards.f1CarKey < MenuDirector.f1CarUnlockQuota)
        {
            Renderer[] carColor = cars[5].GetComponentsInChildren<Renderer>();
            int i;
            for (i = 0; i < carColor.Length; i++)
            {
                carColor[i].material.color = Color.black;
            }
        }
        else
        {
            cars[5].tag = "Unlocked";
        }
    }

    public void UnlockConditionText()
    {
        Text unlockText = GameObject.Find("unlockConditionText").GetComponent<Text>();
        if (cars[carNumber].tag == "Locked")
        {
            RewardCar rewards = new RewardCar();
            rewards = rewards.LoadRewards();
            justStopModeButton.interactable = false;
            timeAttackModeButton.interactable = false;
            switch (carNumber)
            {
                case 1:
                    unlockText.text = "アンロック条件：ゲームを" + MenuDirector.miniCarUnlockQuota + "回遊ぶ\n"
                        + "残り：" + (MenuDirector.miniCarUnlockQuota - rewards.miniCarKey) + "回";
                    break;
                case 2:
                    unlockText.text = "アンロック条件：ジャストストップモードで\n+-30m以内に停車を" + MenuDirector.buggyUnlockQuota + "回達成する\n"
                        + "残り：" + (MenuDirector.buggyUnlockQuota - rewards.buggyKey) + "回";
                    break;
                case 3:
                    unlockText.text = "アンロック条件：ジャストストップモードで\n+-15m以内に停車を" + MenuDirector.truckUnlockQuota + "回達成する\n"
                        + "残り：" + (MenuDirector.truckUnlockQuota - rewards.truckKey) + "回";
                    break;
                case 4:
                    unlockText.text = "アンロック条件：タイムアタックモードで\n600m以上の走行を" + MenuDirector.sportsCarUnlockQuota + "回達成する\n"
                       + "残り：" + (MenuDirector.sportsCarUnlockQuota - rewards.sportsCarKey) + "回";
                    break;
                case 5:
                    unlockText.text = "アンロック条件：タイムアタックモードで\n800m以上の走行を" + MenuDirector.f1CarUnlockQuota + "回達成する\n"
                       + "残り：" + (MenuDirector.f1CarUnlockQuota - rewards.f1CarKey) + "回";
                    break;

            }
        }
        else
        {
            unlockText.text = "";
            justStopModeButton.interactable = true;
            timeAttackModeButton.interactable = true;
        }
    }
}
