using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField,Range(0,100)] private float _speed;

    [SerializeField] private CheakTransforms _cheakLeftTransforms;
    [SerializeField] private CheakTransforms _cheakRigntTransforms;
    [SerializeField] private LayerMask _levelLayerMask;

    private bool _moveToLeftNow = false;

    private void Update()
    {
        var cheakTransform = _moveToLeftNow ? _cheakLeftTransforms : _cheakRigntTransforms;
        if (CanMove(cheakTransform))
        {
            var coef = _moveToLeftNow ? -1 : 1;
            transform.Translate(transform.right * _speed * Time.deltaTime * coef);
        }
        else 
        {
            _moveToLeftNow = !_moveToLeftNow;
        }
    }

    private bool CanMove(CheakTransforms cheakTransforms) =>
        Physics.CheckSphere(cheakTransforms.CheakGround.position, 0.1f, _levelLayerMask) && !Physics.CheckSphere(cheakTransforms.CheakWall.position, 0.1f, _levelLayerMask);

    #region SerializableClass
    [System.Serializable]
    private class CheakTransforms 
    {
        public Transform CheakWall;
        public Transform CheakGround;
    }

    #endregion
}
