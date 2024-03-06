using UnityEngine;
using PVZ;
using AbilitySystem.Authoring;

public class ProjectileCollisionProcessing : MonoBehaviour
{
    [SerializeField]
    private GameplayEffectScriptableObject attackEffect;

    private void OnCollisionEnter(Collision collision)
    {
        DamageZombie(collision.gameObject);
    }

    private void DamageZombie(GameObject zombie)
    {
        print("collision");

        IDamagable damagable = zombie.GetComponent<IDamagable>();

        if (damagable is null)
            return;

        damagable.Damage(attackEffect);

        Destroy(gameObject);
    }
}
