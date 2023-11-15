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
    private DialogueObject talkingTo;

    //image in the canvas that will disply the portrait
    [SerializeField]
    private GameObject portraitImage;

    delegate void EndText();
    EndText endText;

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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Progress();
        }
    }

    public void BeginDescription(DialogueObject clickedOn, string text)
    {
        TurnOffPortrait();
        talkingTo = clickedOn;
        endText = EndDescription;
        SwitchPanel(text, true);
    }

    public void EndDescription()
    {
        SwitchPanel("", false);
    }

    //set who we're talking to, turn on the dialogue panel
    public void BeginDialogue(DialogueObject clickedOn, string text)
    {
        endText = EndDialogue;
        talkingTo = clickedOn;
        SwitchPanel(text, true);
    }

    //change what portrait is showing
    public void SetPortrait(Sprite portrait)
    {
        portraitImage.SetActive(true);
        portraitImage.GetComponent<Image>().sprite = portrait;
    }

    public void TurnOffPortrait()
    {
       portraitImage.SetActive(false);
    }

    //end dialogue if we've reached the end or go to the next line
    private void Progress()
    {
        if(talkingTo.DialogueCounter >= talkingTo.AllLinesCount - 1)
        {
            EndDialogue();
        }
        else
        {
            dialogueText.text = talkingTo.UpdateDialogue();
        }
    }

    //clear our dialogue vars, turn off the panel
    private void EndDialogue()
    {
        TurnOffPortrait();
        talkingTo.ExitDialogue();
        talkingTo = null;
        SwitchPanel("", false);
    }

    //set the text of our panel, turn it off or on and set if we're in dialogue or not
    private void SwitchPanel(string displayText, bool status)
    {
        dialogueText.text = displayText;
        textPanel.SetActive(status);
        inDialogue = status;
    }
}
