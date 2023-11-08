using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, ITalkable
{
    //for writing out a character's dialogue
    [SerializeField]
    private List<string> allLines;

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
    public string CurrentLine {
        get
        {
            return currentLine;
        }
        set
        {
            Debug.Log("changed the current line");
            currentLine = value;
        }
    }

    private string currentLine;

    //for dialogue changes
    [SerializeField]
    private DialogueManager dialogueManager;
    [SerializeField]
    private Sprite basePortrait, susPortrait;

    private void Start()
    {
        CurrentLine = allLines[DialogueCounter];
        allLinesCount = allLines.Count;
    }

    //go to the next line, change the portrait, send the text of this line to the manager
    string ITalkable.UpdateDialogue()
    {
        DialogueCounter++;
        CurrentLine = allLines[DialogueCounter];
        dialogueManager.SetPortrait(SwitchPortrait(CurrentLine[0]));
        CurrentLine = CurrentLine.Substring(1);
        return CurrentLine;
    }

    //tell the manager to start dialogue, change our portrait
    void ITalkable.EnterDialogue()
    {
        dialogueManager.SetPortrait(SwitchPortrait(CurrentLine[0]));
        CurrentLine = CurrentLine.Substring(1);
        dialogueManager.BeginDialogue(this, CurrentLine);
    }

    //reset our dialogue vars
    void ITalkable.ExitDialogue()
    {
        DialogueCounter = 0;
        CurrentLine = allLines[DialogueCounter];
    }

    //change portraits based on the first char of the line
    private Sprite SwitchPortrait(char firstChar)
    {
        switch(firstChar)
        {
            case '$':
                return basePortrait;
                break;
            case '%':
                return susPortrait;
                break;
            default:
                return basePortrait;
                break;
        }
    }
}
