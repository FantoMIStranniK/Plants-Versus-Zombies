using UnityEngine;
using Sirenix.OdinInspector;

namespace PVZ.Grid
{
    public enum TileState : sbyte
    {
        Vacant = 0,
        Occupied = 1,
    }

    public class Tile : SerializedMonoBehaviour
    {
        [field: SerializeField] public TileState State { get; private set; } = TileState.Vacant;

        [PreviewField(ObjectFieldAlignment.Center)]
        [SceneObjectsOnly]
        [field: Space]
        [field: SerializeField] public GameObject CurrentPlant { get; private set; } = null;

        public void SetPlant(GameObject plant)
        {
            CurrentPlant = plant;

            State = TileState.Occupied;
        }

        public void ClearPlant()
        {
            Destroy(CurrentPlant);

            State = TileState.Occupied;
        }
    }
}