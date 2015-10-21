using UnityEngine;
using System.Collections;
public class StateGamePlaying : GameState 
{
	private bool isPaused = false;
	
	public StateGamePlaying(GameManager manager):base(manager){	}
	
	public override void OnStateEntered(){}
	public override void OnStateExit(){}
	
	public override void StateUpdate() 
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			if (isPaused)
			{
				ResumeGameMode();
			}
			else
			{
				PauseGameMode();
			}
		}
	}

    public override void StateGUI()
    {
        //GUILayout.Label("Playing");
    }
		
	private void ResumeGameMode() 
	{
		Time.timeScale = 1.0f;
		isPaused = false;
	}
	
	private void PauseGameMode() 
	{
		Time.timeScale = 0.0f;
		isPaused = true;
	}
}