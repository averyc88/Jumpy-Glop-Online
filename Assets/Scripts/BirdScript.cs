using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public Animator birdAnimator;
    // public AudioSource jump;


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        // jump = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
            birdAnimator.Play("BirdJumpAnimationTWO");
            // jump.Play();
        }
    }

    // handle collisions with pipes
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!logic.gameEnded)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }
}
