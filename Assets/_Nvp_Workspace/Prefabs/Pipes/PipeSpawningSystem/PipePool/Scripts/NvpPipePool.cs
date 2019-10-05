using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NvpPipePool : MonoBehaviour, IGameObjectPool
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private GameObject _pipePrefab;
    [SerializeField] private int _prefillPoolCount;

    private Queue<GameObject> _pool;
    private static NvpPipePool INSTANCE;




    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void Start()
    {
        NvpPipePool.INSTANCE = this;
        _pool = new Queue<GameObject>();
        if (_prefillPoolCount > 1) PreparePool(_prefillPoolCount);
    }




    // +++ IGameObjectPool Implementation +++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public GameObject GetFromPool()
    {
        if(this._pool.Count == 0)
        {
            AddToPool(1);
        }

        var pipe = this._pool.Dequeue();
        
        pipe.GetComponent<IPoolItem>().SetReturnAction(ReturnToPool);

        return pipe;
    }


    public void ReturnToPool(GameObject poolItem)
    {
        poolItem.SetActive(false);
        this._pool.Enqueue(poolItem);
    }
    
    
    
    
    // +++ private class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void PreparePool(int n)
    {
        AddToPool(n);
    }


    private void AddToPool(int n)
    {
        for (int i = 0; i < n; i++)
        {
            var pipe = Instantiate(_pipePrefab);
            pipe.gameObject.SetActive(false);
            _pool.Enqueue(pipe);
        }
    }


    public static GameObject GetPooledItem()
    {
        return NvpPipePool.INSTANCE.GetFromPool();
    }
}
