using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject car;
    static bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        this.car = CarController.cars[CarController.selectedCarNumber];
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 carPos = this.car.transform.GetChild(0).position;
        if (!isGameOver)
        {
            transform.position = new Vector3(carPos.x + 3, transform.position.y, transform.position.z);
        }
    }

    public static void GameOverFlag()
    {
        isGameOver = true;
    }
}
