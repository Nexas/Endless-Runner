using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Object spawnObject;
    const float SPAWN_TIMER_MAX_RANGE = 2.25f;    // A timer used to determine the maximum time of when to spawn obstacles.
    const float SPAWN_TIMER_MIN_RANGE = 0.95f;    // A timer used to determine the maximum time of when to spawn obstacles.
    float spawnTimerCooldown = 0.0f;    // A secondary float used to count up to the SPAWN_TIMER amount.

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        spawnTimerCooldown += Time.deltaTime;

        if (spawnTimerCooldown >= SPAWN_TIMER_MIN_RANGE)
        {
            int spawnChance5050 = Random.Range(1, 5);
            if (spawnChance5050 == 4)
            {
                Instantiate(spawnObject, this.transform.position, new Quaternion());
                spawnTimerCooldown = 0.0f;
            }
        }
        else if (spawnTimerCooldown >= SPAWN_TIMER_MAX_RANGE)
        {
            Instantiate(spawnObject, this.transform.position, new Quaternion());
            spawnTimerCooldown = 0.0f;
        }
	}
}
