using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorOpenClose : MonoBehaviour
{

    Button doorButton;
    public Animator door;
    bool isOpen;


    private void Start()
    {
        isOpen = false;
        doorButton = GameManager.instance.doorButton;
    }


    private void OnTriggerEnter(Collider other)
    {
        doorButton.gameObject.SetActive(true);

        doorButton.onClick.RemoveAllListeners();
        doorButton.onClick.AddListener(OpenClose);
    }

    private void OnTriggerExit(Collider other)
    {
        doorButton.gameObject.SetActive(false);
        doorButton.onClick.RemoveAllListeners();
    }

    void OpenClose()
    {
        isOpen = !isOpen;
        door.SetBool("IsOpen", isOpen);
    }

}
