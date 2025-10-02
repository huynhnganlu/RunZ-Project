using UnityEngine;

[CreateAssetMenu(fileName = "ShootBullet", menuName = "Skills/ShootBullet")]
public class ShootBullet : SkillBase
{
    [Header("Bullet Settings")]
    public GameObject bulletPrefab;
    public int bulletDamage;
    public float bulletSpeed;

    public override void Activate(GameObject user)
    {
        SpawnBullet(user.transform, Vector2.right);
    }

    private void SpawnBullet(Transform transform, Vector2 direction)
    {

        // Instantiate the bullet prefab at the user's position and rotation
        GameObject bullet = ObjectPoolingManager.Instance.GetObjectFromPool(bulletPrefab, transform.position + transform.right, transform.rotation);
        if(bullet != null)
        {
            bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * bulletSpeed;
            bullet.GetComponent<Bullet>().BulletDamage = bulletDamage;
        }
    }
}
