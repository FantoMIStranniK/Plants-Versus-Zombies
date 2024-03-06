using System;
using Unity.Mathematics;
using UnityEngine;

namespace PVZ.Zombies
{
    [RequireComponent(typeof(ZombieController))]
    public class ZombieMovement : MonoBehaviour
    {
        [HideInInspector]
        public float3 FinishPosition;

        [Range(0.1f, 100f)]
        [SerializeField]
        private float speed = 2.5f;

        private Rigidbody _rb;

        private ZombieController _controller;

        private void Awake()
        {
            TryGetComponent(out _rb);

            _controller = GetComponent<ZombieController>();
        }

        private void FixedUpdate()
        {
            if (_controller.State == ZombieState.Move)
                MoveZombie();
        }

        private void MoveZombie()
        {
            float calculatedSpeed = Time.fixedDeltaTime * speed;

            var newPosition = Vector3.MoveTowards(transform.position, FinishPosition, calculatedSpeed);

            _rb.MovePosition(newPosition);
        }
    }
}