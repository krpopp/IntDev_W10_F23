using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : DialogueObject
{

    //for dialogue changes
    [SerializeField]
    private Sprite basePortrait, susPortrait;

    //increase the dialogue count
    //find the next line
    //change the portrait
    //remove the first character (which determines the portrait) from the line
    public override string UpdateDialogue()
    {
        DialogueCounter++;
        string nextLine = CurrentText[DialogueCounter];
        dialogueManager.SetPortrait(SwitchPortrait(nextLine[0]));
        nextLine = nextLine.Substring(1);
        return nextLine;
    }

    //call base talkto
    //find the next line
    //change the portrait
    //remove the first character (which determines the portrait) from the line
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
