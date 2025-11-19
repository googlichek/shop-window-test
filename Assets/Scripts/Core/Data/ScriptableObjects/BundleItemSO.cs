using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game.Core
{
    [CreateAssetMenu(fileName = "BundleItemSO", menuName = "Scriptable Objects/Bundle Item")]
    public class BundleItemSO : ScriptableObject
    {
        public string Description;

        [Space]
#if UNITY_EDITOR
        public List<MonoScript> CostMonoScripts;
        public List<MonoScript> RewardMonoScripts;
#endif
        public List<string> CostValues;
        public List<string> RewardValues;

        public List<string> CostAssemblyQualifiedNames;
        public List<string> RewardAssemblyQualifiedNames;

        private List<Type> _cachedCostTypes = new();
        private List<Type> _cachedRewardTypes = new();

        private Type CostScriptType(int index)
        {
            while (_cachedCostTypes.Count <= index)
            {
                _cachedCostTypes.Add(null);
            }

            if (_cachedCostTypes[index] == null && index < CostAssemblyQualifiedNames.Count && !string.IsNullOrEmpty(CostAssemblyQualifiedNames[index]))
            {
                _cachedCostTypes[index] = Type.GetType(CostAssemblyQualifiedNames[index]);
            }

            return _cachedCostTypes[index];
        }

        private Type RewardScriptType(int index)
        {
            while (_cachedRewardTypes.Count <= index)
            {
                _cachedRewardTypes.Add(null);
            }

            if (_cachedRewardTypes[index] == null && index < RewardAssemblyQualifiedNames.Count && !string.IsNullOrEmpty(RewardAssemblyQualifiedNames[index]))
            {
                _cachedRewardTypes[index] = Type.GetType(RewardAssemblyQualifiedNames[index]);
            }

            return _cachedRewardTypes[index];
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            CostAssemblyQualifiedNames.Clear();
            _cachedCostTypes.Clear();
            for (int index = 0; index < CostMonoScripts.Count; index++)
            {
                if (CostMonoScripts[index] != null)
                {
                    var scriptType = CostMonoScripts[index].GetClass();

                    if ((scriptType != null) && scriptType.IsSubclassOf(typeof(MonoBehaviour)))
                    {
                        CostAssemblyQualifiedNames.Add(scriptType.AssemblyQualifiedName);
                        _cachedCostTypes.Add(scriptType);
                    }
                    else
                    {
                        Debug.LogWarning($"Script on {name} is not a MonoBehaviour!");
                        CostMonoScripts.RemoveAt(index);
                    }
                }
            }

            RewardAssemblyQualifiedNames.Clear();
            _cachedRewardTypes.Clear();
            for (int index = 0; index < RewardMonoScripts.Count; index++)
            {
                if (RewardMonoScripts[index] != null)
                {
                    var scriptType = RewardMonoScripts[index].GetClass();

                    if ((scriptType != null) && scriptType.IsSubclassOf(typeof(MonoBehaviour)))
                    {
                        RewardAssemblyQualifiedNames.Add(scriptType.AssemblyQualifiedName);
                        _cachedRewardTypes.Add(scriptType);
                    }
                    else
                    {
                        Debug.LogWarning($"Script on {name} is not a MonoBehaviour!");
                        RewardMonoScripts.RemoveAt(index);
                    }
                }
            }
        }
#endif

        public List<ICost> AddCostComponentsToGameObject(GameObject target)
        {
            List<ICost> components = new();
            for (int index = 0; index < CostValues.Count; index++)
            {
                var scriptType = CostScriptType(index);
                if (scriptType != null)
                {
                    if (target.AddComponent(scriptType) is ICost component)
                    {
                        var value = CostValues[index];
                        component.SetValue(value);
                        components.Add(component);
                    }
                }
            }

            return components;
        }

        public List<IReward> AddRewardComponentsToGameObject(GameObject target)
        {
            List<IReward> components = new();
            for (int index = 0; index < RewardValues.Count; index++)
            {
                var scriptType = RewardScriptType(index);
                if (scriptType != null)
                {
                    if (target.AddComponent(scriptType) is IReward component)
                    {
                        var value = RewardValues[index];
                        component.SetValue(value);
                        components.Add(component);
                    }
                }
            }

            return components;
        }
    }
}
