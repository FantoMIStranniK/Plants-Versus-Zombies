using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Mathematics;
using Sirenix.OdinInspector;
using PVZ.Grid;
using PVZ.Plants;

namespace PVZ.Building
{
    public class BuildingSystem : SerializedMonoBehaviour
    {
        [SerializeField] private InputActionAsset controls;
        [Space]
        [SerializeField] private LayerMask gridLayer;

        private void Awake()
        {
            var bind = controls.FindAction("Build");

            bind.performed += ctx => TryBuildTower();
        }

        public void TryBuildTower()
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, math.INFINITY);

            if (Physics.Raycast(ray, out hit, 100f, gridLayer))
            {
                var hitGameobject = hit.collider.gameObject;

                if (!hitGameobject.TryGetComponent(out Tile tileComponent))
                    return;

                if (tileComponent.State != TileState.Vacant)
                    return;

                var plantToCreate = PlantsSelector.Instance.GetCurrentPlant();

                var plant = Instantiate(plantToCreate, tileComponent.transform.position, quaternion.identity);

                tileComponent.SetPlant(plant);
            }
        }

        private void OnEnable()
        {
            controls.Enable();
        }

        private void OnDisable()
        {
            controls.Disable();
        }
    }
}