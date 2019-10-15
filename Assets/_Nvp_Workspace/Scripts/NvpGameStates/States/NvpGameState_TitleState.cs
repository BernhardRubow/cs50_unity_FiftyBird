using nvp.events;
using UnityEngine;

public class NvpGameState_TitleState : INvpGameState
{

    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private readonly GameObject _birdPrefab;




    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public NvpGameState_TitleState(GameObject birdPrefab)
    {
        _birdPrefab = birdPrefab;
    }


    // +++ state methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public void Enter()
    {
        Debug.Log("Enter Title State");

        // instantiate new bird
        var bird = Object.Instantiate(_birdPrefab, Vector3.zero, Quaternion.identity);

        // request Title screen
        NvpEventBus.Events(GameEvents.OnUIChanged).TriggerEvent(this, new UiChangedEventArgs { Value = UiNames.title });

        // pause Game
        NvpEventBus.Events(GameEvents.OnPauseGame).TriggerEvent(this, new PauseEventArgs { Value = true });
    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var ea = new StateTransitionEventArgs();
            ea.Value = NvpGameStatesEnum.CountDown;
            NvpEventBus.Events(GameEvents.OnChangeGameState).TriggerEvent(this, ea);
        }
    }

    public void Exit()
    {

    }
}
