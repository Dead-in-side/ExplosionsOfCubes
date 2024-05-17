using UnityEngine;

[RequireComponent(typeof(Camera))]

public class RayCaster : MonoBehaviour
{
    private Camera _camera;
    private Ray _ray;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
    }
}
