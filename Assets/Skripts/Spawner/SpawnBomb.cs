using UnityEngine;

public class SpawnBomb : ObjectPool
{
    [SerializeField] private Bomb _bombPrefab;
    [SerializeField] protected Vector3 _scaleBomb;

    private int _countObject;
    private void Start()
    {
        Initialaze(_bombPrefab.gameObject);
    }

    public void SetSpawnPosition(Vector3 position)
    { 
        Spawn(position);
    }

    private void Spawn(Vector3 position)
    {
        if (TryGetObject(out GameObject gameObject))
        {
            gameObject.SetActive(true);
            gameObject.transform.localScale = _scaleBomb;
            gameObject.transform.position = position;

            _countObject++;
            CountElements(_countObject);
        }
        else
        {
            ResetPoll();
        }
    }
}
