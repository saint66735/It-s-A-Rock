using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour {

    public Transform planet;
    public GameLogic gameLogic;
    public int currentBuilding = 0;
	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && gameLogic.money>=gameLogic.buildings[currentBuilding].cost)
        { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                Vector3 position = Input.mousePosition;

                position = hitInfo.point;

                GameObject temp = Instantiate(gameLogic.buildingGameObjects[currentBuilding],
                    position, new Quaternion());
                temp.transform.rotation = Quaternion.LookRotation(2*transform.position - planet.position);
                temp.transform.parent = planet;
                if (gameLogic.buildings[currentBuilding].type == "turret")
                {
                    temp.GetComponent<Shoot>().currentBuilding = gameLogic.buildings[currentBuilding];
                    temp.GetComponent<Shoot>().gameLogic = gameLogic;
                }
                else if (gameLogic.buildings[currentBuilding].type == "money") gameLogic.moneyBuildingCount++;

                gameLogic.money -= gameLogic.buildings[currentBuilding].cost;
            }
        }
    }
    
}
