using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script deserializes data from a JSON file.
/// </summary>
public class JSONFetch : MonoBehaviour
{
    /// <summary>
    /// Represents the skeletal structure containing a list of body parts.
    /// </summary>
    [System.Serializable]
    public class Skeletal
    {
        /// <summary>
        /// List of body parts.
        /// </summary>
        public List<Parts> list;
    }

    /// <summary>
    /// Represents a body part with a name and description.
    /// </summary>
    [System.Serializable]
    public class Parts
    {
        /// <summary>
        /// The name of the body part.
        /// </summary>
        public string name;

        /// <summary>
        /// The description of the body part.
        /// </summary>
        public string description;
    }

    private Skeletal skeletal = new Skeletal();

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Json/Skeletal");
        if (jsonFile != null)
        {
            string jsonString = jsonFile.ToString();
            skeletal = JsonUtility.FromJson<Skeletal>(jsonString);
        }
        else
        {
            Debug.LogError("JSON file not found at 'Json/Skeletal'. Make sure the file exists and is placed in the Resources folder.");
        }
    }

    /// <summary>
    /// Gets the description of a body part based on its name.
    /// </summary>
    /// <param name="id">The name of the body part.</param>
    /// <returns>The description of the body part, or null if not found.</returns>
    public string GetDescription(string id)
    {
        foreach (var item in skeletal.list)
        {
            if (item.name == id)
            {
                return item.description;
            }
        }
        return null;
    }
}
