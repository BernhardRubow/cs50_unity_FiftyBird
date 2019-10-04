using nvp.events;
using UnityEngine;

public class NvpGameState_Start : NvpGameState{

    public override void EnterState()
    {
        this.Update = UpdateState;
    }

    public override void UpdateState()
    {
    }

    public override void ExitState()
    {

    }

}