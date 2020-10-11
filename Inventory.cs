using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public Item[] items;

    void OnEnable()
    {
        const string fileName = "InventorySaveData.txt";
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        if(File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(json, this);
        }
        else
        {
            string json = JsonUtility.ToJson(this);
            File.WriteAllText(filePath, json);
        }
    }
}
