using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] 
    private float projectileSpeed = 5f;
    [SerializeField] 
    private float maxDistance = 100f;

    private Rigidbody rb;

    private float _spawnTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        _spawnTime = Time.time;
    }

    private void FixedUpdate()
    {
        MoveProjectile();
    }

    private void MoveProjectile()
    {
        float calculatedSpeed = Time.fixedDeltaTime * projectileSpeed;

        var newPosition = Vector3.MoveTowards(transform.position, transform.position + transform.forward * maxDistance, calculatedSpeed);

        rb.MovePosition(newPosition);

        if (Time.time - _spawnTime > maxDistance / projectileSpeed)
            Destroy(gameObject);
    }
}
