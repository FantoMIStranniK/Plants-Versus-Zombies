using System.Collections.Generic;
using UnityEngine;
using AbilitySystem;
using AbilitySystem.Authoring;
using PVZ.Plants;
using AttributeSystem.Authoring;
using System;
using System.Runtime.InteropServices;

namespace PVZ.Player
{
    [RequireComponent(typeof(AbilitySystemCharacter))]
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance { get; private set; }

        public Action<GameplayEffectScriptableObject, float> OnEffectApplied;
        public Action<AbstractAbilityScriptableObject, float> OnAbilityApplied;

        [SerializeField] private AbstractAbilityScriptableObject startAbilities;

        private AbilitySystemCharacter _abilitySystemCharacter;

        private void Awake()
        {
            _abilitySystemCharacter = GetComponent<AbilitySystemCharacter>();

            CreateInstance();
        }

        private void CreateInstance()
        {
            if(Instance == null)
                Instance = this;
            else
                Debug.LogWarning($"WARNING: {nameof(PlayerController)} already has an instance!");
        }

        private void Start () 
        {
            ApplyAbility(startAbilities);
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

            var attributeValue = spec.SourceCapturedAttribute.Value;

            OnEffectApplied.Invoke(gameplayEffectScriptableObject, attributeValue.CurrentValue);
        }
    }
}