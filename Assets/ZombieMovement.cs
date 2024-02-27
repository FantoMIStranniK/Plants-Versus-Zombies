using System;
using Unity.Mathematics;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    [HideInInspector]
    public float3 FinishPosition;

    [Range(0.1f, 100f)]
    [SerializeField] 
    private float speed = 2.5f;

    private Rigidbody rb;

    private void Awake()
    {
        TryGetComponent(out rb);
    }

    private void FixedUpdate()
    {
        MoveZombie();
    }

    private void MoveZombie()
    {
        float calculatedSpeed = Time.fixedDeltaTime * speed;

        var newPosition = Vector3.MoveTowards(transform.position, FinishPosition, calculatedSpeed);

        rb.MovePosition(newPosition);
    }
}
