using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPublisher2 : MonoBehaviour, IInteractable
{
    private ButtonPress bp;

    void Start()
    {
        bp = GetComponent<ButtonPress>();

        if (bp != null)
        {
            bp.ScaleDown();
        }
        else
        {
            Debug.LogError("ButtonPress component not found.");
        }
    }
    public void Interact()
    {
        bp.ScaleDown();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            EventManager.Instance.TriggerEvent100();
        }
    }
    public void onHover()
    {
        EventManager.Instance.TriggerEventInfoBreif();
    }
}
