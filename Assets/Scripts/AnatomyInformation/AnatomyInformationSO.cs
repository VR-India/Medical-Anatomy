using UnityEngine;
using System.Collections.Generic;

[System.Serializable] public class AnatomyInfo { public string objectName; public string objectDescription; }
[CreateAssetMenu(menuName = "Scriptable/Human/PartsInformation")]
public class AnatomyInformationSO : ScriptableObject
{
    public List<AnatomyInfo> ds;
    public string GetDetails(string id)
    {
        foreach (AnatomyInfo ds in ds)
        {
            if (ds.objectName == id)
            {
                return ds.objectDescription;
            }
        }
        return null;
    }
}