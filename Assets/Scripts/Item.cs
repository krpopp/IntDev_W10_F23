using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : DialogueObject
{
    //increase the dialogue index
    //return whatever the next line should be
    public override string UpdateDialogue()
    {
        DialogueCounter++;
        string nextLine = CurrentText[DialogueCounter];
        return nextLine;
    }

    //run base talkto
    //find the next text line and start dialogue
    public override void TalkTo()
    {
        base.TalkTo();
        string nextLine = CurrentText[DialogueCounter];
        dialogueManager.BeginDescription(this, nextLine);
    }

    //run base grab
    //add this to the inventory
    public override void Grab()
    {
        base.Grab();
        GameManager.Instance.AddInventory(gameObject);
    }
}
