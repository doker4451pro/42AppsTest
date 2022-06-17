using UnityEngine;

//[RequireComponent(typeof(ParticleSystem))]
public class PlayerBullet : BulletBase
{
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        collision.gameObject.GetComponent<DamagedEnemy>()?.TakeDamage();
    }
}
