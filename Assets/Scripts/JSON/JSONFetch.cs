using System.Collections.Generic;
using UnityEngine;

// this script serilizes the data from json file
public class JSONFetch : MonoBehaviour
{
    [System.Serializable] public class Skeletal { public List<Parts> list; }
    [System.Serializable] public class Parts { public string name; public string description; }

    string fileName;
    public Skeletal skeletal = new Skeletal();
    
    private void Awake()
    {
        fileName = Resources.Load("Json/Skeletal").ToString();
        skeletal = JsonUtility.FromJson<Skeletal>(fileName);
    }

    public string GetDescription(string id)
    {
        foreach(var item in skeletal.list)
        {
            if (item.name == id)
            {
                return item.description;
            }
        }
        return null;
    }
}