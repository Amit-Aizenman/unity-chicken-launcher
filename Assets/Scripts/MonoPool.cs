using System.Collections.Generic;
using UnityEngine;
using IPoolable = DefaultNamespace.IPoolable;

public class MonoPool<T> : MonoBehaviour where T: MonoBehaviour, IPoolable
{
    private readonly Stack<T> _available = new();
  
    public T Get()
    {
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
}
