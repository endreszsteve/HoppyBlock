using UnityEngine;
using System.Collections;

public class StateGameLoading : GameState
{
    public StateGameLoading(GameManager manager) : base(manager) { }

    public override void OnStateEntered() 
    {
        Debug.Log("Loading");
    }
    public override void OnStateExit() 
    {
        GameManager.SetPlaying();
    }
    public override void StateUpdate() 
    {

    }
}