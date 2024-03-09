using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Unity.VisualScripting;

namespace PVZ.Plants
{
    public enum PlantName : sbyte
    {
        Sunflower,
        Peashooter,
        Chillishooter,
        Mintshooter,
        Ivyshooter,
        Fertilizer,
        Deconstruction,
    }
    public class PlantsSelector : SerializedMonoBehaviour, IInstance
    {
        public static PlantsSelector Instance {  get; private set; }

        [AssetsOnly]
        [PreviewField]
        [field: SerializeField] public Dictionary<PlantName, PlantShopInfoSO> PlantsLibrary { get; private set; }
        [field: Space]
        [field: SerializeField] public PlantName CurrentPlant { get; private set; } = PlantName.Sunflower;

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

        public void SetCurrentPlant(PlantName plantName)
        {
            CurrentPlant = plantName;
            Debug.Log(plantName);
        }

        public PlantShopInfoSO GetCurrentPlantInfo()
            => PlantsLibrary[CurrentPlant];

        public IList<PlantShopInfoSO> GetValues()
            => PlantsLibrary.Values.AsReadOnlyList();
    }
}