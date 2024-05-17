using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ExplodingCube : MonoBehaviour
{
    private Vector3 _scale;
    private Color _color;

    public ExplodingCube(Vector3 scale)
    {
        _scale = scale;
    }
}
