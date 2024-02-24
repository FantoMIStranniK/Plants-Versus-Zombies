using UnityEngine;
using Sirenix.OdinInspector;
using AbilitySystem.Authoring;

namespace PVZ.Plants
{
    [CreateAssetMenu(fileName = "PlantShopInfo", menuName = "PVZ/Plants/Plant Shop Info")]
    public class PlantShopInfoSO : SerializedScriptableObject
    {
        [field: Space(height: 15)]

        [field: SerializeField]
        public PlantName Name {  get; private set; }

        [field: Space(height: 25)]

        [field: AssetsOnly]
        [field: PreviewField(Alignment = ObjectFieldAlignment.Left, Height = 100f)]
        [field: SerializeField]
        public GameObject Prefab { get; private set; }

        [field: Space(height: 25)]

        [field: InlineEditor(InlineEditorModes.GUIOnly, PreviewAlignment = PreviewAlignment.Left)]
        [field: SerializeField]
        public GameplayEffectScriptableObject Cost { get; private set; }
    }
}

