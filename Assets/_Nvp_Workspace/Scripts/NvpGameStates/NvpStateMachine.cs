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
        
    }


    public void Dispose()
    {
       
    }

    public void Update()
    {
        gameStates[currentStateEnum].Update();
    }




    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    




    // +++ private class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void DoStateTransition(NvpGameStatesEnum from, NvpGameStatesEnum to)
    {
        gameStates[from].Exit();
        currentStateEnum = to;
        gameStates[to].Enter();
    }
}