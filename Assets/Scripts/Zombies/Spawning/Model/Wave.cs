using UnityEngine;
using Sirenix.OdinInspector;

namespace PVZ.Zombies
{
    public struct Wave
    {
        [field: BoxGroup(GroupName = "Wave Settings", CenterLabel = true, ShowLabel = true)]
        [field: InlineEditor(InlineEditorModes.GUIAndHeader)]
        [field: SerializeField] 
        public Transform SpawnPoint { get; private set; }

        [field: BoxGroup(GroupName = "Wave Settings", CenterLabel = true, ShowLabel = true)]
        [field: InlineEditor(InlineEditorModes.GUIAndHeader)]
        [field: SerializeField] 
        public Transform FinishPoint {  get; private set; }

        [field: Space(15f)]

        [field: SerializeField]
        [field: InlineEditor(InlineEditorModes.GUIAndHeader)]
        public WaveSettings WaveSettings { get; private set; }
    }
}