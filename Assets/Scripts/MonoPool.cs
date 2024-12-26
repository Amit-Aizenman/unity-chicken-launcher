using System.Collections.Generic;
using UnityEngine;
using IPoolable = DefaultNamespace.IPoolable;

public class MonoPool<T> : MonoBehaviour where T: MonoBehaviour, IPoolable
{
    [SerializeField] private int initialSize;
    [SerializeField] private int currentSize;
    [SerializeField] private T prefab;
    [SerializeField] private Transform parent;
    private Stack<T> _available = new();

    private void Awake()
    {
        AddItemsToPool();
    }

    public T Get()
    {
        if (_available.Count == 0)
        {
            AddItemsToPool();
        }
        var pooledObject = _available.Pop();
        pooledObject.gameObject.SetActive(true);
        
        pooledObject.Reset();

        return pooledObject;
    }
  
    public void Return(T obj)
    {
        obj.gameObject.SetActive(false);
        _available.Push(obj);
    }
    
    private void AddItemsToPool()
    {
        if (currentSize == 0) 
            currentSize = initialSize;
        else currentSize *= 2;
        _available = new Stack<T>();
        for (int i = 0; i < currentSize; i++)
        {
            var obj = Instantiate(prefab, parent);
            obj.gameObject.SetActive(false);
            _available.Push(obj);
        }
    }
}
