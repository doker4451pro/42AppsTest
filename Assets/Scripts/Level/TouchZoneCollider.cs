using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Collider))]
public class TouchZoneCollider : MonoBehaviour
{
    public event Action<string> OnPlayerTouchCollider;

    [SerializeField] private LogState _logState;
    [SerializeField] private string _message;
    [Inject] private LevelRepeater _levelRepeater;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMover>() != null)
        {
            OnPlayerTouchCollider.WriteLog(_logState)?.Invoke(_message);
            _levelRepeater.RepeatLevel();
        }
    }
}
