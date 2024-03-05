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

    private ZombieController controller;

    private void Awake()
    {
        TryGetComponent(out rb);
        controller = GetComponent<ZombieController>();
    }

    private void FixedUpdate()
    {
        if (controller.State != ZombieState.Move)
            return; // maybe later i will make it so it gets new state by an event 

        MoveZombie();
    }

    private void MoveZombie()
    {
        float calculatedSpeed = Time.fixedDeltaTime * speed;

        var newPosition = Vector3.MoveTowards(transform.position, FinishPosition, calculatedSpeed);
        //transform.rotation = Quaternion.LookRotation(newPosition, Vector3.up);

        rb.MovePosition(newPosition);
    }
}
