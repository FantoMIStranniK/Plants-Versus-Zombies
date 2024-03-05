using UnityEngine;
using AbilitySystem;
using AbilitySystem.Authoring;

namespace PVZ.Attributes
{
    public class AttributesInitializer : MonoBehaviour
    {
        [SerializeField] 
        private AbstractAbilityScriptableObject attributesToInitialize;

        private void Awake()
        {
            InitAttributes();
        }

        private void InitAttributes()
        {
            if (!TryGetComponent(out AbilitySystemCharacter abilitySystemCharacter))
            {
#if UNITY_EDITOR
                Debug.LogError($"Failed to get {nameof(AbilitySystemCharacter)} as component in {name}!");
#endif
                return;
            }

            AbstractAbilitySpec abilitySpec = attributesToInitialize.CreateSpec(abilitySystemCharacter);

            StartCoroutine(abilitySpec.TryActivateAbility());
        }
    }
}