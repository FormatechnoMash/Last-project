using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Facts.Runtime
{
    public class FactsDictionnary : MonoBehaviour
    {
        #region Variables

        public enum FactPersistence
        {
            Temporary,
            Persistent
        }
        public Dictionary<string, IFacts> AllFacts => _facts;
        private Dictionary<string, IFacts> _facts = new Dictionary<string, IFacts>();
        
        #endregion
        
    #region Main API

    public bool FactExists<T>(string key, out T value)
    {
        if (_facts.TryGetValue(key, out var fact) && fact is FactsClass<T> typedFact)
        {
            value = typedFact.Value;
            return true;
        }
        value = default;
        return false;
    }

    public void RemoveFact(string key)
    {
        _facts.Remove(key);
    }


    public T GetFact<T>(string key)
    {
        if (!_facts.TryGetValue(key, out var fact))
            throw new KeyNotFoundException($"No fact with key: {key}");

        if (fact is FactsClass<T> typedFact)
            return typedFact.Value;
    
        throw new InvalidCastException($"Fact with key '{key}' is not of type {typeof(T)}");
    }

    public void SetFact<T>(string key, T value, FactPersistence persistence)
    {
        if(_facts.TryGetValue(key, out var existingFact))
        {

            if (existingFact is FactsClass<T> typedFact)
            {
                typedFact.Value = value;
            }
            else
            {
             throw new InvalidCastException("Fact exist but with the wrong type");
            }
        }
        else
        {
            bool isPersistant = persistence == FactPersistence.Persistent;
            _facts[key] = new FactsClass<T>(value, isPersistant);
        }
        
    }
    #endregion




    }
}
