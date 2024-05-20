using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    private static string s_colorShader = "_Color";

    private Renderer _renderer;
    private Color _color;

    public float ExploisionChance { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        ExploisionChance = 100f;
        _renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        ChangeColor();
    }

    public void Initialize(float scaleFactor, float parentChanceOfExplosion, float chanceFactor)
    {
        transform.localScale *= scaleFactor;
        ExploisionChance = parentChanceOfExplosion * chanceFactor;
    }

    private void ChangeColor()
    {
        float lowRandomLimit = 0;
        float highRandomLimit = 1;

        float redComponent = Random.Range(lowRandomLimit, highRandomLimit);
        float greenComponent = Random.Range(lowRandomLimit, highRandomLimit);
        float blueComponent = Random.Range(lowRandomLimit, highRandomLimit);

        _color = new Color(redComponent, greenComponent, blueComponent);

        _renderer.material.SetColor(s_colorShader, _color);
    }
}
