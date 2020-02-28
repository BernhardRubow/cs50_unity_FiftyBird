using UnityEngine;
using nvp.events;

public class NvpGameState_CountDownState : INvpGameState
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private float _timer;
    private int _secondDisplay;




    // +++ state methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public void Enter()
    {
        Debug.Log("Enter Countdown State");
        _timer = 1f;
        _secondDisplay = 3;

        // change ui
        NvpEventBus.Events(GameEvents.OnUIChanged).TriggerEvent(this, new GenericEventArgs(UiNames.countdown));
    }

    public void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            if (_secondDisplay > 0)
            {
                _secondDisplay--;
                _timer = 1f;

                Debug.Log("Display Countdown:" + _secondDisplay);
                NvpEventBus.Events(GameEvents.OnCountDownValueChanged).TriggerEvent(this, new GenericEventArgs(_secondDisplay));

            }
            else
            {
                NvpEventBus.Events(GameEvents.OnCountDownValueChanged).TriggerEvent(this, new GenericEventArgs(3));
                NvpEventBus.Events(GameEvents.OnChangeGameState).TriggerEvent(this, new GenericEventArgs(NvpGameStatesEnum.Play));
            }
        }
    }

    public void Exit()
    {
        
    }
}
