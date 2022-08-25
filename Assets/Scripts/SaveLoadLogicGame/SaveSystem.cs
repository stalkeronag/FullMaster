using System;
using System.Collections.Generic;
using System.Collections;
using System.Xml.Serialization;
using UnityEngine;
public interface ISaveable
{
    public int key { get; set; }
    public void Save();
    public void Load();
}
namespace SystemSave

{
    [System.Serializable]
    public class SaveSystem
    {
        public List<ISaveable> saveables;
        private string path;
        public SaveSystem()
        {
            saveables = new List<ISaveable>();
            path = Application.dataPath + "/Saves/SavedData";
        }
        public void AddSaveble(ISaveable saveItem)
        {
            saveables.Add(saveItem);
        }
        public void DoSave()
        {
            foreach (var item in saveables)
            {
                item.Save();
            }
        }
        public void LoadSaveable()
        {
            foreach (var item in saveables)
            {
                item.Load();
            }
        }
    }
}

