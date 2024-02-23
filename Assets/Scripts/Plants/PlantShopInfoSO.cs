using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace PVZ.Plants
{
    [CreateAssetMenu(fileName = "PlantShopInfo", menuName = "Plants SO")]
    [Serializable]
    public class PlantShopInfoSO : ScriptableObject
    {
        public PlantName Name;

        [AssetsOnly]
        public GameObject Prefab;
        public int Cost;
    }
}

