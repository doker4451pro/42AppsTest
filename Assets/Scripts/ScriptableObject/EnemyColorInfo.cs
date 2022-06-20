using UnityEngine;


[CreateAssetMenu(fileName = "New EnemyColorInfo", menuName = "Enemy Color Info", order = 51)]
public class EnemyColorInfo : ScriptableObject
{
    [SerializeField] private Material _defaltColorMaterial;
    [SerializeField] private Material _highlightColotMateral;

    public Material DefaltColor { get { return _defaltColorMaterial; } }
    public Material HighlightColor { get { return _highlightColotMateral; } }
}
