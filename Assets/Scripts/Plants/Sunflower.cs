using UnityEngine;
using AbilitySystem.Authoring;
using PVZ.Player;

namespace PVZ.Plants
{
    public class Sunflower : MonoBehaviour
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
    }
}