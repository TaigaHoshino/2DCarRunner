using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackgroundController : MonoBehaviour
{
	GameObject car;
    float carPosX;
    float posDistance;
    float backgroundMove;
    float pastPos;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        car = MenuCarController.cars[MenuCarController.carNumber];
        carPosX = car.transform.GetChild(0).position.x;
        posDistance = 0;
        pastPos = car.transform.GetChild(0).position.x;
    }

    // Update is called once per frame
    void Update()
    {
        car = MenuCarController.cars[MenuCarController.carNumber];
        carPosX = car.transform.GetChild(0).position.x;
        posDistance = carPosX - pastPos;
        backgroundMove = posDistance * moveSpeed;

        transform.Translate(posDistance - backgroundMove, 0, 0);
        pastPos = carPosX;
        posDistance = 0;
    }

}
