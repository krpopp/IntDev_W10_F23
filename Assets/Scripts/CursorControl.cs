using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour
{
    [SerializeField]
    Texture2D baseCursor, grabCursor, tasteCursor, talkCursor, lookCursor;

    [SerializeField]
    CursorMode cursorMode = CursorMode.Auto;

    Vector2 hotSpot = Vector2.zero;

    delegate void ClickDelegate();
    ClickDelegate clicked;

    DialogueObject clickedOn = null;

    public enum CURSORS
    {
        BASE,
        GRAB,
        TASTE,
        TALK,
        LOOK
    }

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

    private CURSORS currentCursor;

    // Start is called before the first frame update
    void Start()
    {
        CurrentCursor = CURSORS.BASE;
        clicked = BaseClick;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchCursor();
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if(rayHit)
            {
                if (rayHit.transform.gameObject.GetComponent<DialogueObject>())
                {
                    clickedOn = rayHit.transform.GetComponent<DialogueObject>();
                    clicked();
                }
            }
        }
    }

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
