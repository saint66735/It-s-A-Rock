using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Dropdown dropdown;
    public Text moneyDisplay;
    public Place place;
    public GameObject enemy;
    public Transform planet;
    public GameLogic gameLogic;
    public Text planetHealthDisplay;

    public Building[] buildings = new Building[4];
    public float moneyBuildingCount = 0;
    float moneyTime = 0;
    public float planetHealth = 50;

    float enemySpawnTime = 0;
    public float enemySpawnInterval = 5;
    public float enemyHealth = 3;


    // Use this for initialization
    void Start () {
        gameLogic = gameObject.GetComponent<GameLogic>();

        buildings[0] = new Building("factory","money",10,0,0);
        buildings[1] = new Building("laser", "turret", 10, 1, 0.5f);
        buildings[2] = new Building("railgun", "turret", 30, 15, 2);
        buildings[3] = new Building("icbm", "turret", 100, 150, 10);

        //enemies = new List<GameObject>();
        money = 30;
        dropdown.options.Clear();
        foreach (var building in buildings)
        {
            Dropdown.OptionData option = new Dropdown.OptionData(building.name +" "+ building.cost+"$");
            dropdown.options.Add(option);
        }
        dropdown.captionText.text = dropdown.options[0].text;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        enemySpawnTime += Time.deltaTime;
        moneyTime += Time.deltaTime;
        if (moneyTime >= 1)
        {
            money += moneyBuildingCount;
            moneyTime = 0;
        }
        moneyDisplay.text = "money:" + money;
        planetHealthDisplay.text = "health:" + planetHealth;

        if (enemySpawnTime > enemySpawnInterval)
        {
            SpawnEnemy();
            enemyHealth += 0.2f;
            enemySpawnTime = 0;
        }
	}
    public void updateBuildingValue()
    {
        place.currentBuilding = dropdown.value;
    }
    public void SpawnEnemy()
    {
        Vector3 position = Random.onUnitSphere*15;
        GameObject temp = Instantiate(enemy, position, new Quaternion());
        temp.transform.LookAt(planet);
        enemies.Add(temp);
        temp.GetComponent<Enemy>().health = enemyHealth;
        temp.GetComponent<Enemy>().gameLogic = gameLogic;
        temp.GetComponent<Enemy>().planet = planet;
    }

}
