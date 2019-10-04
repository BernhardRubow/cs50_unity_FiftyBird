using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NvpPripeController : MonoBehaviour, IPoolItem
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private System.Action<GameObject> _returnToPoolAction;





    // +++ IPoolItem implementation +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public void SetReturnAction(Action<GameObject> returnToPoolAction)
    {
        if (_returnToPoolAction == null) _returnToPoolAction = returnToPoolAction;
    }




    // +++ class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void ReturnToPool()
    {
        _returnToPoolAction(this.gameObject);
    }
}
