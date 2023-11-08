using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //movement vars
    [SerializeField]
    private float speed;
    private Rigidbody2D myBody;
    private float hMove;
    private float vMove;

    //for triggering dialogue when collding
    [SerializeField]
    private DialogueManager dialogueManager;

    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    //move, otherwise if we're talking, freeze the player
    private void Update()
    {
        if (!DialogueManager.inDialogue)
        {
            GetInput();
        }
        else
        {
            hMove = 0;
            vMove = 0;
            myBody.velocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        DoMove();
    }

    //check input
    void GetInput()
    {
        hMove = Input.GetAxis("Horizontal");
        vMove = Input.GetAxis("Vertical");
    }

    //do physics calculations
    void DoMove()
    {
        Vector3 newVel = myBody.velocity;
        newVel.x = hMove * speed;
        newVel.y = vMove * speed;
        myBody.velocity = newVel;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("NPC") || collision.gameObject.CompareTag("Item"))
        {
            CollideTalkable(collision.gameObject.GetComponent<ITalkable>());
        }
        else if(collision.gameObject.CompareTag("Exit"))
        {
            CollideExit();
        }
    }

    //for colliding w/ things that can talk
    private void CollideTalkable(ITalkable hitThing)
    {
        hitThing.EnterDialogue();
    }

    //for colliding w/ the exit
    private void CollideExit()
    {
        SceneLoader.LoadNewScene("End");
    }
}
