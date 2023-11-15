using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : DialogueObject
{

    public override string UpdateDialogue()
    {
        DialogueCounter++;
        string nextLine = CurrentText[DialogueCounter];
        return nextLine;
    }

    public override void TalkTo()
    {
        base.TalkTo();
        string nextLine = CurrentText[DialogueCounter];
        dialogueManager.BeginDescription(this, nextLine);
    }

    public override void Grab()
    {
        base.Grab();
        GameManager.Instance.AddInventory(gameObject);
    }
}
