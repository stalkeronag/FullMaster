using System;
using System.Collections.Generic;
using System.Collections;
using System.Xml.Serialization;
using UnityEngine;

namespace SystemSave
{
    [System.Serializable]
    public class SaveEvents
    {
        public SaveSystem saveSystem;
        public event Action<ISaveable> onSave;
        public event Action<ISaveable> onLoad;
        public event Action<ISaveable> onDestroy;
        public SaveEvents(SaveSystem save)
        {
            onDestroy += RequestDelete;
            onSave += RequestSave;
            saveSystem = save;
        }
        public void RequestDelete(ISaveable saveable)
        {
            saveSystem.saveables.Remove(saveable);
        }
        public void RequestSave(ISaveable saveable)
        {
            for(int i = 0; i < saveSystem.saveables.Count; i++)
            {
                if(saveSystem.saveables[i].key == saveable.key)
                {
                    saveSystem.saveables.Remove(saveable);
                }
            }
            saveSystem.AddSaveble(saveable);
        }
    }
}

