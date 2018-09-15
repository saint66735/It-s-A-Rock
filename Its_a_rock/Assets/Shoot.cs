using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    // Use this for initialization
    public GameLogic gameLogic;
    public Building currentBuilding;
    float timeSinceShoot=0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timeSinceShoot += Time.deltaTime;

        if (timeSinceShoot > currentBuilding.shootInterval)
        {
            List<GameObject> enemies = gameLogic.enemies;
            if (enemies.Count > 0)
            {
                float max = 0;
                int maxEnemyID = 0;
                foreach (var enemy in enemies)
                {
                    RaycastHit hit;
                    if (enemy != null)
                    {
                        if (!Physics.Linecast(enemy.transform.position, transform.position, out hit))
                        {
                            float dist = Vector3.Distance(enemy.transform.position, transform.position);
                            if (dist > max) { max = dist; maxEnemyID = enemies.IndexOf(enemy); }
                        }
                        else Debug.Log(hit.collider.gameObject.name);
                    }
                    //else enemies.TrimExcess();
                }

                if (max > 0 && max < 6)
                {
                    enemies[maxEnemyID].GetComponent<Enemy>().health -= currentBuilding.damage;
                    timeSinceShoot = 0;
                }
            }
        }
	}
}
