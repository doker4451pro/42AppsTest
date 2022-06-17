using UnityEngine;

//[RequireComponent(typeof(ParticleSystem))]
public class PlayerBullet : BulletBase
{
    private ParticleSystem _particleSystem;

    private void Awake()
    {
        //_particleSystem = GetComponent<ParticleSystem>();
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        collision.gameObject.GetComponent<DamagedEnemy>()?.TakeDamage();

        //_particleSystem.Play();
    }
}
