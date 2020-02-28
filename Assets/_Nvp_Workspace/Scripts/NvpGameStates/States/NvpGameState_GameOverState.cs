using nvp.events;
using UnityEngine;

public class NvpGameState_GameOverState : INvpGameState
{
    public float timer = 0;

    public void Enter()
    {

        Debug.Log("Enter Game Over State");
        timer = 0;
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10 || Input.GetMouseButtonUp(0))
        {
            NvpEventBus.Events(GameEvents.OnGameOverFinished).TriggerEvent(this, null);
        }
    }

    public void Exit()
    {
        
    }
}