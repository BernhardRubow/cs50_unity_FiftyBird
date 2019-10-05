using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;

public class NvpInputController : MonoBehaviour
{
    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void FixedUpdate()
    {


        if (Input.GetMouseButtonUp(0))
        {
            NvpEventBus.Events(GameEvents.OnPlayerJumps).TriggerEvent(null, null);
        }
    }
}
