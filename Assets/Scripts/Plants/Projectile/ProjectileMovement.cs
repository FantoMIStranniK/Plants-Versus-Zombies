using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 5f;

    [SerializeField] private float maxDistance = 100f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
    }
}
