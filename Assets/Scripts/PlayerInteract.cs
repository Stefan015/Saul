using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
    public void onHover();
}
public class PlayerInteract : MonoBehaviour
{
    public Transform InteractSource;
    public float InteractRange;

    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    bool hoverAudioPlayed = false, pressAudioPlayed = false;
    void Update()
    {
        Ray r = new Ray(InteractSource.position, InteractSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                interactObj.onHover();

                if (!hoverAudioPlayed)
                {
                    audioManager.playSFX(audioManager.buttonHover);
                    hoverAudioPlayed = true;
                }
            }
            else { EventManager.Instance.TriggerEventInfoReset(); hoverAudioPlayed = false; }

            if (Input.GetKeyDown(KeyCode.Mouse0) && (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactingObj)))
            {
                interactingObj.Interact();
                if (!pressAudioPlayed)
                {
                    audioManager.playSFX(audioManager.buttonPress);
                    pressAudioPlayed = true;
                }
            }
            else { pressAudioPlayed = false; }

        }
    }
}
