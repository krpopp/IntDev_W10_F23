using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //for writing out a character's dialogue
    [SerializeField]
    private List<string> allLines;

    private int allLinesCount;

    private int dialogueCounter = 0;

    private string currentLine;

    //for dialogue changes
    [SerializeField]
    private DialogueManager dialogueManager;
    [SerializeField]
    private Sprite basePortrait, susPortrait;

    private void Start()
    {
        currentLine = allLines[dialogueCounter];
        allLinesCount = allLines.Count;
    }

    //go to the next line, change the portrait, send the text of this line to the manager
    string UpdateDialogue()
    {
        dialogueCounter++;
        currentLine = allLines[dialogueCounter];
        currentLine = currentLine.Substring(1);
        return currentLine;
    }

    //tell the manager to start dialogue, change our portrait
    void EnterDialogue()
    {
        currentLine = currentLine.Substring(1);
    }

    //reset our dialogue vars
    void ExitDialogue()
    {
        dialogueCounter = 0;
        currentLine = allLines[dialogueCounter];
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
