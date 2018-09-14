using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health;
    public GameLogic gameLogic;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            int id = gameLogic.enemies.IndexOf(gameObject);
            gameLogic.enemies.RemoveAt(id);
            Destroy(gameObject);
        }
	}
}
