using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITalkable 
{
    public string CurrentLine { get; set; }
    public int DialogueCounter { get; set; }
    public int AllLinesCount { get; set; }
    public void EnterDialogue();
    public string UpdateDialogue();
    public void ExitDialogue();
}
