using UnityEngine;
using PVZ.Attributes;

namespace PVZ.Player
{
    public class PlayerController : AttributeDependentBehaviour, IInstance
    {
        public static PlayerController Instance { get; private set; }

        private void Start()
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
    }
}