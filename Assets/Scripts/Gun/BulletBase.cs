using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public abstract class BulletBase : MonoBehaviour, IPoolObject
{
    [SerializeField, Range(100, 1000)] private float _speed = 150;
    private Rigidbody _rigidbody;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void GetFromPool()
    {
        gameObject.SetActive(true);
        _rigidbody.isKinematic = false;
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
        _rigidbody.isKinematic = true;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        ReturnToPool();
    }

    public void Shoot(Vector3 from, Vector3 to)
    {
        var direction = to - from;
        _rigidbody.AddForce(direction * _speed);
    }
    public void Shoot(Vector3 from) 
    {
        _rigidbody.AddForce(from * _speed);
    }

    public void SetBuletToStartPosition(Transform start) 
    {
        transform.position = start.position;
        transform.rotation = start.rotation;
    }
}
