using UnityEngine;

namespace PVZ.Plants
{
    [RequireComponent(typeof(Rigidbody))]
    public class ProjectileMovement : MonoBehaviour
    {
        [SerializeField]
        private float projectileSpeed = 5f;
        [SerializeField]
        private float maxDistance = 100f;

        private float _spawnTime;

        private void Awake()
        {
            _spawnTime = Time.time;
        }

        private void FixedUpdate()
        {
            MoveProjectile();
        }

        private void MoveProjectile()
        {
            var normalizedDirection = transform.forward.normalized;

            var movement = normalizedDirection * projectileSpeed * Time.fixedDeltaTime;

            transform.position += movement;

            if (Time.fixedTime - _spawnTime > maxDistance / projectileSpeed)
                Destroy(gameObject);
        }
    }
}