using System;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    [SerializeField] private float _explosionForce;

    private Cube _cubePrefab;

    private void Start()
    {
        _cubePrefab = GetComponent<Cube>();
    }

    private void OnMouseUpAsButton()
    {
        Exploid();
    }

    private void Exploid()
    {
        int lowRandomLimit = 2;
        int highRandomLimit = 7;
        int lowChanseLimit = 0;
        int highChanseLimit = 101;

        float chanceFactor = 0.5f;
        float _scaleFactor = 0.5f;

        if (UsedTools.GetRandomNumber(lowChanseLimit, highChanseLimit) <= _cubePrefab.ExploisionChance)
        {
            for (int i = 0; i < UsedTools.GetRandomNumber(lowRandomLimit, highRandomLimit); i++)
            {
                Cube newCube = Instantiate(_cubePrefab);

                newCube.DecreaseChance(_cubePrefab.ExploisionChance, chanceFactor);

                newCube.DecreaseScale(_scaleFactor);

                newCube.Rigidbody.AddForce(Vector3.up * _explosionForce, ForceMode.Impulse) ;
            }
        }

        Destroy(gameObject);
    }
}
