using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour {

    public GameObject building;
    public Transform planet;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                Vector3 position = Input.mousePosition;

                position = hitInfo.point;

                GameObject temp = Instantiate(building, position, new Quaternion());
                temp.transform.rotation = Quaternion.LookRotation(2*transform.position - planet.position);
                temp.transform.parent = planet;


            }
        }
    }
}
