using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    [SerializeField] private List<PoolItem> _poolObjectsList;

    private Dictionary<Type, List<MonoBehaviour>> _dictPoolObjects;

    private void Awake()
    {
        _dictPoolObjects = new Dictionary<Type, List<MonoBehaviour>>();

        foreach (var item in _poolObjectsList)
        {
            var poolList = new List<MonoBehaviour>();
            for (int i = 0; i < item.StartCapacity; i++)
            {
                var gameObject = Instantiate(item.ObjectToPool);
                gameObject.gameObject.SetActive(false);
                poolList.Add(gameObject);
            }
            _dictPoolObjects.Add(item.ObjectToPool.GetType(), poolList);
        }
    }


    public T GetObject<T>() where T : MonoBehaviour
    {
        var list = new List<MonoBehaviour>();
        if (_dictPoolObjects.TryGetValue(typeof(T), out list))
        {
            MonoBehaviour gameObject = null;
            for (int i = 0; i < list.Count; i++)
            {
                if (!list[i].isActiveAndEnabled)
                {
                    gameObject = list[i];
                }
            }

            if (gameObject == null)
            {
                gameObject = Instantiate(list[0]);
                list.Add(gameObject);
            }

            ((IPoolObject)gameObject).GetFromPool();
            return (T)gameObject;
        }
        else
        {
            return null;
        }
    }


    #region SerializableClass
    [System.Serializable]
    private class PoolItem
    {
        public string Name;
        [Header("Only IPoolObject")]
        public MonoBehaviour ObjectToPool;
        public int StartCapacity = 10;
    }
    #endregion
}
