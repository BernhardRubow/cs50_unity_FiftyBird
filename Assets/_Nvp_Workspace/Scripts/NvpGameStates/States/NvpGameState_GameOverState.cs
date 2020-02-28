using nvp.events;
using UnityEngine;

public class NvpGameState_GameOverState : INvpGameState
{
    public float timer = 0;

    public void Enter()
    {

        Debug.Log("Enter Game Over State");

        var ea = new GenericEventArgs(UiNames.gameover);
        NvpEventBus.Events(GameEvents.OnUIChanged).TriggerEvent(this, ea);
        timer = 0;
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10 || Input.GetMouseButtonUp(1))
        {
            NvpEventBus.Events(GameEvents.OnGameOverFinished).TriggerEvent(this, null);
        }
    }

    public void Exit()
    {
        
    }
}