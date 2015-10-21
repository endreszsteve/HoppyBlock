using UnityEngine;
using System.Collections;

public class StateGameMenu : GameState
{
    public StateGameMenu(GameManager manager) : base(manager) { }

    public override void OnStateEntered() 
    {
        Debug.Log("menuState");
    }
    public override void OnStateExit() 
    {
        GameManager.SetPlaying();
    }
    public override void StateUpdate() 
    {

    }
}
