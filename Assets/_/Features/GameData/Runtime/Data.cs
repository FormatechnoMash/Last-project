using UnityEngine;

namespace GameData.Runtime
{
    [System.Serializable]
    public class Data
    {
        public int m_deathCount;
        public Vector3 m_position;
        public Data()
        {
            m_deathCount = 0;
        }
    }
}
