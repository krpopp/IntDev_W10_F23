using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //for writing out a character's dialogue
    [SerializeField]
    private List<string> allLines;

    private int allLinesCount;

    private int dialogueCounter = 0;

    private string currentLine;

    [SerializeField]
    private DialogueManager dialogueManager;

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
        return currentLine;
    }

    //tell the manager to start dialogue, change our portrait
    void EnterDialogue()
    {
    }

    //reset our dialogue vars
    void ExitDialogue()
    {
        dialogueCounter = 0;
        currentLine = allLines[dialogueCounter];
        GameManager.Instance.AddInventory(gameObject);
    }
}
