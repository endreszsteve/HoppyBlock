using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
    private static LevelManager instance = null;
    public static LevelManager Instance { get { return instance; } }

    public string[] levelNames;
    public int gameLevelNum;

    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }

    public void LoadLevel( string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    public void ResetGame()
    {
        // reset the level index counter
        gameLevelNum = 0;
    }

    public void GoToNextLevel()
    {
        // if the array goes over the number of levels in the array we reset it
        if (gameLevelNum >= levelNames.Length)
        {
            gameLevelNum = 0;
        }
            // load the level (the array index starts at 0, but we start counting game levels at 1)
            LoadLevel(gameLevelNum);

        // increase our game level index counter
            gameLevelNum++;
    }

    private void LoadLevel(int indexNum)
    {
        //load the game level
        LoadLevel(levelNames[indexNum]);
    }
}
