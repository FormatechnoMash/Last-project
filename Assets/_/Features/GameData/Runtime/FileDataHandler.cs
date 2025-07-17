using UnityEngine;
using System;
using System.IO;
namespace GameData.Runtime
{
    public class FileDataHandler
    {
        private string dataDirPath = "";
        
        private string dataFileName = "";

        public FileDataHandler(string dataDirPath, string dataFileName)
        {
            this.dataDirPath = dataDirPath;
            this.dataFileName = dataFileName;
        }

        // public Data Load()
        // {
        //     
        // }

        public void Save()
        {
            
        }
    }
}
