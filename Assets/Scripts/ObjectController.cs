using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectController : MonoBehaviour
{
    GameObject car;
    static bool isGameOver;
    bool isGameScene;
    // Start is called before the first frame update
    void Start()
    {
        isGameScene = false;
        if(SceneManager.GetActiveScene().name == "GamePlayScene")
        {
            car = CarController.cars[CarController.selectedCarNumber];
            isGameScene = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            if (isGameScene)
            {
                if (transform.position.x - car.transform.GetChild(0).position.x < -13)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                if (transform.position.x - MenuCarController.carPosX < -13)
                {
                    Destroy(gameObject);
                }
            }
            
        }
    }

    public static void GameOverFlag(bool boolean)
    {
        if (boolean)
        {
            isGameOver = true;
        }
        else
        {
            isGameOver = false;
        }
    }

}
