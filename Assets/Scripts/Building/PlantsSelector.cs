using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace PVZ.Plants
{
    public enum PlantName : byte
    {
        Sunflower,
        Peashooter,
        Chillishooter,
        Mintshooter,
        Ivyshooter,
    }
    public class PlantsSelector : SerializedMonoBehaviour
    {
        public static PlantsSelector Instance {  get; private set; }

        [AssetsOnly]
        [PreviewField]
        [field: SerializeField] public Dictionary<PlantName, GameObject> PlantsLibrary { get; private set; }
        [field: Space]
        [field: SerializeField] public PlantName CurrentPlant { get; private set; } = PlantName.Sunflower;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Debug.LogWarning($"WARNING: {nameof(PlantsSelector)} already has instance!");
        }

        public void SetCurrentPlant(PlantName newPlantName)
            => CurrentPlant = newPlantName;

        public GameObject GetCurrentPlant()
            => PlantsLibrary[CurrentPlant];
    }
}