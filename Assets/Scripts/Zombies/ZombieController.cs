using UnityEngine;

namespace PVZ.Zombies
{
    public enum ZombieState : sbyte
    {
        Move,
        Attack,
    }

    public class ZombieController : MonoBehaviour
    {
        [field: SerializeField]
        public ZombieState State { get; private set; } = ZombieState.Move;

        [field: SerializeField]
        public float AttackDistance { get; private set; } = 1f;

        [field: SerializeField]
        public LayerMask PlantLayerMask { get; private set; }

        private void Update()
        {
            TryChangeState();
        }

        private void TryChangeState()
        {
            if (Physics.Raycast(transform.position, -transform.right, out RaycastHit hit, AttackDistance, PlantLayerMask))
                State = ZombieState.Attack;
            else
                State = ZombieState.Move;
        }
    }
}