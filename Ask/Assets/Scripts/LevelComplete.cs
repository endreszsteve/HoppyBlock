using UnityEngine;
using System.Collections;

public class LevelComplete : MonoBehaviour 
{
    [SerializeField]
    private bool playerComplete = false;
	// Use this for initialization
	void Start () 
    {
        playerComplete = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (playerComplete)
        {
            Application.LoadLevel(1);
        }
	}

    void OnCollisionStay(Collision other)
    {
        // check to see if the player is touching the end of the level
        if(other.gameObject.tag == "Player")
        {
            playerComplete = true;
        }
        else
        {
            playerComplete = false;
        }
    }
}
