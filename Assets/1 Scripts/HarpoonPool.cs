using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonPool
{
    GameObject _prefab;
    List<GameObject> pool = new List<GameObject>();
    public bool _canGrow;

    public HarpoonPool(GameObject prefab, bool canGrow, int count)
    {
        _prefab = prefab;
        _canGrow = canGrow;

        for (int i = 0; i < count; i++)
        {
            GameObject temp = GameObject.Instantiate(_prefab);
            temp.SetActive(false);
            pool.Add(temp);
        }
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeSelf)
            {
                return pool[i];
            }
        }

        if (_canGrow)
        {
            GameObject temp = GameObject.Instantiate(_prefab);
            temp.SetActive(false);
            pool.Add(temp);
            return temp;
        }
        return null;
    }
}

