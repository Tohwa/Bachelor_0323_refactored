using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeSet<T> : ScriptableObject
{
    public List<T> Items = new List<T>();

    public void Add(T item)
    {
        if(!Items.Contains(item)) Items.Add(item);
    }

    public void Remove(T item)
    {
        if(Items.Contains(item)) Items.Remove(item);
    }
}
