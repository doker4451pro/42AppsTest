using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private InputActionReference _moveAction;
    [SerializeField, Range(0,100)] private float _speed=10f;

    private Rigidbody _rigidbody;
    private Vector3 _move;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var moveV2 = _moveAction.action.ReadValue<Vector2>();
        _move = transform.right * moveV2.x + transform.forward * moveV2.y;
        _move *= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position+ _move * _speed);
    }
}
