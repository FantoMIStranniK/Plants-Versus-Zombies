using UnityEngine;
using Unity.Mathematics;

namespace PVZ.Plants
{
    public class ProjectileRotationAnimation : MonoBehaviour
    {
        [SerializeField]
        private float3 rotationSpeed;

        [Space]

        [SerializeField]
        private bool3 rotationAxis;

        private float3 _rotationProgress;

        private void Update()
        {
            RotateProjectile();
        }

        private void RotateProjectile()
        {
            _rotationProgress += Time.deltaTime * (float3)rotationAxis * rotationSpeed;

            transform.rotation = quaternion.Euler(_rotationProgress);
        }
    }
}