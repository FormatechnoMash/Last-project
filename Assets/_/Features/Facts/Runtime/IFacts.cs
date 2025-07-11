using UnityEngine;

namespace Facts.Runtime
{
    public interface IFacts
    {
        object Value { get; }
        bool IsPersistant { get;}
        void GetFact();
        void SetFact(object Value);
    }

    
}