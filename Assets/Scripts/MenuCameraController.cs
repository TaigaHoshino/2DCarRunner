using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(MenuCarController.cars[MenuCarController.carNumber].transform.GetChild(0).position.x,
            transform.position.y, transform.position.z);
    }

}
