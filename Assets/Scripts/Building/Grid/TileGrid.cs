using UnityEngine;
using Unity.Mathematics;
using Sirenix.OdinInspector;

namespace PVZ.Grid
{
    #region Enums
    public enum HorizontalDirection : sbyte
    {
        Left = -1,
        Right = 1,
    }
    public enum VerticalDirection : sbyte
    {
        Up = 1,
        Down = -1,
    }
    #endregion

    public class TileGrid : SerializedMonoBehaviour
    {
        [TabGroup("Grid properties")]
        [SerializeField] public float2 GridOrigin = new float2(0, 0);
#if UNITY_EDITOR
        [Space(10f)]
        [TabGroup("Grid properties")]
        [SerializeField] public Color GridOriginColor = Color.red;
        [Space(10f)]
#endif
        [TabGroup("Grid properties")]
        [Header("Grid size")]
        [MoreThanZero]
        [SerializeField] public int GridHeight = 3;
        [TabGroup("Grid properties")]
        [MoreThanZero]
        [SerializeField] public int GridWidth = 3;
        [TabGroup("Grid properties")]
        [Space(10f)]
        [Header("Directions")]
        [SerializeField] public HorizontalDirection HorizontalDirection = HorizontalDirection.Left;
        [TabGroup("Grid properties")]
        [SerializeField] public VerticalDirection VerticalDirection = VerticalDirection.Up;

        [TabGroup("Tile properties")]
        [MoreThanZero]
        [SerializeField] public float TileSize = 1;
#if UNITY_EDITOR
        [TabGroup("Tile properties")]
        [Space(10f)]
        [SerializeField] public Color EditorTileColor = Color.green;
#endif
        [HideInEditorMode]
        [SerializeField] public Tile[,] Tiles;

        [Button(ButtonHeight = 30, ButtonAlignment = 50f)]
        private void BuildGrid()
        {
            Tiles = new Tile[GridWidth,GridHeight];

            float2 currentPoint = GridOrigin;

            for (int i = 0; i < GridHeight; i++)
            {
                for(int j = 0; j < GridWidth; j++)
                {
                    Tiles[j,i] = new Tile(TileState.Vacant, currentPoint);

                    currentPoint.x += TileSize * (sbyte)HorizontalDirection;
                }

                currentPoint.x = GridOrigin.x;

                currentPoint.y += TileSize * (sbyte)VerticalDirection;
            }
        }
#if UNITY_EDITOR
        #region Gizmos
        private void OnDrawGizmos()
        {
            DrawGridOrigin();

            if (Tiles == null || Tiles.Length == 0)
                return;

            DrawTiles();
        }

        private void DrawGridOrigin()
        {
            Gizmos.color = GridOriginColor;

            var position = new float3(GridOrigin.x, 0, GridOrigin.y);

            Gizmos.DrawCube(position, new Vector3(0.5f, 0.5f, 0.5f));
        }

        private void DrawTiles()
        {
            Gizmos.color = EditorTileColor;

            foreach (var tile in Tiles)
            {
                var position = new float3(tile.TileCenter.x, 0, tile.TileCenter.y);

                float offset = 0.1f;

                Gizmos.DrawCube(position, new Vector3(TileSize - offset, 0.25f, TileSize - offset));
            }
        }
    }
    #endregion
#endif
}