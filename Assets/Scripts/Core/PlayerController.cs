using UnityEngine;
using PVZ.Attributes;

namespace PVZ.Player
{
    public class PlayerController : AttributeDependentBehaviour, IInstance
    {
        public static PlayerController Instance { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            CreateInstance();
        }

        public void CreateInstance()
        {
            if (Instance == null)
                Instance = this;
            else
#if UNITY_EDITOR
                Debug.LogWarning($"WARNING: {GetType().Name} already has an instance!");
#endif
        }
    }
}