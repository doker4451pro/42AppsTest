using UnityEngine;

public class Searcher : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private float _halfWidth => Screen.width / 2;
    private float _halfHeight => Screen.height / 2;

    public T GetObjectFront<T>(LayerMask layerMask) where T : class
    {
        var rayPosition = new Vector3(_halfWidth, _halfHeight, 0);
        var ray = _camera.ScreenPointToRay(rayPosition);

        RaycastHit hit;
        Physics.Raycast(ray, out hit,layerMask);

        if (hit.collider != null)
        {
            var foundObject = hit.collider.GetComponent<T>();
            return foundObject;

        }
        return null;
    }
}
