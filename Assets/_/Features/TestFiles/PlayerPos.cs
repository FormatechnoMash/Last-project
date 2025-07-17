using UnityEngine;
using GameData.Runtime;
namespace TestFiles.Runtime
{
    public class PlayerPos : MonoBehaviour, iDataPersistance
    {
        #region Unity API
        void Start()
        {
        
        }
        
        void Update()
        {
        _myPosition=transform.position;
        }
        #endregion
        
        #region Utils

        public void LoadData(Data data)
        {
            this._myPosition = data.m_position;
        }

        public void SaveData(ref Data data)
        {
            data.m_position = this._myPosition;
        }
        #endregion
        
        #region private

        private Vector3 _myPosition;

        #endregion
    }
}
