using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cube))]
[RequireComponent(typeof(Spawner))]

public class Detonator : MonoBehaviour
{
    private Spawner _spawner;
    private Cube _cube;

    private void Start()
    {
        _cube = GetComponent<Cube>();
        _spawner = GetComponent<Spawner>();
    }

    private void OnMouseUpAsButton()
    {
        Exploid();
    }

    private void Exploid()
    {
        int lowChanseLimit = 0;
        int highChanseLimit = 101;

        if (Random.Range(lowChanseLimit, highChanseLimit) <= _cube.ExploisionChance)
        {
            foreach (Cube cube in _spawner.Spawn())
            {
                cube.Rigidbody.AddForce(Vector3.up * _cube.ExplosionForce);
            }
        }
        else
        {
            foreach(Rigidbody explodableObject in GetExplodableObjects())
            {
                explodableObject.AddExplosionForce(_cube.ExplosionForce, transform.position, _cube.ExplosionRadius);
            }
        }

        Destroy(gameObject);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        List<Rigidbody> explodableObjects = new List<Rigidbody>();

        Collider[] colliders = Physics.OverlapSphere(transform.position, _cube.ExplosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.attachedRigidbody != null)
            {
                explodableObjects.Add(collider.attachedRigidbody);
            }
        }

        return explodableObjects;
    }
}
