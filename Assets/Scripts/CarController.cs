using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public static GameObject[] cars;

    public WheelJoint2D backWheel;
    public WheelJoint2D frontWheel;
    WheelJoint2D[] wheels;
    public static int selectedCarNumber;
    Rigidbody2D carBody;

	public JointMotor2D motorFront;
	public JointMotor2D motorBack;
    float torque;
    float carRotationSpeed;
    public float pastPosition;
    public float length = 0;
    bool isAcceleratorButtonDown;
    bool isBrakeButtonDown;
    static bool isAcceleratorButtonPushed;
    float time;
    float threshold = 0.2f;
    static bool isGameOver;
    static bool isGameStart;
    int key;
    static int gameMode;
    static AudioSource motorAudio;

    public float speed = 0;
    float carSpeed;
	// Start is called before the first frame update
	void Start()
    {
        cars = new GameObject[6] { GameObject.Find("2DCar"),
            GameObject.Find("MiniCar"),
            GameObject.Find("Buggy"),
            GameObject.Find("Truck"),
            GameObject.Find("SportsCar"),
            GameObject.Find("F1Car")};
        selectedCarNumber = MenuCarController.carNumber;
        int i;
        for (i = 0; i < cars.Length; i++)
        {
            cars[i].SetActive(false);
        }
        carSpeed = 1;
        if (selectedCarNumber == 4)
        {
            carSpeed = 1.2f;
        }
        if (selectedCarNumber == 5)
        {
            carSpeed = 1.3f;
        }
        carBody = cars[selectedCarNumber].GetComponentInChildren<Rigidbody2D>();
        carRotationSpeed = 30;
        torque = 10000;
        cars[selectedCarNumber].SetActive(true);
        wheels = cars[selectedCarNumber].GetComponentsInChildren<WheelJoint2D>();
        frontWheel = wheels[0];
        backWheel = wheels[1];
        isGameOver = true;
        isGameStart = false;
        isAcceleratorButtonPushed = false;
        pastPosition = transform.position.x;
        motorAudio = gameObject.GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if(gameMode == 1)
        {
            JustStopMode();
        }
        else
        {
            timeAttackMode();
        }
    }

    public void JustStopMode()
    {

        if (!isGameOver)
        {
            if ((Input.GetKey(KeyCode.Space) || isAcceleratorButtonDown) && !isAcceleratorButtonPushed)
            {
                if (speed < 3000 * carSpeed)
                {
                    speed += 400f * Time.deltaTime * carSpeed;
                    motorFront.motorSpeed = speed * -1;
                    motorFront.maxMotorTorque = torque;
                    frontWheel.motor = motorFront;

                    motorBack.motorSpeed = speed * -1;
                    motorBack.maxMotorTorque = torque;
                    backWheel.motor = motorBack;
                }
            }
            else
            {
                if (speed > 0)
                {
                    speed -= 250f * Time.deltaTime * carSpeed;
                    motorFront.motorSpeed = speed * -1;
                    motorFront.maxMotorTorque = torque;
                    frontWheel.motor = motorFront;

                    motorBack.motorSpeed = speed * -1;
                    motorBack.maxMotorTorque = torque;
                    backWheel.motor = motorBack;
                }
            }

            if (Input.GetKey(KeyCode.RightShift) || isBrakeButtonDown)
            {
                if (speed > 0)
                {
                    speed -= 800f * Time.deltaTime;
                    motorFront.motorSpeed = speed * -1;
                    motorFront.maxMotorTorque = torque;
                    frontWheel.motor = motorFront;

                    motorBack.motorSpeed = speed * -1;
                    motorBack.maxMotorTorque = torque;
                    backWheel.motor = motorBack;
                }
                else
                {
                    speed = 0;
                    motorFront.motorSpeed = speed * -1;
                    motorFront.maxMotorTorque = torque;
                    frontWheel.motor = motorFront;

                    motorBack.motorSpeed = speed * -1;
                    motorBack.maxMotorTorque = torque;
                    backWheel.motor = motorBack;
                }
            }

            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                carBody.AddTorque(carRotationSpeed * Input.GetAxisRaw("Horizontal") * -1);
            }
            key = 0;
            if (Input.acceleration.x < -this.threshold) key = -1;
            if (this.threshold < Input.acceleration.x) key = 1;
            carBody.AddTorque(carRotationSpeed * key * -1);

            motorAudio.pitch = 0.7f + speed * 0.0003f;
        }
        else
        {
            speed = 0;
            motorFront.motorSpeed = speed * -1;
            motorFront.maxMotorTorque = torque;
            frontWheel.motor = motorFront;

            motorBack.motorSpeed = speed * -1;
            motorBack.maxMotorTorque = torque;
            backWheel.motor = motorBack;
        }

        length = cars[selectedCarNumber].transform.GetChild(0).position.x - pastPosition;

        if (isAcceleratorButtonPushed && length < 0.01f)
        {
            time += Time.deltaTime;
            if (time > 2f)
            {
                GameDirector.GameOverFlag();
            }
        }
        else
        {
            time = 0;
            length = 0;
            pastPosition = cars[selectedCarNumber].transform.GetChild(0).position.x;
        }
    }

    public void timeAttackMode()
    {

        if (!isGameOver)
        {
            if (Input.GetKey(KeyCode.Space) || isAcceleratorButtonDown)
            {
                if (speed < 5000 * carSpeed)
                {
                    speed += 400f * Time.deltaTime * carSpeed;
                    motorFront.motorSpeed = speed * -1;
                    motorFront.maxMotorTorque = torque;
                    frontWheel.motor = motorFront;

                    motorBack.motorSpeed = speed * -1;
                    motorBack.maxMotorTorque = torque;
                    backWheel.motor = motorBack;
                }
            }
            else
            {
                if (speed > 0)
                {
                    speed -= 250f * Time.deltaTime;
                    motorFront.motorSpeed = speed * -1;
                    motorFront.maxMotorTorque = torque;
                    frontWheel.motor = motorFront;

                    motorBack.motorSpeed = speed * -1;
                    motorBack.maxMotorTorque = torque;
                    backWheel.motor = motorBack;
                }
            }

            if (Input.GetKey(KeyCode.RightShift) || isBrakeButtonDown)
            {
                if (speed > 0)
                {
                    speed -= 800f * Time.deltaTime;
                    motorFront.motorSpeed = speed * -1;
                    motorFront.maxMotorTorque = torque;
                    frontWheel.motor = motorFront;

                    motorBack.motorSpeed = speed * -1;
                    motorBack.maxMotorTorque = torque;
                    backWheel.motor = motorBack;
                }
                else
                {
                    speed = 0;
                    motorFront.motorSpeed = speed * -1;
                    motorFront.maxMotorTorque = torque;
                    frontWheel.motor = motorFront;

                    motorBack.motorSpeed = speed * -1;
                    motorBack.maxMotorTorque = torque;
                    backWheel.motor = motorBack;
                }
            }
            

            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                carBody.AddTorque(carRotationSpeed * Input.GetAxisRaw("Horizontal") * -1);
            }
            key = 0;
            if (Input.acceleration.x < -this.threshold) key = -1;
            if (this.threshold < Input.acceleration.x) key = 1;
            carBody.AddTorque(carRotationSpeed * key * -1);

            motorAudio.pitch = 0.7f + speed * 0.0003f;
        }
        else
        {
            speed = 0;
            motorFront.motorSpeed = speed * -1;
            motorFront.maxMotorTorque = torque;
            frontWheel.motor = motorFront;

            motorBack.motorSpeed = speed * -1;
            motorBack.maxMotorTorque = torque;
            backWheel.motor = motorBack;
        }
    }

    public void AcceleratorButtonDown()
    {
        isAcceleratorButtonDown = true;
    }

    public void AcceleratorButtonUp()
    {
        isAcceleratorButtonDown = false;
        if (isGameStart)
        {
            isAcceleratorButtonPushed = true;
        }
    }

    public void BrakeButtonDown()
    {
        isBrakeButtonDown = true;
    }

    public void BrakeButtonUp()
    {
        isBrakeButtonDown = false;
    }

    public static void GameOverFlag()
    {
        isGameOver = true;
        motorAudio.Stop();
    }

    public static void GameStartFlag()
    {
        isGameOver = false;
        isAcceleratorButtonPushed = false;
        isGameStart = true;
    }

    public static void GameMode(int i)
    {
        gameMode = i;
    }
}
