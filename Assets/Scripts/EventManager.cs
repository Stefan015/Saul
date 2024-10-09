using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    public event Action OnEvent10;
    public event Action OnEvent100;
    public event Action OnEvent1k;
    public event Action OnEvent10k;
    public event Action OnEvent100k;
    public event Action OnEvent1m;
    public event Action OnEventClick;


    public event Action infoEventClick;
    public event Action infoEventCup;
    public event Action infoEventBrief;
    public event Action infoEventCar;
    public event Action infoEventKim;
    public event Action infoEventWalt;
    public event Action infoEventLalo;
    public event Action infoEventReset;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("more than one EventManager in scene");
        }
        Instance = this;
    }

    public void TriggerEvent10() => OnEvent10?.Invoke();
    public void TriggerEvent100() => OnEvent100?.Invoke();
    public void TriggerEvent1k() => OnEvent1k?.Invoke();
    public void TriggerEvent10k() => OnEvent10k?.Invoke();
    public void TriggerEvent100k() => OnEvent100k?.Invoke();
    public void TriggerEvent1m() => OnEvent1m?.Invoke();
    public void TriggerEventClick() => OnEventClick?.Invoke();


    public void TriggerEventInfoClick() => infoEventClick?.Invoke();
    public void TriggerEventInfoCup() => infoEventCup?.Invoke();
    public void TriggerEventInfoBreif() => infoEventBrief?.Invoke();
    public void TriggerEventInfoCar() => infoEventCar?.Invoke();
    public void TriggerEventInfoKim() => infoEventKim?.Invoke();
    public void TriggerEventInfoWalt() => infoEventWalt?.Invoke();
    public void TriggerEventInfoLalo() => infoEventLalo?.Invoke();
    public void TriggerEventInfoReset() => infoEventReset?.Invoke();
}
