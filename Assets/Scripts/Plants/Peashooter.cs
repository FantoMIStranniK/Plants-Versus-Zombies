using UnityEngine;
using Sirenix.OdinInspector;
using PVZ.Attributes;

namespace PVZ.Plants
{
    public class Peashooter : AttributeDependentBehaviour
    {
        [AssetsOnly]
        [InlineEditor(InlineEditorModes.GUIAndPreview, PreviewHeight = 250f, PreviewWidth = 75)]
        [SerializeField]
        private GameObject projectile;

        [Space]

        [InlineEditor(InlineEditorModes.GUIOnly)]
        [SerializeField]
        private Transform shootingPoint;

        private void Start()
        {
            Invoke(nameof(StartProjectileSpawnSequence), 1f);
        }

        private void StartProjectileSpawnSequence()
        {
            float speed = GetShootingSpeed();

            float timing = 7.5f / speed;

            Invoke(nameof(CreateProjectile), timing);
        }

        private float GetShootingSpeed()
        {
            var attributeLibrary = AttribiteLibrary.Instance;

            if (!attributeLibrary.TryGetAttribute(new AttributeKey(AttributeSide.General, AttributeType.AttackSpeed), out var speedAttribute))
                return -1f;

            return GetAttributeValue(speedAttribute).CurrentValue;
        }

        private void CreateProjectile()
        {
            Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);

            StartProjectileSpawnSequence();
        }
    }
}