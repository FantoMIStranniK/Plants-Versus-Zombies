using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public ZombieState State;
    public float AttackDistance;

    public LayerMask plantLM;

    private void Update()
    {
        if (Physics.Raycast(transform.position, -transform.right, out RaycastHit hit, AttackDistance, plantLM))
        {
            State = ZombieState.Attack;
        }
        else
        {
            State = ZombieState.Move;
        }
    }
}

public enum ZombieState : byte
{
    Move,
    Attack,
}
