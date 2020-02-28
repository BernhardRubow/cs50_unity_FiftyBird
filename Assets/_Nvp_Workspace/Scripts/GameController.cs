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
            .AddGameState(NvpGameStatesEnum.GameOver, new NvpGameState_GameOverState())
            .Build();

        _nvpStateMachine.DoStateTransition(NvpGameStatesEnum.Title);

        NvpEventBus.Events(GameEvents.OnPlayerScores).GameEventHandler += OnPlayerScores;
        NvpEventBus.Events(GameEvents.OnPlayerHitsPipe).GameEventHandler += OnPlayerHitsPipe;
        NvpEventBus.Events(GameEvents.OnGameOverFinished).GameEventHandler += OnGameOverFinished;
    }

    private void OnDisable()
    {

        NvpEventBus.Events(GameEvents.OnPlayerScores).GameEventHandler -= OnPlayerScores;
        NvpEventBus.Events(GameEvents.OnPlayerHitsPipe).GameEventHandler -= OnPlayerHitsPipe;
        NvpEventBus.Events(GameEvents.OnGameOverFinished).GameEventHandler -= OnGameOverFinished;
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

    private void OnPlayerHitsPipe(object sender, EventArgs e)
    {
        var stateTransitionEventArgs = new GenericEventArgs(NvpGameStatesEnum.GameOver);
        NvpEventBus.Events(GameEvents.OnChangeGameState).TriggerEvent(this, stateTransitionEventArgs);
    }

    private void OnGameOverFinished(object sender, EventArgs e)
    {
        Score = 0;

        NvpEventBus.Events(GameEvents.OnResetPipes).TriggerEvent(this, null);

        var stateTransitionEventArgs = new GenericEventArgs(NvpGameStatesEnum.Title);
        NvpEventBus.Events(GameEvents.OnChangeGameState).TriggerEvent(this, stateTransitionEventArgs);
    }
}
