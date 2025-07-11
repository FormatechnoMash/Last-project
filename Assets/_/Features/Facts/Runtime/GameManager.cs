using UnityEngine;

namespace Facts.Runtime
{
    public class GameManager 
    {

        #region Publics
        private static FactsDictionnary _gameFact;
        public static FactsDictionnary m_gameFacts
        
        
        {
            get
            {
                if(_gameFact !=null) return _gameFact;
                GameObject go = new GameObject("GameFacts");
                _gameFact = go.AddComponent<FactsDictionnary>();
                return _gameFact;
            }
        }
        
        
        
        

        #endregion
    }
}
