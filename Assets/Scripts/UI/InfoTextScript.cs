using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoTextScript : MonoBehaviour
{
    public TextMeshProUGUI infoText;


    void Update()
    {
    }
    void OnEnable()
    {
        EventManager.Instance.infoEventClick += HandleClick;
        EventManager.Instance.infoEventCup += HandleCup;
        EventManager.Instance.infoEventBrief += HandleBrief;
        EventManager.Instance.infoEventCar += HandleCar;
        EventManager.Instance.infoEventKim += HandleKim;
        EventManager.Instance.infoEventWalt += HandleWalt;
        EventManager.Instance.infoEventLalo += HandleLalo;
        EventManager.Instance.infoEventReset += HandleReset;
 
    }

    void OnDisable()
    {
        EventManager.Instance.infoEventClick -= HandleClick;
        EventManager.Instance.infoEventCup -= HandleCup;
        EventManager.Instance.infoEventBrief -= HandleBrief;
        EventManager.Instance.infoEventCar -= HandleCar;
        EventManager.Instance.infoEventKim -= HandleKim;
        EventManager.Instance.infoEventWalt -= HandleWalt;
        EventManager.Instance.infoEventLalo -= HandleLalo;
        EventManager.Instance.infoEventReset -= HandleReset;

    }
    void HandleClick() { infoText.text = "1 click = 1 case won"; }
    void HandleCup() { infoText.text = "Cost: 10cw, Production +1cw/s"; }
    void HandleBrief() { infoText.text = "Cost: 100cw, Production +10cw/s"; }
    void HandleCar() { infoText.text = "Cost: 1000cw, Production +100cw/s"; }
    void HandleKim() { infoText.text = "Cost: 10000cw, Production +1000cw/s"; }
    void HandleWalt() { infoText.text = "Cost: 100000cw, Production +10000cw/s"; }
    void HandleLalo() { infoText.text = "Cost: 1000000cw, Production +100000cw/s"; }
    void HandleReset() { infoText.text = ""; }


}
