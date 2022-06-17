using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class Gun : MonoBehaviour
{
    [Inject] private ObjectPooler _objectPooler;
    [SerializeField] private InputActionReference _shotAction;

    private void Awake()
    {
        _shotAction.action.started += Shot;
    }

    private void Shot(InputAction.CallbackContext obj)
    {
        var bullet=_objectPooler.GetObject<PlayerBullet>();
        bullet.SetBuletToStartPosition(transform);
        bullet.Shoot(transform.forward);
    }
}
