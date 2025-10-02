using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Health playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(20); // Adjust damage value as needed
            }
        }
    }
}
