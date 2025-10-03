using System;
using UnityEngine;


public abstract class Health : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private int maxHealth;
    private int currentHealth;

    void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth - damage <= 0)
        {
            OnDeath();
        }
        else
        {
            currentHealth -= damage;
        }
    }


    public abstract void OnDeath();


}
