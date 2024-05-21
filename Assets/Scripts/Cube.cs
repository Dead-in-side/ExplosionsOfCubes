using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    private const string ColorShader = "_Color";

    private Renderer _renderer;
    private Color _color;

    public float ExploisionChance { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    public float ExplosionForce {  get; private set; }
    public float ExplosionRadius {  get; private set; }

    private void Awake()
    {
        ExploisionChance = 100f;
        _renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();
        ExplosionForce = 400f;
        ExplosionRadius = 2.0f;
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

    public void SetExplosionOptions(float parentExplosionForce, float parentExplosionRadius, float explosionFactor)
    {
        ExplosionForce = parentExplosionForce*explosionFactor;
        ExplosionRadius = parentExplosionRadius*explosionFactor;
    }

    private void ChangeColor()
    {
        float lowRandomLimit = 0;
        float highRandomLimit = 1;

        float redComponent = Random.Range(lowRandomLimit, highRandomLimit);
        float greenComponent = Random.Range(lowRandomLimit, highRandomLimit);
        float blueComponent = Random.Range(lowRandomLimit, highRandomLimit);

        _color = new Color(redComponent, greenComponent, blueComponent);

        _renderer.material.SetColor(ColorShader, _color);
    }
}
