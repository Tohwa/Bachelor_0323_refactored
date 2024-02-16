using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool<T> where T : MonoBehaviour, IPoolableBullet<T>
{
    public GameObject prefab;

    Transform oriParent;

    public BulletPool(GameObject _prefab, int _size, Transform _parent)
    {
        oriParent = _parent;
        prefab = _prefab;
        for (int i = 0; i < _size; i++)
        {
            T temp = GameObject.Instantiate(_prefab).GetComponent<T>();
            temp.InitializeBullet(this);
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
        _item.transform.parent = oriParent;
        queue.Enqueue(_item);
    }
}
