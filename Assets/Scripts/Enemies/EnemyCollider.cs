using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    private Health enemyHealth;

    private void Awake()
    {
        enemyHealth = GetComponent<Health>();
    }

    public void EnemyTakeDamage()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }
}
