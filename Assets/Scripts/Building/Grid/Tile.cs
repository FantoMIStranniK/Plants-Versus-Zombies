using System;
using Unity.Mathematics;

namespace PVZ.Grid
{
    public enum TileState : sbyte
    {
        Occupied = 1,
        Vacant = 0,
    }

    [Serializable]
    public struct Tile
    {
        public TileState State;

        public float2 TileCenter;

        public Tile(TileState state, float2 tileCenter)
        {
            State = state;
            TileCenter = tileCenter;
        }
    }
}