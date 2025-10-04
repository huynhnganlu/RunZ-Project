using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    [Header("Health UI")]
    [SerializeField]
    private Slider healthBar;

    private void OnEnable()
    {
        base.InitHealth();
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
        OnHealthChanged += ChangeHealthBar;
    }

    private void OnDisable()
    {
        OnHealthChanged -= ChangeHealthBar;
    }


    private void ChangeHealthBar(int currentHealth)
    {
        healthBar.value = currentHealth;
    }

    public override void OnDeath()
    {
        ChangeHealthBar(0);
        gameObject.SetActive(false);
        Debug.Log("Player has died.");
    }

 
}
