using System;

namespace Core.Runtime.Interfaces
{
    public class Fact<T> : IFact
    {
        public T Value;
        private object _getObjectValue;
        public Type ValueType => typeof(T);
        object IFact.GetObjectValue => _getObjectValue; 
        public Fact(T value, bool isPersistent = false)
        {
            Value = value;
            IsPersistent = isPersistent;
        }
        
        public object GetObjectValue() => Value;

        public void SetObjectValue(object value)
        {
            if (value is T cast)
            {
                Value = cast;
            }
            else
            {
                throw new InvalidCastException("Cannot asign a value to a fact");
            }
        }

        public bool IsPersistent { get; set; }
    }
}