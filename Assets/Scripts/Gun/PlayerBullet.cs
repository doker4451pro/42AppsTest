using UnityEngine;

public class PlayerBullet : BulletBase
{
    protected override void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<DamagedEnemy>()?.TakeDamage(collision.contacts[0]);
        base.OnCollisionEnter(collision);
    }
}
