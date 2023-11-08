using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ITalkable
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
    public string CurrentLine
    {
        get
        {
            return currentLine;
        }
        set
        {
            currentLine = value;
        }
    }

    private string currentLine;

    [SerializeField]
    private DialogueManager dialogueManager;

    private void Start()
    {
        CurrentLine = allLines[DialogueCounter];
        AllLinesCount = allLines.Count;
    }

    //go to the next line, change the portrait, send the text of this line to the manager
    string ITalkable.UpdateDialogue()
    {
        DialogueCounter++;
        CurrentLine = allLines[DialogueCounter];
        return CurrentLine;
    }

    //tell the manager to start dialogue, change our portrait
    void ITalkable.EnterDialogue()
    {
        dialogueManager.TurnOffPortrait();
        dialogueManager.BeginDialogue(this, CurrentLine);
    }

    //reset our dialogue vars
    void ITalkable.ExitDialogue()
    {
        DialogueCounter = 0;
        CurrentLine = allLines[DialogueCounter];
        GameManager.Instance.AddInventory(gameObject);
    }
}
