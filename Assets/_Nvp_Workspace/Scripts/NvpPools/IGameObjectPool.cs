using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameObjectPool 
{
    GameObject GetFromPool();
    void ReturnToPool(GameObject poolItem);
}
