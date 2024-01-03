using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a sound with a name and associated AudioClip.
/// </summary>
[System.Serializable]
public class Sound
{
    /// <summary>
    /// The name of the sound.
    /// </summary>
    public string Name;

    /// <summary>
    /// The AudioClip associated with the sound.
    /// </summary>
    public AudioClip Clip;
}

/// <summary>
/// A collection of sounds stored as a ScriptableObject.
/// </summary>
[CreateAssetMenu(fileName = "AudioClips", menuName = "Scriptable/Sounds", order = 1)]
public class Sounds : ScriptableObject
{
    /// <summary>
    /// List of sounds.
    /// </summary>
    public List<Sound> Clips;

    /// <summary>
    /// Gets the AudioClip associated with the specified sound name.
    /// </summary>
    /// <param name="name">The name of the sound.</param>
    /// <returns>The AudioClip associated with the specified name, or null if not found.</returns>
    public AudioClip GetClip(string name)
    {
        foreach (var sound in Clips)
        {
            if (sound.Name == name)
                return sound.Clip;
        }
        return null;
    }
}