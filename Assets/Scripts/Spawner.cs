using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cube))]

public class Spawner : MonoBehaviour
{
    private Cube _cubePrefab;

    private List<Cube> _cubeList;

    private void Start()
    {
        _cubeList = new List<Cube>();
        _cubePrefab = GetComponent<Cube>();
    }

    public List<Cube> Spawn()
    {
        int lowRandomLimit = 2;
        int highRandomLimit = 7;
        int numberOfCubes = Random.Range(lowRandomLimit, highRandomLimit);

        float chanceFactor = 0.5f;
        float scaleFactor = 0.5f;

        for (int i = 0; i < numberOfCubes; i++)
        {
            Cube newCube = Instantiate(_cubePrefab);

            newCube.Initialize(scaleFactor, _cubePrefab.ExploisionChance, chanceFactor);

            _cubeList.Add(newCube);
        }

        return _cubeList;
    }
}
