using AbilitySystem.Authoring;
using PVZ.Attributes;

namespace PVZ.Zombies
{
    public class ZombieHealth : AttributeDependentBehaviour, IDamagable
    {
        public void Damage(GameplayEffectScriptableObject damageEffect)
        {
            ApplyEffect(damageEffect);

            var attributeLibrary = AttribiteLibrary.Instance;

            if (!attributeLibrary.TryGetAttribute(new AttributeKey(AttributeSide.General, AttributeType.Health), out var health))
                return;

            var healthValue = GetAttributeValue(health);

            if (healthValue.CurrentValue <= 0)
                Destroy(gameObject);
        }
    }
}