using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    public event UnityAction<int> CountedCreate;
    public event UnityAction<int> CountedActive;

    private void FixedUpdate()
    {
        CountActiveElements();
    }

    protected void Initialaze(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject cube = Instantiate(prefab.gameObject, _container.transform);
            cube.SetActive(false);

            _pool.Add(cube);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    protected void ResetPoll()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }

    protected void CountElements(int count)
    {
        CountedCreate?.Invoke(count);
    }

    private void CountActiveElements()
    {
        int count = _pool.Count(p => p.activeSelf);

        CountedActive?.Invoke(count);
    }
}
