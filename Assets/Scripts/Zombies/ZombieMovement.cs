using System;
using Unity.Mathematics;
using UnityEngine;

namespace PVZ.Zombies
{
    [RequireComponent(typeof(ZombieController), typeof(Rigidbody))]
    public class ZombieMovement : MonoBehaviour
    {
        [HideInInspector]
        public float3 FinishPosition;

        [Range(0.1f, 100f)]
        [SerializeField]
        private float speed = 2.5f;

        private ZombieController _controller;

        private void Awake()
        {
            _controller = GetComponent<ZombieController>();
        }

        private void FixedUpdate()
        {
            if (_controller.State == ZombieState.Move)
                MoveZombie();
        }

        private void MoveZombie()
        {
            var direction = (Vector3)FinishPosition - transform.position;

            var normalizedDirection = direction.normalized;

            var movement = normalizedDirection * speed * Time.fixedDeltaTime;

            if (movement.sqrMagnitude > direction.sqrMagnitude)
                transform.position = FinishPosition;
            else
                transform.position += movement;
        }
    }
}