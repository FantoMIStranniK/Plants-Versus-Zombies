using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Mathematics;
using Sirenix.OdinInspector;
using AttributeSystem.Authoring;
using AbilitySystem.Authoring;
using PVZ.Grid;
using PVZ.Player;
using PVZ.Plants;

namespace PVZ.Building
{
    public class BuildingSystem : SerializedMonoBehaviour
    {
        [SerializeField] 
        private InputActionAsset controls;

        [Space]

        [SerializeField] 
        private LayerMask gridLayer;

        [Space]

        [SerializeField] 
        private AttributeScriptableObject moneyAttribute;

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
                CheckTowerRequirments(hit);
        }

        private void CheckTowerRequirments(RaycastHit hit)
        {
            var hitGameobject = hit.collider.gameObject;

            if (!hitGameobject.TryGetComponent(out Tile tileComponent))
                return;

            if (tileComponent.State != TileState.Vacant)
                return;

            var plantInfo = PlantsSelector.Instance.GetCurrentPlantInfo();

            var moneyInfo = PlayerController.Instance.GetAttributeValue(moneyAttribute);

            var cost = -plantInfo.Cost.gameplayEffect.Modifiers[0].Multiplier;

            if (moneyInfo.CurrentValue < cost)
                return;

            ApplyMoneySubtractEffect(plantInfo.Cost);

            BuildTower(tileComponent, plantInfo.Prefab);
        }

        private void ApplyMoneySubtractEffect(GameplayEffectScriptableObject costEffect)
            => PlayerController.Instance.ApplyEffect(costEffect);

        private void BuildTower(Tile tileComponent, GameObject plantPrefab)
        {
            var plant = Instantiate(plantPrefab, tileComponent.transform.position, quaternion.identity);

            tileComponent.SetPlant(plant);
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