using UnityEngine;
using AbilitySystem.Authoring;
using PVZ.Player;
using PVZ.Attributes;

namespace PVZ.Plants
{
    public class Sunflower : AttributeDependentBehaviour, IDamagable
    {
        [SerializeField] 
        private float timeBeforeStart = 1f;
        [SerializeField] 
        private float timeBeforeIterations = 1f;

        [Space]

        [SerializeField] 
        private GameplayEffectScriptableObject addPointsEffect;

        private void Start()
        {
            InvokeRepeating(nameof(AddSunPoints), timeBeforeStart, timeBeforeIterations);
        }

        private void AddSunPoints()
            => PlayerController.Instance.ApplyEffect(addPointsEffect);

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