using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health;
    public float speed = 0.5f;
    public GameLogic gameLogic;
    public Transform planet;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            gameLogic.money += 5;
            Die();
        }
        transform.LookAt(planet);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Planet")
        {
            gameLogic.planetHealth -= health;
            Die();
        }
    }
    void Die()
    {
        int id = gameLogic.enemies.IndexOf(gameObject);
        gameLogic.enemies.RemoveAt(id);
        Destroy(gameObject);
    }
}
