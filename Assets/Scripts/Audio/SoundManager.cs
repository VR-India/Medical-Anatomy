using UnityEngine;

/// <summary>
/// Manages playing sound clips using an AudioSource and a collection of sounds.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    /// <summary>
    /// Collection of sounds available for playback.
    /// </summary>
    public Sounds Sounds;
    private AudioSource audioSource;

    /// <summary>
    /// Singleton instance of the SoundManager.
    /// </summary>
    public static SoundManager Instance { get; private set; }
    private void Awake()
    {
        // Ensure only one instance of SoundManager exists
        if (Instance == null)
        {
            Instance = this;
        }

        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Plays a sound clip once if the AudioSource is not already playing.
    /// </summary>
    /// <param name="_clip">The AudioClip to play.</param>
    public void PlayClipOneShot(AudioClip _clip)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(_clip);
        }
    }
}