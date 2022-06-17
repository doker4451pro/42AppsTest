using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputActionReference[] _inputActionsForEnableOnStart;

    private void Start()
    {
        foreach (var item in _inputActionsForEnableOnStart)
        {
            item.action.Enable();
        }
    }
}
