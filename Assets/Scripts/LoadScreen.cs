using UnityEngine;
using System.Collections;

public class LoadScreen : MonoBehaviour 
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(5f);
        LevelManager.Instance.GoToNextLevel();
    }
}
