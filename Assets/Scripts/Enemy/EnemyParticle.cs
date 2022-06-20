using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class EnemyParticle : MonoBehaviour
{
    [SerializeField] private DamagedEnemy enemy;

    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void PlayParticleSystem(Vector3 contactPointPosition)
    {
        _particleSystem.transform.position = contactPointPosition;
        StartCoroutine(PlayParticleCarutine());
    }
    private IEnumerator PlayParticleCarutine() 
    {
        _particleSystem.Play();
        while (_particleSystem.IsAlive())
        {
            yield return null;
        }
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        enemy.OnTakeDamage += PlayParticleSystem;
    }

    private void OnDisable()
    {
        enemy.OnTakeDamage -= PlayParticleSystem;
    }
}
