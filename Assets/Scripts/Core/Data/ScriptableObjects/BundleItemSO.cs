using System;
using UnityEditor;
using UnityEngine;

namespace Game.Core
{
    [CreateAssetMenu(fileName = "BundleItemSO", menuName = "Scriptable Objects/Bundle Item")]
    public class BundleItemSO : ScriptableObject
    {
        public string Description;

        [Space] public MonoScript CostMonoScript;
        public MonoScript RewardMonoScript;

        [Space] public string CostValue;
        public string RewardValue;

        [Space] public string CostAssemblyQualifiedName;
        public string RewardAssemblyQualifiedName;

        private Type _cachedCostType;
        private Type _cachedRewardType;

        public Type CostScriptType
        {
            get
            {
                if (_cachedCostType == null && !string.IsNullOrEmpty(CostAssemblyQualifiedName))
                {
                    _cachedCostType = Type.GetType(CostAssemblyQualifiedName);
                }

                return _cachedCostType;
            }
        }

        private Type RewardScriptType
        {
            get
            {
                if (_cachedRewardType == null && !string.IsNullOrEmpty(RewardAssemblyQualifiedName))
                {
                    _cachedRewardType = Type.GetType(RewardAssemblyQualifiedName);
                }

                return _cachedRewardType;
            }
        }
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (CostMonoScript != null)
            {
                var scriptType = CostMonoScript.GetClass();

                if ((scriptType != null) && scriptType.IsSubclassOf(typeof(MonoBehaviour)))
                {
                    CostAssemblyQualifiedName = scriptType.AssemblyQualifiedName;
                    _cachedCostType =  scriptType;
                }
                else
                {
                    Debug.LogWarning($"Script on {name} is not a MonoBehaviour!");
                    CostMonoScript = null;
                }
            }
            else
            {
                CostAssemblyQualifiedName = string.Empty;
                _cachedCostType = null;
            }

            if (RewardMonoScript != null)
            {
                var scriptType = RewardMonoScript.GetClass();

                if ((scriptType != null) && scriptType.IsSubclassOf(typeof(MonoBehaviour)))
                {
                    RewardAssemblyQualifiedName = scriptType.AssemblyQualifiedName;
                    _cachedRewardType =  scriptType;
                }
                else
                {
                    Debug.LogWarning($"Script on {name} is not a MonoBehaviour!");
                    RewardMonoScript = null;
                }
            }
            else
            {
                RewardAssemblyQualifiedName = string.Empty;
                _cachedRewardType = null;
            }
        }
#endif

        // Add the component to a GameObject at runtime
        public Component AddCostComponentToGameObject(GameObject target)
        {
            if (CostScriptType != null)
            {
                return target.AddComponent(CostScriptType);
            }

            return null;
        }

        public Component AddRewardComponentToGameObject(GameObject target)
        {
            if (RewardScriptType != null)
            {
                return target.AddComponent(RewardScriptType);
            }

            return null;
        }
    }
}
