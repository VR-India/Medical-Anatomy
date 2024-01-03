using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Represents information about a specific anatomical part, including its name and description.
/// </summary>
[System.Serializable]
public class AnatomyInfo
{
    /// <summary>
    /// The name of the anatomical part.
    /// </summary>
    public string objectName;

    /// <summary>
    /// The description of the anatomical part.
    /// </summary>
    public string objectDescription;
}

/// <summary>
/// ScriptableObject containing a list of AnatomyInfo objects representing human body parts information.
/// </summary>
[CreateAssetMenu(menuName = "Scriptable/Human/PartsInformation")]
public class AnatomyInformationSO : ScriptableObject
{
    /// <summary>
    /// List of AnatomyInfo objects containing information about various human body parts.
    /// </summary>
    public List<AnatomyInfo> anatomyInfos;

    /// <summary>
    /// Retrieves the description of a specific anatomical part based on its name.
    /// </summary>
    /// <param name="id">The name of the anatomical part.</param>
    /// <returns>The description of the anatomical part, or null if not found.</returns>
    public string GetDetails(string id)
    {
        AnatomyInfo info = anatomyInfos.Find(anatomy => anatomy.objectName == id);
        return info?.objectDescription;
    }
}
