using AbilitySystem;
using AbilitySystem.Authoring;
using Sirenix.OdinInspector;
using System.Reflection;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private AbilitySystemCharacter abilitySystem;

    [SerializeField] private AbstractAbilityScriptableObject InitAbility;

    [SerializeField] private AbstractAbilityScriptableObject HealthBuffAbility;

    //Init
    private void Awake()
    {
        AbstractAbilitySpec abilitySpec = InitAbility.CreateSpec(abilitySystem);

        StartCoroutine(abilitySpec.TryActivateAbility());
    }
    //Buff activation
    public void BuffHealth()
    {
        AbstractAbilitySpec abilitySpec = HealthBuffAbility.CreateSpec(abilitySystem);

        StartCoroutine(abilitySpec.TryActivateAbility());
    }
}
