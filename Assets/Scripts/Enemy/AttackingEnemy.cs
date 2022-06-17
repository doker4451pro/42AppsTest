using System.Collections;
using UnityEngine;
using Zenject;

public class AttackingEnemy : MonoBehaviour
{
    [SerializeField] private float _attackPeriod;
    [SerializeField] private float _attackRadius;
    [SerializeField] private LayerMask _playerLayerMask;

    [SerializeField] private Transform _startBullet;

    [Inject] ObjectPooler _objectPooler;

    private Transform _player;

    private void Start()
    {
        StartCoroutine(SearchPlayer());
    }

    private IEnumerator SearchPlayer() 
    {
        _player=GetPlayerToShoot();

        while (_player==null) 
        {
            yield return null;
            _player = GetPlayerToShoot();
        }

        StartCoroutine(AtackPlayer());
    }

    private IEnumerator AtackPlayer() 
    {
        while (_player!=null) 
        {
            ShotPlayer();
            yield return new WaitForSeconds(_attackPeriod);
            _player = GetPlayerToShoot();
        }

        StartCoroutine(SearchPlayer());
    }

    private Transform GetPlayerToShoot() 
    {
        var colliders = Physics.OverlapSphere(transform.position, _attackRadius, _playerLayerMask);

        if (CanShoot(colliders)) 
        {
            return colliders[0].transform;
        }
        return null;
    }

    private void ShotPlayer() 
    {
        Debug.Log("Shoot");
        var bullet = _objectPooler.GetObject<EnemyBullet>();
        bullet.SetBuletToStartPosition(_startBullet);
        bullet.Shoot(_startBullet.position,_player.position);
    }

    private bool CanShoot(Collider[] colliders) 
    {
        return colliders.Length != 0 && !Physics.Linecast(transform.position, colliders[0].transform.position, ~_playerLayerMask);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _attackRadius);
    }
#endif
}
