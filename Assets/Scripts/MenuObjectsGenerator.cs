using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuObjectsGenerator : MonoBehaviour
{
    public GameObject asphaltTile;
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

	GameObject car;
    float tilePastPos;
    float tilePosDistance;
	float objectPastPos;
	float objectPosDistance;
    float stagePastPos;
    float stagePosDistance;
    int objectInterval;
    int stage;
    int stageChangeInterval;
    float carPosX;
    float carPosY;

    // Start is called before the first frame update
    void Start()
    {
        car = MenuCarController.cars[MenuCarController.carNumber];
        carPosX = car.transform.GetChild(0).position.x;
        carPosY = car.transform.GetChild(0).position.y;
        tilePastPos = carPosX;
        tilePosDistance = 0;
        objectInterval = Random.Range(10, 50);
        objectPastPos = carPosX;
        objectPosDistance = 0;
        stagePastPos = carPosX;
        stagePosDistance = 0;
        stage = 1;
        stageChangeInterval = Random.Range(150, 300);

        int i;
        for (i = 0; i < 31; i++)
        {
            GameObject set = Instantiate(asphaltTile) as GameObject;
            set.transform.position = new Vector3((int)carPosX - 10 + i,
                                                 carPosY - 2, 0);
        }

    }

    private void Update()
    {
        car = MenuCarController.cars[MenuCarController.carNumber];
        carPosX = this.car.transform.GetChild(0).position.x;

        tilePosDistance = carPosX - tilePastPos;
		if (tilePosDistance > 0.8)
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
                set = Instantiate(asphaltTile) as GameObject;
                set.transform.position = new Vector3((int)carPosX + 20,
                                                     carPosY - 2, 0);
                set = Instantiate(asphaltTile) as GameObject;
                set.transform.position = new Vector3((int)carPosX + 21,
                                                     carPosY - 2, 0);
                set = Instantiate(asphaltTile) as GameObject;
                set.transform.position = new Vector3((int)carPosX + 22,
                                                     carPosY - 2, 0);
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
