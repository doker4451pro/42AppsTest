using UnityEngine;

public class ColorEnemy : MonoBehaviour
{
    [SerializeField] private EnemyColorInfo _colorInfo;
    [SerializeField] private MeshRenderer _meshRenderer;

    private bool _isHighlightNow;

    private bool IsHighlightNow
    {
        set 
        {
            if (_isHighlightNow != value)
            {
                _isHighlightNow = value;
                _meshRenderer.material = _isHighlightNow ? _colorInfo.HighlightColor : _colorInfo.DefaltColor;
            }
        }
    }

    public void TakeAim(bool flag) 
    {
        IsHighlightNow = flag;
    }
}
