using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    private Renderer _renderer;
    private Color _color;
    
    public float ExploisionChance {  get; private set; }
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

    public void DecreaseScale(float scaleFactor) => transform.localScale *= scaleFactor;

    public void DecreaseChance(float parentChance, float chanceFactor) => ExploisionChance = parentChance * chanceFactor;

    private void ChangeColor()
    {
        int lowRandomLimit = 0;
        int highRandomLimit = 1001;

        float rComponent = Convert.ToSingle(UsedTools.GetRandomNumber(lowRandomLimit, highRandomLimit)) / highRandomLimit;
        float gComponent = Convert.ToSingle(UsedTools.GetRandomNumber(lowRandomLimit, highRandomLimit)) / highRandomLimit;
        float bComponent = Convert.ToSingle(UsedTools.GetRandomNumber(lowRandomLimit, highRandomLimit)) / highRandomLimit;

        _color = new Color(rComponent, gComponent, bComponent);

        _renderer.material.SetColor("_Color", _color);
    }
}
