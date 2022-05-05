using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Crosstales.RTVoice;

public class DialogueManager : MonoBehaviour
{
    #region Singleton
    public static DialogueManager instance;

    void Instanciate()
    {
        instance = this;
    }
    #endregion

    private void Awake()
    {
        Instanciate();
        showBool = Animator.StringToHash("show");
        //Speaker.CreateInstance();
    }

    public Animator dialoguePanel;
    public TextMeshProUGUI dialogueText;
    int showBool;
    public AudioSource source;

    public void ShowObjectiveWithInfo(string info)
    {
        dialogueText.SetText(info);
        StartCoroutine("ShowObjectiveRoutine");
        Speaker.Instance.Speak(info);
    }

    public void ShowObjective()
    {
        StartCoroutine("ShowObjectiveRoutine");
    }

    IEnumerator ShowObjectiveRoutine()
    {
        dialoguePanel.SetBool(showBool, true);
        yield return new WaitForSeconds(4);
        dialoguePanel.SetBool(showBool, false);
    }


    public void ShowDialogue(string dialogue)
    {
        dialogueText.SetText(dialogue);
        dialoguePanel.SetBool(showBool, true);
        Speaker.Instance.Speak(dialogue);
    }

    public void ShowDialogPanel()
    {
        dialoguePanel.SetBool(showBool, true);
    }

    public void HideDialogPanel()
    {
        StopCoroutine("ShowObjectiveRoutine");
        dialoguePanel.SetBool(showBool, false);
    }


}
