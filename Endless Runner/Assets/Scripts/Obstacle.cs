using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    const float TRAVEL_SPEED = -.095f;
    Vector3 camLeft;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        camLeft = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, -10.0f));

        this.transform.Translate(new Vector3(TRAVEL_SPEED, 0.0f, 0.0f));
        
        if (transform.position.x < camLeft.x - 2.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
