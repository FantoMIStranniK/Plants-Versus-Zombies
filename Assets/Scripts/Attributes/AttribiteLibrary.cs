using System.Collections.Generic;
using UnityEngine;
using AttributeSystem.Authoring;
using Sirenix.OdinInspector;

namespace PVZ.Attributes
{
    public class AttribiteLibrary : SerializedMonoBehaviour, IInstance
    {
        public static AttribiteLibrary Instance { get; private set; }

        [field: SerializeField]
        public Dictionary<AttributeKey, AttributeScriptableObject> Attributes {  get; private set; } = new Dictionary<AttributeKey, AttributeScriptableObject>();

        private void Awake()
        {
            CreateInstance();
        }

        public void CreateInstance()
        {
            if (Instance == null)
                Instance = this;
            else
                Debug.LogWarning($"WARNING: {GetType().Name} already has an instance!");
        }

        public bool TryGetAttribute(AttributeKey key, out AttributeScriptableObject attributeScriptableObject)
        {
            attributeScriptableObject = null;

            if (!Attributes.ContainsKey(key))
                return false;

            attributeScriptableObject = Attributes[key];

            return true;
        }
    }
}