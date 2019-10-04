using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;

public class GameController : MonoBehaviour
{
    // +++ fields ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private NvpStateMachine _nvpStateMachine;




    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnEnable()
    {
        _nvpStateMachine = new NvpStateMachine_Builder()
            .AddGameState(NvpGameStatesEnum.Start, new NvpGameState_Start())
            .SetStartState(NvpGameStatesEnum.Start)
            .Build();
    }

    private void OnDisable()
    {
        _nvpStateMachine.Dispose();
    }

    private void Update()
    {
        _nvpStateMachine.Update();
    }
}
