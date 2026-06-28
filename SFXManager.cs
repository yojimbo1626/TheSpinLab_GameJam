using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXManager : MonoBehaviour
{
    private AudioSource audioSource;

    // List out your different sound effects
    public AudioClip deathSound;
    public AudioClip winLevelSound;
    public AudioClip winGameSound;

    void Start()
    {
        // Automatically fetches the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    // Call these methods from other scripts or events
    public void PlayDeath()
    {
        audioSource.PlayOneShot(deathSound);
    }

    public void PlayWinLevel()
    {
        audioSource.PlayOneShot(winLevelSound);
    }

    public void PlayWinGame()
    {
        audioSource.PlayOneShot(winGameSound);
    }
}
