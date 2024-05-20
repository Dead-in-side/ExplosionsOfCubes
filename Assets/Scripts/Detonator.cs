using UnityEngine;

[RequireComponent(typeof(Cube))]
[RequireComponent(typeof(Spawner))]

public class Detonator : MonoBehaviour
{
    [SerializeField] private float _explosionForce;

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
                cube.Rigidbody.AddForce(Vector3.up*_explosionForce);
            }
        }

        Destroy(gameObject);
    }
}
