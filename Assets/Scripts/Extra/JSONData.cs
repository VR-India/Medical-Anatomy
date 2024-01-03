using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class JSONData : MonoBehaviour
{
    [System.Serializable]
    public class Part
    {
        public List<Parts> list;
        //public Parts[] list;
    }

    [System.Serializable]
    public class Parts
    {
        public string name;
        public string description;
    }

    public string fileName = "/RetinalData.json";
    string dataFilePath;

    public AnatomyInformationSO data;

    public Part part;


    private void Awake()
    {
        dataFilePath = Application.dataPath + fileName;
        // part.list = new Parts[data.ds.Count];
    }
    // public string json;
    private void Start()
    {
        foreach(var item in data.anatomyInfos) 
        {
            part.list.Add(new Parts() { name = item.objectName, description = item.objectDescription }) ;
        }

        //for(int i = 0; i < data.ds.Count; i++) 
        //{
        //    part.list[i].name = data.ds[i].objectName;
        //    part.list[i].description = data.ds[i].objectDescription;
        //}

        //foreach (var item in data)
        //{
        //    list.Add(item.ds);
        //}
    }

    //public IEnumerator ExchangeValues()
    //{
    //    //foreach (var part in data.ds) 
    //    //{
    //    //    list.Add(part);
    //    //}

    //    for (int i = 0; i < data.ds.Count; i++)
    //    {
    //        parts[i].name = data.ds[i].objectName;
    //        parts[i].description = data.ds[i].objectDescription;
    //        //json += JsonUtility.ToJson(parts[i]) + "\n\n";
    //    }

    //    string json = JsonUtility.ToJson(parts);

    //    yield return new WaitForSeconds(0.2f);

    //    Debug.Log(json);

    //    File.WriteAllText(dataFilePath, json);
    //}

    //private void Start()
    //{
    //    string json = File.ReadAllText(dataFilePath);


    //    Debug.Log(json);
    //    parts = JsonUtility.FromJson<Parts[]>(json);

    //    foreach (var part in parts)
    //        Debug.Log(part.name);
    //}

    private void OnDisable()
    {
        string json = JsonUtility.ToJson(part);
        File.WriteAllText(dataFilePath, json);
    }
}