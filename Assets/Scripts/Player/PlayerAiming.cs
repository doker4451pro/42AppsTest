using UnityEngine;
using Zenject;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyMask;
    [Inject] Searcher _searcher;

    private ColorEnemy _currentEnemy;

    private void Update()
    {
        var newEnemy= _searcher.GetObjectFront<ColorEnemy>(_enemyMask);
        if (_currentEnemy != newEnemy) 
        {
            _currentEnemy?.TakeAim(false);
            newEnemy?.TakeAim(true);
            _currentEnemy = newEnemy;
        }
    }
}
