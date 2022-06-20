using TMPro;
using UnityEngine;

public class TextOnLevel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private TouchZoneCollider[] touchZoneColliders;

    private void OnEnable()
    {
        foreach (var item in touchZoneColliders)
        {
            item.OnPlayerTouchCollider += ChangeText;
        }
    }
    private void OnDisable()
    {
        foreach (var item in touchZoneColliders)
        {
            item.OnPlayerTouchCollider -= ChangeText;
        }
    }

    private void ChangeText(string obj)
    {
        _textMeshPro.text = obj;
    }
}
