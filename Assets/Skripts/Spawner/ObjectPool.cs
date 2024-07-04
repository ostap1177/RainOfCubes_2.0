using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    //private List<GameObject> _pool = new List<GameObject>();
    private List<T> _pool = new List<T>();

    public event UnityAction<int> CountedCreate;
    public event UnityAction<int> CountedActive;

/*    private void FixedUpdate() 
    {
        CountActiveElements();
    }*/

    protected void Initialaze(T prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            T objectInGame = Instantiate(prefab, _container.transform);
            objectInGame.gameObject.SetActive(false);

            _pool.Add(objectInGame);
        }
    }

    protected bool TryGetObject(out T result)
    {
        result = null;

        foreach(T obj in _pool) 
        {
            if (obj.TryGetComponent<T>(out T entity) && !entity.gameObject.activeInHierarchy)
            {
                result = entity;    
            }
        }

        return result != null;
    }


    /*    protected void Initialaze (T prefab)
        {
            for (int i = 0; i < _capacity; i++)
            {
                GameObject objectInGame = Instantiate(prefab.gameObject, _container.transform);
                objectInGame.SetActive(false);

                _pool.Add(objectInGame);
            }
        }

        protected bool TryGetObject(out GameObject result)
        {
            result = _pool.FirstOrDefault(p => p.activeSelf == false);

            return result != null;
        }*/

/*    protected void ResetPoll()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }*/

    protected void CountElements(int count)
    {
        CountedCreate?.Invoke(count);
    }

   /* private void CountActiveElements()
    {
        int count = _pool.Count(p => p.activeSelf);

        CountedActive?.Invoke(count);
    }*/
}
