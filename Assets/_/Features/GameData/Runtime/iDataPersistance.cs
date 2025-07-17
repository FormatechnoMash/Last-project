using UnityEngine;

namespace GameData.Runtime
{
    public interface iDataPersistance 
    {
       void LoadData(Data data);
       void SaveData(ref Data data);
       
    }
}
