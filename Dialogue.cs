using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{

    public string dialogue;

    private void OnEnable()
    {
        DialogueManager.instance.ShowDialogue(dialogue);
    }


    private void OnDisable()
    {
        DialogueManager.instance.HideDialogPanel();
    }


}
