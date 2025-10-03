using UnityEngine;

public class PlayerHealth : Health
{
    
    public override void OnDeath()
    {
        gameObject.SetActive(false);
        Debug.Log("Player has died.");
    }

 
}
