using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateClockwise : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.RotateAround(Vector3.zero, Vector3.up, 35 * Time.deltaTime);
	}
}
