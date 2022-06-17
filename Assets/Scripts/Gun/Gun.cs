using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class Gun : MonoBehaviour
{
    [Inject] private ObjectPooler _objectPooler;
    [SerializeField] private InputActionReference _shootAction;

    private void Start()
    {
        _shootAction.action.started += Shoot;
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        var bullet = _objectPooler.GetObject<PlayerBullet>();
        bullet.SetBuletToStartPosition(transform);
        bullet.Shoot(transform.forward);
    }
}
