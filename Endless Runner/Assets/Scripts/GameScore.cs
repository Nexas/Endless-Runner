using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameScore : MonoBehaviour {
    
    string text;
    static bool created;
    public Text scoreText;

    void Awake()
    {
        if (created)
            return;
        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start () {
        created = true;
        UpdateText();
    }
	
	// Update is called once per frame
	void Update () {
        UpdateText();
    }

    void UpdateText()
    {
        scoreText.text = "Score: " + GameGod.score.ToString();
    }
}
