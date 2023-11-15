using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : DialogueObject
{

    //for dialogue changes
    [SerializeField]
    private Sprite basePortrait, susPortrait;

    public override string UpdateDialogue()
    {
        DialogueCounter++;
        string nextLine = CurrentText[DialogueCounter];
        dialogueManager.SetPortrait(SwitchPortrait(nextLine[0]));
        nextLine = nextLine.Substring(1);
        return nextLine;
    }

    public override void TalkTo()
    {
        base.TalkTo();
        string nextLine = CurrentText[DialogueCounter];
        dialogueManager.SetPortrait(SwitchPortrait(nextLine[0]));
        nextLine = nextLine.Substring(1);
        dialogueManager.BeginDialogue(this, nextLine);
    }

    //change portraits based on the first char of the line
    private Sprite SwitchPortrait(char firstChar)
    {
        switch(firstChar)
        {
            case '$':
                return basePortrait;
            case '%':
                return susPortrait;
            default:
                return basePortrait;
        }
    }
}
