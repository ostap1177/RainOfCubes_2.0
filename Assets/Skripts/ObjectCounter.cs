using UnityEngine;

public class ObjectCounter : MonoBehaviour
{
    [SerializeField] SpawnBomb _spawnBomb;
    [SerializeField] SpawnCubes _spawnCubes;
   
    private int _countActiveBomb;
    private int _countActiveCubes;

    public int CountCreatedBomb { get; private set; }
    public int CountCreatedCubes { get; private set; }
    public int CountActiveObject { get; private set; }

    private void OnEnable()
    {
        _spawnBomb.CountedCreate += OnCountedCreateBomb;
        _spawnBomb.CountedActive += OnCountedActiveBomb;

        _spawnCubes.CountedCreate += OnCountedCreateCubes;
        _spawnCubes.CountedActive += OnCountedActiveCubes;
    }

    private void OnDisable()
    {
        _spawnBomb.CountedCreate -= OnCountedCreateBomb;
        _spawnBomb.CountedActive -= OnCountedActiveBomb;

        _spawnCubes.CountedCreate -= OnCountedCreateCubes;
        _spawnCubes.CountedActive -= OnCountedActiveCubes;
    }

    private void OnCountedCreateCubes(int count)
    { 
       CountCreatedCubes = count;
    }

    private void OnCountedCreateBomb(int count)
    {
        CountCreatedBomb = count;
    }

    private void OnCountedActiveBomb(int count)
    {
        _countActiveBomb = count;
        CountedActiveObject();
    }

    private void OnCountedActiveCubes(int count)
    { 
        _countActiveCubes = count;
        CountedActiveObject();
    }

    private void CountedActiveObject()
    { 
        CountActiveObject = _countActiveCubes + _countActiveBomb;
    }

}
