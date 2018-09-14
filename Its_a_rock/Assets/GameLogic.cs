using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Building
{
    public string name;
    public string type;
    public float cost;
    public float damage;
    public float shootInterval;

    public Building(string name, string type, float cost, float damage, float shootInterval)
    {
        this.name = name;
        this.type = type;
        this.cost = cost;
        this.damage = damage;
        this.shootInterval = shootInterval;
        
    }

}
public class GameLogic : MonoBehaviour {

    public float money = 0;
    public GameObject[] buildingGameObjects;
    public List<GameObject> enemies = new List<GameObject>();

    public Building[] buildings = new Building[4];
    public float moneyBuildingCount = 0;
    float moneyTime = 0;


    // Use this for initialization
    void Start () {
        buildings[0] = new Building("factory","money",10,0,0);
        buildings[1] = new Building("laser", "turret", 10, 1, 0.5f);
        buildings[2] = new Building("railgun", "turret", 30, 15, 2);
        buildings[3] = new Building("icbm", "turret", 100, 150, 10);

        //enemies = new List<GameObject>();
        money = 30;
    }
	
	// Update is called once per frame
	void Update () {
        if (moneyTime >= 1)
        {
            money += 1 * moneyBuildingCount;
        }
	}
}
