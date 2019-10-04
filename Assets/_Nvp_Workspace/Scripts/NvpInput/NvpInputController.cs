using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;

public class NvpInputController : MonoBehaviour
{
    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("On Player jumps events thrown");
            NvpEventBus.Events(GameEvents.OnPlayerJumps).TriggerEvent(this, null);
        }
    }
}
