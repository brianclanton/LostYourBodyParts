using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NarrationController : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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
