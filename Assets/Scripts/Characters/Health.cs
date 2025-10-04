using System;
using UnityEngine;


public abstract class Health : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private int _maxHealth;
    public int maxHealth { get => _maxHealth; set => _maxHealth = value; }
    private int currentHealth;

    public event Action<int> OnHealthChanged;

    void OnEnable()
    {
        InitHealth();
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
            OnHealthChanged?.Invoke(currentHealth);
        }
    }

    protected void InitHealth()
    {
        currentHealth = maxHealth;
    }

    public abstract void OnDeath();


}
