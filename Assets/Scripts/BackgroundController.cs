using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
	GameObject car;
    float posDistance;
    float backgroundMove;
    float pastPos;
    public float moveSpeed;
    static bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
		//car = CarController.cars[CarController.selectedCarNumber];
        posDistance = 0;
        //pastPos = car.transform.GetChild(0).position.x;
        pastPos = -4.55f;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            posDistance = CarController.cars[CarController.selectedCarNumber].transform.GetChild(0).position.x - pastPos;
            backgroundMove = posDistance * moveSpeed;

            transform.Translate(posDistance - backgroundMove, 0, 0);
            pastPos = CarController.cars[CarController.selectedCarNumber].transform.GetChild(0).position.x;
            posDistance = 0;
        }
    }

    public static void GameOverFlag()
    {
            isGameOver = true;
    }
}
