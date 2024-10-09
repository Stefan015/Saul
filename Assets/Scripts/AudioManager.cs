using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource SFXSource;

    public AudioClip buttonPress;
    public AudioClip buttonHover;
    public AudioClip backgroundSound;

    private void Start()
    {
        backgroundMusic.clip = backgroundSound;
        backgroundMusic.Play();
    }

    public void playSFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
