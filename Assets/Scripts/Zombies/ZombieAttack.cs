using UnityEngine;
using AbilitySystem.Authoring;

namespace PVZ.Zombies
{
    public class ZombieAttack : MonoBehaviour
    {
        [SerializeField] 
        private GameplayEffectScriptableObject attackEffect;

        [SerializeField] 
        private float attackDelay;

        private ZombieController controller;

        private float attackTime;

        private void Awake()
        {
            controller = GetComponent<ZombieController>();
        }

        private void Update()
        {
            TryAttack();
        }

        private void TryAttack()
        {
            if (controller.State != ZombieState.Attack)
                return;

            attackTime += Time.deltaTime;

            if (attackDelay > attackTime)
                return;

            attackTime = 0;

            if (Physics.Raycast(transform.position, -transform.right, out RaycastHit hit, controller.AttackDistance, controller.PlantLayerMask))
            {
                IDamagable damagable = hit.collider.GetComponent<IDamagable>();

                if (damagable is null)
                    return;

                damagable.Damage(attackEffect);
            }
        }
    }
}