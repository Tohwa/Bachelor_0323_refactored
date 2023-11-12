using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObjectPool<T> where T : MonoBehaviour, IPoolable<T>
{
    public GameObject prefab;

    public MyObjectPool(GameObject _prefab, int _size, Transform _parent)
    {
        prefab = _prefab;
        for (int i = 0; i < _size; i++)
        {
            T temp = GameObject.Instantiate(_prefab).GetComponent<T>();
            temp.Initialize(this);
            temp.transform.parent = _parent;
            ReturnItem(temp);
        }        
    }

    private Queue<T> queue = new Queue<T>();

    public T GetItem()
    {
        T temp;

        if (queue.Count == 0)
        {
            return null;
        }

        temp = queue.Dequeue();
        temp.Activate();

        return temp;
    }

    public void ReturnItem(T _item)
    {
        _item.Deactivate();
        queue.Enqueue(_item);
    }
}
