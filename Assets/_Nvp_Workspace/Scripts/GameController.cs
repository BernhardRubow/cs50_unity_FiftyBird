using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;

public class GameController : MonoBehaviour
{
    // +++ fields ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private NvpStateMachine _nvpStateMachine;
    public GameObject birdPrefab;
    public int Score;




    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnEnable()
    {
        _nvpStateMachine = new NvpStateMachine_Builder()
            .AddGameState(NvpGameStatesEnum.Idle, new NvpGameState_IdleState())
            .AddGameState(NvpGameStatesEnum.Title, new NvpGameState_TitleState(birdPrefab))
            .AddGameState(NvpGameStatesEnum.CountDown, new NvpGameState_CountDownState())
            .AddGameState(NvpGameStatesEnum.Play, new NvpGameState_PlayState())
            .AddGameState(NvpGameStatesEnum.Score, new NvpGameState_ScoreState())
            .Build();

        _nvpStateMachine.DoStateTransition(NvpGameStatesEnum.Title);

        NvpEventBus.Events(GameEvents.OnPlayerScores).GameEventHandler += OnPlayerScores;
    }

    private void OnDisable()
    {

        NvpEventBus.Events(GameEvents.OnPlayerScores).GameEventHandler -= OnPlayerScores;
        _nvpStateMachine.Dispose();
    }

    private void Update()
    {
        _nvpStateMachine.Update();
    }




    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnPlayerScores(object sender, EventArgs e)
    {
        Score++;
        NvpEventBus.Events(GameEvents.OnScoreChanged).TriggerEvent(this, new GenericEventArgs(Score));

    }
}
