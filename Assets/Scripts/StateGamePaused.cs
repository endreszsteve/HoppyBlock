using UnityEngine;
using System.Collections;

public class StateGamePaused : GameState 
{
    public StateGamePaused(GameManager manager) : base(manager) { }

    public override void OnStateEntered()
    {
        Debug.Log("Paused");
        
    }
    public override void OnStateExit()
    {

    }

    public override void StateUpdate()
    {

    }
}
