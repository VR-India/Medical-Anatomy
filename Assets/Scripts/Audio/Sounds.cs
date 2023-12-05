using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class sound
{
    public string name;
    public AudioClip clip;
}
[CreateAssetMenu(fileName = "AudioClips", menuName = "Scriptable/Sounds", order = 1)]
public class Sounds : ScriptableObject
{
    public List<sound> clips;

    public AudioClip GetClip(string name)
    {
        foreach (var c in clips)
        {
            if (c.name == name)
                return c.clip;
        }
        return null;
    }
}