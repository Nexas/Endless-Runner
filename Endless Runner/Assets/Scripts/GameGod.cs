using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGod : MonoBehaviour {

    public static float score;
    static public bool isPaused;
    static bool created;

    void Awake()
    {
        if (created)
            return;
        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start () {
        created = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isPaused)
        {
            score += 2.5f * Time.deltaTime;
        }
	}
}
