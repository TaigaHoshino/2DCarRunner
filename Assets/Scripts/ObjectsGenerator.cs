using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsGenerator : MonoBehaviour
{
    public GameObject asphaltTile;
    public GameObject constructedAsphaltTile;
    public GameObject snowTile;
    public GameObject soilTile;
	public GameObject house;
	public GameObject house2;
	public GameObject house3;
	public GameObject house4;
	public GameObject house5;
	public GameObject house6;
	public GameObject house7;
    public GameObject tree;
    public GameObject tree2;
    public GameObject tree3;
    public GameObject forgroundTree;
    public GameObject forgroundTree2;
    public GameObject forgroundTree3;
    public GameObject snowman;
    public GameObject snowman2;
    public GameObject snowmanCouple;
    public GameObject shovel;
    public GameObject jumpFloor;
    public GameObject constructDirector;
    public GameObject rammer;
    public GameObject sequrity;
    GameObject stopLine;


	GameObject car;
    float tilePastPos;
    float tilePosDistance;
	float objectPastPos;
	float objectPosDistance;
    float stagePastPos;
    float stagePosDistance;
    float obstaclePastPos;
    float obstaclePosDistance;
    int obstacleInterval;
    int objectInterval;
    bool isObstacleAppearing = false;
    int stage;
    int stageChangeInterval;
    int counter = 0;
    float carPosY;
    float carPosX;

    // Start is called before the first frame update
    void Start()
    {
        car = CarController.cars[CarController.selectedCarNumber];
        carPosX = this.car.transform.GetChild(0).position.x;
        carPosY = car.transform.position.y;
        tilePastPos = carPosX;
        tilePosDistance = 0;
        objectInterval = Random.Range(10, 50);
        objectPastPos = carPosX;
        objectPosDistance = 0;
        obstacleInterval = Random.Range(80, 150);
        obstaclePastPos = carPosX;
        obstaclePosDistance = 0;
        stagePastPos = carPosX;
        stagePosDistance = 0;
        stage = Random.Range(1, 4);
        stageChangeInterval = Random.Range(150, 300);

        int i;
        for (i = 0; i < 30; i++)
        {
            GameObject set = Instantiate(asphaltTile) as GameObject;
            set.transform.position = new Vector3((int)carPosX - 7 + i,
                                                 carPosY - 2, 0);
        }

        stopLine = GameObject.Find("StopLine");

        int direction = Random.Range(500, 700);
        stopLine.transform.Translate(direction, 0, 0);

    }

    private void Update()
    {
        carPosX = this.car.transform.GetChild(0).position.x;

        tilePosDistance = carPosX - tilePastPos;
		if (tilePosDistance > 0.8f)
		{
			CreateTiles();

			tilePosDistance = 0;
			tilePastPos = carPosX;
		}

		objectPosDistance = carPosX - objectPastPos;
        if(objectPosDistance > objectInterval)
		{

			CreateObjects();
			objectPosDistance = 0;
			objectPastPos = carPosX;
		}

        obstaclePosDistance = carPosX - obstaclePastPos;
        if(obstaclePosDistance > obstacleInterval)
        {
            if(stage == 1)
            {
                isObstacleAppearing = true;
            }
            CreateObstacles();
            obstaclePosDistance = 0;
            obstaclePastPos = carPosX;
        }

        stagePosDistance = carPosX - stagePastPos;
        if(stagePosDistance > stageChangeInterval)
        {
            stage = Random.Range(1, 4);
            stagePosDistance = 0;
            stagePastPos = carPosX;

        }


	}

    private void CreateTiles()
	{
        GameObject set;
        switch (stage)
        {
            case 1:
                if (!isObstacleAppearing)
                {
                    set = Instantiate(asphaltTile) as GameObject;
                    set.transform.position = new Vector3((int)carPosX + 20,
                                                     carPosY - 2, 0);
                    set = Instantiate(asphaltTile) as GameObject;
                    set.transform.position = new Vector3((int)carPosX + 21,
                                                     carPosY - 2, 0);
                    set = Instantiate(asphaltTile) as GameObject;
                    set.transform.position = new Vector3((int)carPosX + 22,
                                                     carPosY - 2, 0);
                }
                else
                {
                    set = Instantiate(constructedAsphaltTile) as GameObject;
                    set.transform.position = new Vector3((int)carPosX + 20,
                                                     carPosY - 2, 0);
                    set = Instantiate(constructedAsphaltTile) as GameObject;
                    set.transform.position = new Vector3((int)carPosX + 21,
                                                     carPosY - 2, 0);
                    set = Instantiate(constructedAsphaltTile) as GameObject;
                    set.transform.position = new Vector3((int)carPosX + 22,
                                                     carPosY - 2, 0);
                    counter++;
                    if (counter > 20)
                    {
                        isObstacleAppearing = false;
                        counter = 0;
                    }
                }
                
                break;
            case 2:
                set = Instantiate(snowTile) as GameObject;
                set.transform.position = new Vector3((int)carPosX + 20,
                                                 carPosY - 2, 0);
                set = Instantiate(snowTile) as GameObject;
                set.transform.position = new Vector3((int)carPosX + 21,
                                                 carPosY - 2, 0);
                set = Instantiate(snowTile) as GameObject;
                set.transform.position = new Vector3((int)carPosX + 22,
                                                 carPosY - 2, 0);
                break;
            case 3:
                set = Instantiate(soilTile) as GameObject;
                set.transform.position = new Vector3((int)carPosX + 20,
                                                 carPosY - 1.9f, 0);
                set = Instantiate(soilTile) as GameObject;
                set.transform.position = new Vector3((int)carPosX + 21,
                                                 carPosY - 1.9f, 0);
                set = Instantiate(soilTile) as GameObject;
                set.transform.position = new Vector3((int)carPosX + 22,
                                                 carPosY - 1.9f, 0);
                break;
        }
        
	}

    public void CreateObstacles()
    {
        GameObject set;
        if(stage == 1)
        {
            set = Instantiate(sequrity) as GameObject;
            set.transform.position = new Vector3((int)carPosX + 18,
                                             carPosY +0.1f, 0);

            set = Instantiate(constructDirector) as GameObject;
            set.transform.position = new Vector3((int)carPosX + 28,
                                             carPosY - 0.1f, 0);

            set = Instantiate(rammer) as GameObject;
            set.transform.position = new Vector3((int)carPosX + 35,
                                             carPosY - 0.1f, 0);
        }
        if(stage == 2)
        {
            set = Instantiate(jumpFloor) as GameObject;
            set.transform.position = new Vector3((int)carPosX + 20,
                                             carPosY -0.4f, 0);
        }
    }

    public void CreateObjects()
	{
		int dice;
        GameObject set;
        if (stage < 3)
        {
            dice = Random.Range(1, 8);
            switch (dice)
            {
                case 1:
                    set = Instantiate(house) as GameObject;
                    set.transform.position = new Vector3((int)carPosX + 20,
                                                     carPosY + 1.3f, 0);
                    break;
                case 2:
                    set = Instantiate(house2) as GameObject;
                    set.transform.position = new Vector3((int)carPosX + 20,
                                                     carPosY + 0.8f, 0);
                    break;
                case 3:
                    set = Instantiate(house3) as GameObject;
                    set.transform.position = new Vector3((int)carPosX + 20,
                                                     carPosY + 0.8f, 0);
                    break;
                case 4:
                    set = Instantiate(house4) as GameObject;
                    set.transform.position = new Vector3((int)carPosX + 20,
                                                     carPosY + 0.8f, 0);
                    break;
                case 5:
                    set = Instantiate(house5) as GameObject;
                    set.transform.position = new Vector3((int)carPosX + 20,
                                                     carPosY + 0.8f, 0);
                    break;
                case 6:
                    set = Instantiate(house6) as GameObject;
                    set.transform.position = new Vector3((int)carPosX + 20,
                                                     carPosY + 0.8f, 0);
                    break;
                case 7:
                    set = Instantiate(house7) as GameObject;
                    set.transform.position = new Vector3((int)carPosX + 20,
                                                     carPosY + 0.8f, 0);
                    break;
            }

            if(stage == 2)
            {
                dice = Random.Range(1, 5);
                float positionDice = Random.Range(-5, 15);
                switch (dice)
                {
                    case 1:
                        set = Instantiate(snowman) as GameObject;
                        set.transform.position = new Vector3((int)carPosX + 20 + positionDice,
                                                         carPosY - 0.05f, 0);
                        break;
                    case 2:
                        set = Instantiate(snowman2) as GameObject;
                        set.transform.position = new Vector3((int)carPosX + 20 + positionDice,
                                                         carPosY - 0.2f, 0);
                        break;
                    case 3:
                        set = Instantiate(snowmanCouple) as GameObject;
                        set.transform.position = new Vector3((int)carPosX + 20 + positionDice,
                                                         carPosY - 0.05f, 0);
                        break;
                    case 4:
                        set = Instantiate(shovel) as GameObject;
                        set.transform.position = new Vector3((int)carPosX + 20 + positionDice,
                                                         carPosY - 0.8f, 0);
                        break;
                }
             }
            objectInterval = Random.Range(10, 50);

        }
        if(stage == 3)
        {
            dice = Random.Range(1, 16);
            switch (dice)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    set = Instantiate(tree) as GameObject;
                    set.transform.position = new Vector3((int)carPosX + 20,
                                                     carPosY + 1.3f, 0);
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                    set = Instantiate(tree2) as GameObject;
                    set.transform.position = new Vector3((int)carPosX + 20,
                                                     carPosY + 1.3f, 0);
                    break;
                case 9:
                case 10:
                case 11:
                case 12:
                    set = Instantiate(tree3) as GameObject;
                    set.transform.position = new Vector3((int)carPosX + 20,
                                                     carPosY + 0.9f, 0);
                    break;
                case 13:
                    set = Instantiate(forgroundTree) as GameObject;
                    set.transform.position = new Vector3((int)carPosX + 20,
                                                     carPosY + 1.3f, 0);
                    break;
                case 14:
                    set = Instantiate(forgroundTree2) as GameObject;
                    set.transform.position = new Vector3((int)carPosX + 20,
                                                     carPosY + 1.3f, 0);
                    break;
                case 15:
                    set = Instantiate(forgroundTree3) as GameObject;
                    set.transform.position = new Vector3((int)carPosX + 20,
                                                     carPosY + 1.3f, 0);
                    break;
            }
            objectInterval = Random.Range(1, 5);
        }
        
	}

}
