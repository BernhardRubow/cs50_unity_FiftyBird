using nvp.events;
using UnityEngine;

public class NvpGameState_PlayState : INvpGameState
{

    public void Enter()
    {
        Debug.Log("Enter Play State");
        NvpEventBus.Events(GameEvents.OnUIChanged).TriggerEvent(this, new GenericEventArgs(UiNames.play));
        NvpEventBus.Events(GameEvents.OnPauseGame).TriggerEvent(this, new GenericEventArgs(false));
    }

    public void Update()
    {
    }

    public void Exit()
    {
    }
}
