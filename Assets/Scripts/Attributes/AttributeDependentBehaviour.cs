using UnityEngine;
using AbilitySystem;
using AbilitySystem.Authoring;
using AttributeSystem.Authoring;
using AttributeSystem.Components;

namespace PVZ.Attributes
{
    [RequireComponent(typeof(AbilitySystemCharacter))]
    public class AttributeDependentBehaviour : MonoBehaviour
    {
        private AbilitySystemCharacter _abilitySystemCharacter;

        private void Awake()
        {
            if (!TryGetComponent(out _abilitySystemCharacter))
#if UNITY_EDITOR
                Debug.LogError($"ERROR: No {nameof(AbilitySystemCharacter)} component was found on {gameObject.name}!");
#endif
        }

        public void ApplyAbility(AbstractAbilityScriptableObject ability)
        {
            AbstractAbilitySpec abilitySpec = ability.CreateSpec(_abilitySystemCharacter);

            StartCoroutine(abilitySpec.TryActivateAbility());
        }

        public void ApplyEffect(GameplayEffectScriptableObject gameplayEffectScriptableObject)
        {
            GameplayEffectSpec spec = _abilitySystemCharacter.MakeOutgoingSpec(gameplayEffectScriptableObject);

            _abilitySystemCharacter.ApplyGameplayEffectSpecToSelf(spec);
        }

        public AttributeValue GetAttributeValue(AttributeScriptableObject attributeScriptableObject)
        {
            _abilitySystemCharacter.AttributeSystem.GetAttributeValue(attributeScriptableObject, out AttributeValue attributeValue);

            return attributeValue;
        }
    }
}