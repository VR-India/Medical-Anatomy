using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public Sounds sounds;
    AudioSource audioSource;
    public static SoundManager instance;
    void Awake()
    {
        if (instance == null) { instance = this; }
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayClipOneShot(AudioClip _clip)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(_clip);
        }
    }

    public void playit()
    {
        PlayClipOneShot(sounds.GetClip("grab"));
    }
    public void playitt()
    {
        PlayClipOneShot(sounds.GetClip("drum"));
    }
}