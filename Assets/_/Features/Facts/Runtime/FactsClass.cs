using UnityEngine;
using System;
namespace Facts.Runtime
{
    public class FactsClass<T> : IFacts
    {
        public T Value;
        object IFacts.Value => Value;
        private bool _isPersistant;
        public bool IsPersistant => _isPersistant;

        public FactsClass(T value, bool isPersistant = false)
        {
            Value = value;
            _isPersistant = isPersistant;
        }
        
        public void GetFact()
        {
            Debug.Log($"Getting fact of type {typeof(T)} with value: {Value}");
        }

        public void SetFact(object value)
        {
            if (value is T typedValue)
            {
                Value = typedValue;
            }
            else
            {
                throw new InvalidCastException($"Cannot cast {value.GetType()} to {typeof(T)}");
            }
        }
        
        
    }
}
