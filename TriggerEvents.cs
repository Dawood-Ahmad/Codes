using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


[RequireComponent(typeof(BoxCollider))]
public class TriggerEvents : MonoBehaviour
{
    public UnityEvent triggerEvents, waitEvents;
    public float waitTime = 0;
    Button actionButton;
    public bool automatic;
    private void Start()
    {
        actionButton = GameManager.instance.actionButton;
        actionButton.onClick.RemoveAllListeners();
    }

    private void OnTriggerEnter(Collider other)
    {
        actionButton.onClick.RemoveAllListeners();
        actionButton.onClick.AddListener(InvokeEvents);
        if (other.gameObject.CompareTag("Player"))
        {
            if (automatic)
            {
                StartCoroutine("InvokingEvents");
            }
            else
            {
                actionButton.gameObject.SetActive(true);
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        actionButton.onClick.RemoveAllListeners();
        if (other.gameObject.CompareTag("Player"))
            actionButton.gameObject.SetActive(false);
    }


    void InvokeEvents()
    {
        actionButton.onClick.RemoveAllListeners();
        StartCoroutine("InvokingEvents");
    }


    IEnumerator InvokingEvents()
    {
        GameManager.instance.FadeInOut();
        yield return new WaitForSeconds(0.5f);
        triggerEvents.Invoke();
        yield return new WaitForSeconds(waitTime);
        waitEvents.Invoke();
        actionButton.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }


}
