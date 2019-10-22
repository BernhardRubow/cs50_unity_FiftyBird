using System;
using System.Collections.Generic;
using nvp.events;

public class NvpStateMachine : System.IDisposable {

    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public NvpGameStatesEnum currentStateEnum = NvpGameStatesEnum.Idle;
    public Dictionary<NvpGameStatesEnum, INvpGameState> gameStates;




    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public NvpStateMachine()
    {
        NvpEventBus.Events(GameEvents.OnChangeGameState).GameEventHandler += OnGameStateChanged;
    }


    public void Dispose()
    {
        NvpEventBus.Events(GameEvents.OnChangeGameState).GameEventHandler -= OnGameStateChanged;
    }


    public void Update()
    {
        gameStates[currentStateEnum].Update();
    }




    //// +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnGameStateChanged(object sender, EventArgs e)
    {
        var ea = (GenericEventArgs)e;
        DoStateTransition(ea.GetValue<NvpGameStatesEnum>());
    }

    


    // +++ private class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public void DoStateTransition(NvpGameStatesEnum to)
    {
        gameStates[currentStateEnum].Exit();
        currentStateEnum = to;
        gameStates[to].Enter();
    }
}