using UnityEngine;
using Sirenix.OdinInspector;

namespace PVZ.Zombies
{
    public struct WaveSegment
    {
        [field: BoxGroup(GroupName = "Wave segment settings", CenterLabel = true, ShowLabel = true)]
        [field: InlineEditor(InlineEditorModes.GUIAndPreview, PreviewHeight = 125f)]
        [field: AssetList(Path = "Prefabs/Zombies/Zombie Units", AutoPopulate = true)]
        [field: SerializeField]
        public GameObject ZombieToSpawn { get; private set; }

        [field: Space(10f)]

        [field: BoxGroup(GroupName = "Wave segment settings", CenterLabel = true, ShowLabel = true)]
        [field: SerializeField] 
        public float DelayAfterSpawn { get; private set; }

        [field: Space(15f)]

        [field: SerializeField]
        public bool DoRandomTime { get; private set; }

        [field: Space(5f)]

        [field: ShowIf(nameof(DoRandomTime), true)]
        [field: SerializeField]
        public float MaxRandomTime { get; private set; }
    }
}