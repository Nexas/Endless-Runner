using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour {

    //private bool isJumping;     // A bool to determine if the player is jumping. TODO: REPLACE WITH PLAYER_STATE
    //private bool isFalling;     // A bool to determine if the player's jump has finished. TODO: REPLACE WITH PLAYER_STATE
    private enum playerState { NORMAL = 0, JUMPING, FALLING, SLIDING, NUM_STATES }
    private playerState currentState;
    private float jumpTimer;    // A timer to determine how long to jump for.
    private float slideTimer;   // A timer to determine how long to slide for.
    private const float JUMP_TIME = 0.30f;
    private const float JUMP_SPEED = 0.15f;
    private const float SLIDE_TIME = 0.5f;
    public Text scoreText;

    // Use this for initialization
    void Start ()
    {
        currentState = playerState.NORMAL;
        jumpTimer = JUMP_TIME;
        UpdateText();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateText();
		for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase != TouchPhase.Ended && Input.GetTouch(i).phase != TouchPhase.Canceled)
            {
                Jump();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Slide();
        }

        if (currentState == playerState.JUMPING)
        {
            jumpTimer -= Time.deltaTime;
            if (jumpTimer > 0.0f)
                this.transform.Translate(new Vector3(0.0f, JUMP_SPEED, 0.0f), Space.World);
            else
            {
                currentState = playerState.FALLING;
            }
        }
        if (currentState == playerState.FALLING)    // TODO: Change so that when the player collides with the ground, currentState is set back to NORMAL.
        {
            jumpTimer += Time.deltaTime;
            if (jumpTimer < JUMP_TIME)
            {
                this.transform.Translate(new Vector3(0.0f, -JUMP_SPEED, 0.0f), Space.World);
            }
            else if (jumpTimer >= JUMP_TIME)
            {
                jumpTimer = JUMP_TIME;
                currentState = playerState.NORMAL;
            }
        }
        if (currentState == playerState.SLIDING)
        {
            if (slideTimer == 0.0f)
            {
                this.transform.Translate(0.0f, -GetComponent<BoxCollider>().size.x / 2.0f, 0.0f, Space.World);
                this.transform.Rotate(Vector3.forward, 90);
                //GetComponent<CharacterController>().Move(new Vector3(0.0f, -GetComponent<BoxCollider>().size.x / 2.0f, 0.0f));
            }
            slideTimer += Time.deltaTime;
            if (slideTimer >= SLIDE_TIME)
            {
                //GetComponent<CharacterController>().Move(new Vector3(0.0f, GetComponent<BoxCollider>().size.x / 2.0f, 0.0f));
                this.transform.Rotate(Vector3.forward, -90);
                this.transform.Translate(0.0f, GetComponent<BoxCollider>().size.x / 2.0f, 0.0f, Space.World);
                slideTimer = 0.0f;
                currentState = playerState.NORMAL;
            }
        }

        //if (this.transform.position.y <= -3.61f && currentState != playerState.SLIDING)
        //{
        //    this.transform.position = new Vector3(this.transform.position.x, -3.61f, this.transform.position.z);
        //    // If the player has already collided with the ground, reset the current state so the player can act again.
        //    if (currentState == playerState.FALLING)
        //    {
        //        currentState = playerState.NORMAL;
        //    }
        //}
	}

    void Jump()
    {
        // If the player was sliding, revert to a standing rotation before jumping.
        if (currentState == playerState.SLIDING)
        {
            this.transform.Rotate(Vector3.forward, -90);
            this.transform.Translate(0.0f, GetComponent<BoxCollider>().size.x / 2.0f, 0.0f, Space.World);
            slideTimer = 0.0f;
            currentState = playerState.NORMAL;
        }

        if (currentState == playerState.NORMAL)
        {
            currentState = playerState.JUMPING;
        }
    }

    void Slide()
    {
        if (currentState != playerState.FALLING && currentState != playerState.JUMPING)
        {
            currentState = playerState.SLIDING;
        }
    }

    void UpdateText()
    {
        int truncScore = (int)GameGod.score;
        scoreText.text = "Score: " + truncScore;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Obstacle")
        {
            Destroy(this.gameObject);  // Player is dead. TODO: Change to Game Over state.
        }

        if (collider.tag == "Ground")
        {
            if ((transform.position.y - (GetComponent<BoxCollider>().size.y / 2.0f)) <= collider.transform.position.y + (collider.bounds.size.y / 2.0f))
            {
                float offsetY = Mathf.Abs((transform.position.y - ((GetComponent<BoxCollider>().size.y / 2.0f))) - (collider.transform.position.y + (collider.bounds.size.y / 2.0f)));
                transform.Translate(new Vector3(0.0f, offsetY, 0.0f));

                //If the player has already collided with the ground, reset the current state so the player can act again.
                if (currentState == playerState.FALLING)
                {
                    currentState = playerState.NORMAL;
                }
            }
        }
    }
}
