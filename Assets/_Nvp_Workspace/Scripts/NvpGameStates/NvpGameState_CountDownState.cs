using UnityEngine;
using nvp.events;

public class NvpGameState_CountDownState : INvpGameState
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private float _timer;




    // +++ state methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public void Enter()
    {
        Debug.Log("Enter Countdown State");
        _timer = 4f;
    }

    public void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            var ea = new StateTransitionEventArgs()
            {
                Value = NvpGameStatesEnum.Play
            };
            NvpEventBus.Events(GameEvents.OnChangeGameState).TriggerEvent(this, ea);
        }
    }

    public void Exit()
    {
        // do nothing
    }
}
