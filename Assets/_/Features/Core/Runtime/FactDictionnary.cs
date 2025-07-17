using System;
using System.Collections.Generic;
using Core.Runtime.Interfaces;

namespace Core.Runtime
{
    public class FactDictionnary
    {
        #region Publics

        public Dictionary<string, IFact> AllFacts => _facts;
        private Dictionary<string, IFact> _facts => new Dictionary<string, IFact>();
        
        #endregion
        
        #region Main API
        public bool FactExists<T>(string key, out T value)
        {
            if (_facts.TryGetValue(key, out var fact) && fact is Fact<T> typedFact)
            {
                value = typedFact.Value;
                return true;
            }
            
            value = default;
            return false;
        }

        public void SetFact<T>(string key, T value, BaseMonobehaviour.FactPersistence persistence)
        {
            if (_facts.TryGetValue(key, out var existingFact))
            {
                if (existingFact is Fact<T> typedFact)
                {
                    typedFact.Value = value;
                    typedFact.IsPersistent = persistence == BaseMonobehaviour.FactPersistence.Persistent;
                }
                else
                {
                    throw new InvalidCastException("Fact exists but is a wrong type");
                }
            }
            else
            {
                bool isPersistent = persistence == BaseMonobehaviour.FactPersistence.Persistent;
                _facts[key] = new Fact<T>(value, isPersistent);
            }
        }

        public T GetFact<T>(string key)
        {
            if (!_facts.TryGetValue(key, out var fact))
            {
                throw new KeyNotFoundException($"Fact {key} does not exist");
            }

            if (_facts[key] is not Fact<T> typedFact)
            {
                throw new InvalidCastException($"Fact {key} is not of type {typeof(T)}");
            }
            
            return typedFact.Value;
        }

        public void RemoveFact<T>(string key)
        {
            _facts.Remove(key);
        }
        
        #endregion
    }
}