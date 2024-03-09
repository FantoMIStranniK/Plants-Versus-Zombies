using AbilitySystem.Authoring;
using PVZ.Attributes;
using UnityEngine;

namespace PVZ.Plants
{
    public class Fertilizer : AttributeDependentBehaviour
    {
        [SerializeField] private float BuffRadius;
        [SerializeField] private float BuffSpeed;
        private float buffTimer;

        [SerializeField] private GameplayEffectScriptableObject BuffEffect;

        [field: SerializeField]
        public LayerMask PlantLayerMask { get; private set; }

        private void Start()
        {
            
        }

        private void Update()
        {
            buffTimer += Time.deltaTime;

            if (buffTimer > BuffSpeed) 
            {
                var plants = Physics.OverlapSphere(transform.position, BuffRadius, PlantLayerMask);

                foreach (var plant in plants)
                {
                    plant.TryGetComponent(out AttributeDependentBehaviour behaviour);
                    behaviour.ApplyEffect(BuffEffect);
                }

                buffTimer = 0;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, BuffRadius);
        }
    }
}