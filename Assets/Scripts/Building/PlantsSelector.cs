using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using PVZ.UI;
using Unity.VisualScripting;

namespace PVZ.Plants
{
    public enum PlantName : sbyte
    {
        Deconstruction,
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
        [field: SerializeField] public Dictionary<PlantName, PlantShopInfoSO> PlantsLibrary { get; private set; }
        [field: Space]
        [field: SerializeField] public PlantName CurrentPlant { get; private set; } = PlantName.Sunflower;

        private void Awake()
        {
            CreateInstance();
        }

        private void CreateInstance()
        {
            if (Instance == null)
                Instance = this;
            else
                Debug.LogWarning($"WARNING: {nameof(PlantsSelector)} already has an instance!");
        }

        public void SetCurrentPlant(PlantName plantName)
        {
            CurrentPlant = plantName;
            Debug.Log(plantName);
        }

        public GameObject GetCurrentPlant()
            => PlantsLibrary[CurrentPlant].Prefab;

        public IList<PlantShopInfoSO> GetValues()
            => PlantsLibrary.Values.AsReadOnlyList();
    }
}