using UnityEngine;
using AbilitySystem.Authoring;
using PVZ.Player;
using AbilitySystem;
using AttributeSystem.Components;
using AttributeSystem.Authoring;

namespace PVZ.Plants
{
    public class Sunflower : MonoBehaviour, IDamagable
    {
        [SerializeField] private float timeBeforeStart = 1f;
        [SerializeField] private float timeBeforeIterations = 1f;
        [Space]
        [SerializeField] private GameplayEffectScriptableObject addPointsEffect;

        [SerializeField] private AttributeScriptableObject healthAttributeSO;
        [SerializeField] private AbstractAbilityScriptableObject startAbilities;

        private AbilitySystemCharacter abilitySystemCharacter;
        private AttributeSystemComponent attributeSystem;

        private void Start()
        {
            abilitySystemCharacter = GetComponent<AbilitySystemCharacter>();
            attributeSystem = GetComponent<AttributeSystemComponent>();
            InvokeRepeating(nameof(AddSunPoints), timeBeforeStart, timeBeforeIterations);

            ApplyAbility(startAbilities);
        }

        private void AddSunPoints()
            => PlayerController.Instance.ApplyEffect(addPointsEffect);

        public void Damage(GameplayEffectScriptableObject damageEffect)
        {
            GameplayEffectSpec spec = abilitySystemCharacter.MakeOutgoingSpec(damageEffect);

            abilitySystemCharacter.ApplyGameplayEffectSpecToSelf(spec);

            attributeSystem.GetAttributeValue(healthAttributeSO, out AttributeValue health);
            
            if (health.CurrentValue <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void ApplyAbility(AbstractAbilityScriptableObject ability)
        {
            AbstractAbilitySpec abilitySpec = ability.CreateSpec(abilitySystemCharacter);

            StartCoroutine(abilitySpec.TryActivateAbility());
        }
    }
}

public interface IDamagable
{
    public void Damage(GameplayEffectScriptableObject damageEffect);
}