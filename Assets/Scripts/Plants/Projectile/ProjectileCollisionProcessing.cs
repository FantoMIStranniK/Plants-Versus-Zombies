using UnityEngine;

public class ProjectileCollisionProcessing : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        DamageZombie(collision.gameObject);
    }

    private void DamageZombie(GameObject zombie)
    {

    }
}
