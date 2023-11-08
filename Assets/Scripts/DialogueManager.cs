using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //for setting the dialogue visuals
    [SerializeField]
    private GameObject textPanel;
    [SerializeField]
    private TMP_Text dialogueText;

    //tracks if we're showing dialogue or not
    public static bool inDialogue = false;

    //for referencing the thing we're talking to
    private NPC talkingToNPC;
    private Item talkingToItem;

    //image in the canvas that will disply the portrait
    [SerializeField]
    private Image portraitImage;

    //move through story if we're in dialogue mode
    private void Update()
    {
        if(inDialogue)
        {
            CheckInput();
        }
    }

    //increase dialogue if we press space
    private void CheckInput()
    {
    }

    
}
