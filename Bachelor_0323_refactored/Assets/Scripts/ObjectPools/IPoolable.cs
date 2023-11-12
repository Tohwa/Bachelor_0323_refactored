using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable<T> where T : MonoBehaviour, IPoolable<T>
{
    public void Initialize(MyObjectPool<T> pool);

    public void Deactivate();

    public void Activate();

}
