using System.Collections.Generic;

public class NvpStateMachine_Builder{
    private NvpStateMachine _nvpStateMachine;

    public NvpStateMachine_Builder(){
        _nvpStateMachine = new NvpStateMachine();
        _nvpStateMachine.gameStates = new Dictionary<NvpGameStatesEnum, NvpGameState>();
    }

    public NvpStateMachine_Builder AddGameState(NvpGameStatesEnum stateEnumName, NvpGameState stateClass){
        _nvpStateMachine.gameStates.Add(stateEnumName, stateClass);
        return this;
    }

    public NvpStateMachine_Builder SetStartState(NvpGameStatesEnum stateEnumName){
        _nvpStateMachine.currentStateEnum = stateEnumName;
        _nvpStateMachine.gameStates[stateEnumName].Update = _nvpStateMachine.gameStates[stateEnumName].EnterState;
        return this;
    }

    public NvpStateMachine Build(){
        return _nvpStateMachine;
    }
}