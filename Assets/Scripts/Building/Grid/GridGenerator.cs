using UnityEngine;
using Unity.Mathematics;
using Sirenix.OdinInspector;

namespace PVZ.Grid
{
    public class GridGenerator : MonoBehaviour
    {
        [TabGroup("Grid properties")]
        [SerializeField] private uint GridWidth;

        [Space]

        [TabGroup("Grid properties")]
        [SerializeField] private uint gridHeight;

        [Space]

        [TabGroup("Grid properties")]
        [SerializeField] private float2 gridOrigin;

        [Space]

        [TabGroup("Tile properties")]
        [AssetsOnly]
        [PreviewField(Alignment = ObjectFieldAlignment.Left, Height = 50f)]
        [SerializeField] private GameObject tilePrefab;

        [Space]

        [TabGroup("Tile properties")]
        [SerializeField] private float tileOffset = 0.1f;

        [Space]

        [TabGroup("Tile properties")]
        [SerializeField] private Material oddTileMaterial;
        [TabGroup("Tile properties")]
        [SerializeField] private Material evenTileMaterial;

        [Button(ButtonAlignment = 50f, ButtonHeight = 25, Style = ButtonStyle.CompactBox)]
        private void GenerateGrid()
        {
            ClearOldTiles();

            var currentPoint = gridOrigin;

            bool isEven = true;

            for (uint i = 0; i < gridHeight; i++)
            {
                for (uint j = 0; j < GridWidth; j++)
                {
                    var tile = Instantiate(tilePrefab, new Vector3(currentPoint.x, 0, currentPoint.y), quaternion.identity, gameObject.transform);

                    tile.GetComponent<MeshRenderer>().material = isEven ? evenTileMaterial : oddTileMaterial;

                    currentPoint.x += tilePrefab.transform.lossyScale.x + tileOffset;

                    isEven = !isEven;
                }

                currentPoint.x = gridOrigin.x;
                currentPoint.y += tilePrefab.transform.lossyScale.z + tileOffset;
            }
        }

        private void ClearOldTiles()
        {
            var children = GetComponentsInChildren<Transform>();

            foreach (var child in children)
            {
                if (child.gameObject.CompareTag(gameObject.tag))
                    continue;

                DestroyImmediate(child.gameObject);
            }
        }
    }
}