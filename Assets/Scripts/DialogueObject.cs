using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueObject : MonoBehaviour
{

    [SerializeField]
    string[] lookText, tasteText, talkText, grabText;

    public static DialogueManager dialogueManager;

    //tracks how many lines this character can say
    public int AllLinesCount
    {
        get
        {
            return allLinesCount;
        }
        set
        {
            allLinesCount = value;
        }
    }

    private int allLinesCount;

    //tracks the index of which line we should say
    public int DialogueCounter
    {
        get
        {
            return dialogueCounter;
        }
        set
        {
            dialogueCounter = value;
        }
    }

    private int dialogueCounter = 0;

    //tracks which line is next to display
    public string[] CurrentText
    {
        get
        {
            return currentText;
        }
        set
        {
            currentText = value;
        }
    }

    private string[] currentText;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GameObject.Find("Game Manager").GetComponent<DialogueManager>();
    }

    public virtual void LookAt()
    {
        CurrentText = lookText;
        AllLinesCount = lookText.Length;
        dialogueManager.BeginDescription(this, lookText[dialogueCounter]);
    }

    public virtual void Grab()
    {
        CurrentText = grabText;
        AllLinesCount = CurrentText.Length;
        dialogueManager.BeginDescription(this, grabText[dialogueCounter]);
    }

    public virtual void Taste()
    {
        CurrentText = tasteText;
        AllLinesCount = CurrentText.Length;
        dialogueManager.BeginDescription(this, tasteText[dialogueCounter]);
    }

    public virtual void TalkTo()
    {
        CurrentText = talkText;
        AllLinesCount = CurrentText.Length;
    }

    public virtual string UpdateDialogue()
    {
        return "";
    }

    public virtual void ExitDialogue()
    {
        DialogueCounter = 0;
        CurrentText = null;
    }
}
