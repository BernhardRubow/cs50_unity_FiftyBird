using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolItem
{
    void SetReturnAction(Action<GameObject> returnToPoolAction);
}
