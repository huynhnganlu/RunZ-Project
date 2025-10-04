using UnityEngine;

public class EnemyHealth : Health
{
    
    public override void OnDeath()
    {
        ObjectPoolingManager.Instance.ReturnObjectToPool(gameObject);


    }

  
}
