using System.Collections;
using UnityEngine;

public class SpawnCubes : ObjectPool
{
    [SerializeField] private Collider _spawnTerritory;
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] protected Vector3 _scaleCube;
    [SerializeField] private int _delaySpawn;

    private Vector3 _spawnBound;
    private Transform _transform;

    private Coroutine _spawnCoroutine;
    private WaitForSeconds _waitForSeconds;

    private int _countObject;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_delaySpawn);
        _spawnBound = _spawnTerritory.bounds.extents;
        _transform = transform;
    }

    private void Start()
    {
        Initialaze(_cubePrefab.gameObject);
        Spawn();
    }

    private void Spawn()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
        }

        _spawnCoroutine = StartCoroutine(DelaySpawnOre());
    }

    private IEnumerator DelaySpawnOre()
    {
        while (true)
        {
            SpawnCube(GetSpawtPosition());

            yield return _waitForSeconds;
        }
    }

    private void SpawnCube(Vector3 spawtPosition)
    {
        if (TryGetObject(out GameObject cube))
        { 
            cube.SetActive(true);
            cube.transform.localScale = _scaleCube;
            cube.transform.position = GetSpawtPosition();

            _countObject++;
            CountElements(_countObject);
        }
        else
        {
            ResetPoll();
        }
    }

    private Vector3 GetSpawtPosition()
    {
        float vectorX = Random.Range(_spawnBound.x, -_spawnBound.x);
        float vectorZ = Random.Range(_spawnBound.z, -_spawnBound.z);

        Vector3 spawtPosition = new Vector3(vectorX, _transform.position.y, vectorZ);

        return spawtPosition;
    }
}
