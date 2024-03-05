using AbilitySystem.Authoring;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    private ZombieController controller;
    [SerializeField] private GameplayEffectScriptableObject attackEffect;

    [SerializeField] private float attackDelay;
    private float attackTime;

    private void Awake()
    {
        controller = GetComponent<ZombieController>();
    }

    private void Update()
    {
        if (controller.State != ZombieState.Attack)
            return;

        attackTime += Time.deltaTime;
        
        if (attackDelay > attackTime)
            return;

        attackTime = 0;

        if (Physics.Raycast(transform.position, -transform.right, out RaycastHit hit, controller.AttackDistance, controller.plantLM))
        {
            IDamagable damagable = hit.collider.GetComponent<IDamagable>();

            if (damagable is null)
                return;

            damagable.Damage(attackEffect);
        }
    }
}
