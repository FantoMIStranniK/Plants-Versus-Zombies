using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace PVZ.Zombies
{
    [CreateAssetMenu(fileName = "WaveSettings", menuName = "PVZ/Zombies/WaveSettings")]
    public class WaveSettings : SerializedScriptableObject
    {
        [field: BoxGroup(GroupName = "Wave Settings", CenterLabel = true, ShowLabel = true)]
        [field: SerializeField]
        public Queue<WaveSegment> Wave { get; private set; }
    }
}