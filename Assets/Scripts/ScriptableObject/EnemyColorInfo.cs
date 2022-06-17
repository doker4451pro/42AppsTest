using UnityEngine;


[CreateAssetMenu(fileName = "New EnemyColorInfo", menuName = "Enemy Color Info", order = 51)]
public class EnemyColorInfo : ScriptableObject
{
    [SerializeField] private Color _defaltColor = Color.red;
    [SerializeField] private Color _highlightColot = Color.yellow;

    public Color DefaltColor { get { return _defaltColor; } }
    public Color HighlightColor { get { return _highlightColot; } }
}
