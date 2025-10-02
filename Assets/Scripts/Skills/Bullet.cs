using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private int bulletDamage;

    public int BulletDamage { get => bulletDamage; set => bulletDamage = value; }

    private void OnEnable()
    {
        StartCoroutine(DisableAfterTime());
    }

    private IEnumerator DisableAfterTime()
    {
        yield return new WaitForSeconds(2f);
        ObjectPoolingManager.Instance.ReturnObjectToPool(gameObject);
    }
}
