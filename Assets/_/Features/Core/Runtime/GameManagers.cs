namespace Core.Runtime
{
    public class GameManager
    {

        #region Publics

        public static FactDictionnary m_gameFacts
        {
            get
            {
                if (_gameFacts == null)
                {
                    _gameFacts = new FactDictionnary();
                    return _gameFacts;
                }
                return _gameFacts;
            }
        }

        #endregion


        #region Unity API

        //

        #endregion


        #region Main Methods

        // 

        #endregion


        #region Utils

        /* Fonctions privées utiles */

        #endregion


        #region Privates and Protected

        private static FactDictionnary _gameFacts;

        #endregion
    }
}