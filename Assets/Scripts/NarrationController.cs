using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NarrationController : MonoBehaviour
{
    public AudioClip[] audioClips;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayNarration(int num)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }

        audioSource.clip = audioClips[num];
        audioSource.Play();
    }
}
