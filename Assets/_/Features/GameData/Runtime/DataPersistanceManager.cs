using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace GameData.Runtime
{
    public class DataPersistanceManager : MonoBehaviour
    {
        private List<iDataPersistance> dataPersistenceObjects;
        private Data GameData;
        public static DataPersistanceManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("DataPersistanceManager already exists."); 
            }
            Instance = this;
        }

        private void Start()
        {
            this.dataPersistenceObjects = FindAllDataPersistenceObjects();
            LoadGame();
        }

        public void NewGame()
        {
            this.GameData = new Data();
        }

        

        public void LoadGame()
        {
             //Load any saved data from a file using the data handler
                                //if no data can be loaded, initialize to a new game
            if (this.GameData == null)
            {
                Debug.Log("No data was found Initializing data to default ");
                NewGame();
            }
             //push  loaded data to all other scripts that need it
             foreach (iDataPersistance dataPersistanceObj in dataPersistenceObjects)
             {
                    dataPersistanceObj.LoadData(GameData);
             }
             Debug.Log(" Your coord are " + this.GameData.m_position.x + " and " + this.GameData.m_position.y + " ");
        }

        public void SaveGame()
                {
                    //pass the data to other scripts so they can update it
                    foreach (iDataPersistance dataPersistanceObj in dataPersistenceObjects)
                    {
                        dataPersistanceObj.SaveData(ref GameData);
                    }
                   //save that data to a file using the data handler
                    
                   Debug.Log("Saved coord " + this.GameData.m_position.x + " and " + this.GameData.m_position.y + " ");
                }
        
        private void OnApplicationQuit()
        {
            SaveGame();
        }

        private List<iDataPersistance> FindAllDataPersistenceObjects()
        {
            IEnumerable<iDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<iDataPersistance>();
            
            return new List<iDataPersistance>(dataPersistanceObjects);
        }
    }
}
