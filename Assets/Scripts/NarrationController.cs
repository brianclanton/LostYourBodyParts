﻿using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NarrationController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip introClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Start()
    {
        if (Collectibles.count == 0)
        {
            audioSource.clip = introClip;
            audioSource.Play();
        }
    }

    public void PlayNarration(AudioClip clip)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }

        audioSource.clip = clip;
        audioSource.Play();
    }
}
