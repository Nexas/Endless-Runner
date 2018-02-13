using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeToScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ResizeSpriteToScreen();
	}

    // Function to scale the background to the screen size.
    void ResizeSpriteToScreen()
    {
        SpriteRenderer sr = (SpriteRenderer)GetComponent("Renderer");

        if (sr == null)
            return;

        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector2(worldScreenWidth / width, worldScreenHeight / height);
    }
}
