using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour
{
    //image files for what the cursor can be
    [SerializeField]
    Texture2D baseCursor, grabCursor, tasteCursor, talkCursor, lookCursor;

    //if we should use hardware or software renderer cursors
    [SerializeField]
    CursorMode cursorMode = CursorMode.Auto;

    //where on the cursor sprite we should be able to to click
    Vector2 hotSpot = Vector2.zero;

    //delegate to hold methods that call when the player clicks
    delegate void ClickDelegate();
    ClickDelegate clicked;

    //will hold the thing we clicked on
    DialogueObject clickedOn = null;

    //states for the cursor
    public enum CURSORS
    {
        BASE,
        GRAB,
        TASTE,
        TALK,
        LOOK
    }

    //property for the cursor state
    //sets the cursor state, including changing the cursor image and the click delegate
    public CURSORS CurrentCursor
    {
        get
        {
            return currentCursor;
        }
        set
        {
            switch(value)
            {
                case CURSORS.BASE:
                    clicked = BaseClick;
                    Cursor.SetCursor(baseCursor, hotSpot, cursorMode);
                    break;
                case CURSORS.GRAB:
                    clicked = GrabClick;
                    Cursor.SetCursor(grabCursor, hotSpot, cursorMode);
                    break;
                case CURSORS.TASTE:
                    clicked = TasteClick;
                    Cursor.SetCursor(tasteCursor, hotSpot, cursorMode);
                    break;
                case CURSORS.TALK:
                    clicked = TalkClick;
                    Cursor.SetCursor(talkCursor, hotSpot, cursorMode);
                    break;
                case CURSORS.LOOK:
                    clicked = LookCLick;
                    Cursor.SetCursor(lookCursor, hotSpot, cursorMode);
                    break;
            }
            currentCursor = value;
        }
    }

    //private state var
    private CURSORS currentCursor;

    // set the starting cursor state
    void Start()
    {
        CurrentCursor = CURSORS.BASE;
    }

    // Update is called once per frame
    void Update()
    {
        //if we're not seeing dialogue
        if (!DialogueManager.inDialogue)
        {
            //check if the player has pressed a key
            SwitchCursor();
            //if the mouse button is pressed
            if (Input.GetMouseButtonDown(0))
            {
                //create a raycast from the mouse's position
                RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
                //if it hits something
                if (rayHit)
                {
                    //if its a thing that can talk
                    if (rayHit.transform.gameObject.GetComponent<DialogueObject>())
                    {
                        //get the thing that is clicked on
                        clickedOn = rayHit.transform.GetComponent<DialogueObject>();
                        //run the clicked delegate
                        clicked();
                    }
                }
            }
        }
    }

    //switch the cursor state based on key presses
    void SwitchCursor()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentCursor = CURSORS.BASE;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentCursor = CURSORS.LOOK;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentCursor = CURSORS.TALK;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CurrentCursor = CURSORS.TASTE;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            CurrentCursor = CURSORS.GRAB;
        }
    }

    //different methods for what the player can do when clicking

    void BaseClick()
    {

    }

    void GrabClick()
    {
        clickedOn.Grab();
    }

    void LookCLick()
    {
        clickedOn.LookAt();
    }

    void TalkClick()
    {
        clickedOn.TalkTo();
    }

    void TasteClick()
    {
        clickedOn.Taste();
    }

}
