using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPublisher7 : MonoBehaviour, IInteractable
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
            EventManager.Instance.TriggerEventClick();
        }
    }
    public void onHover()
    {
        EventManager.Instance.TriggerEventInfoClick();
    }
}
