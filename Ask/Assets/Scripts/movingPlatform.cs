using UnityEngine;
using System.Collections;

public class movingPlatform : MonoBehaviour 
{
    public Transform platform;

    private Vector3 origin;
    private Vector3 target;
    private Vector3 current;

    private float speed = 0.025f;

    private bool moveRight = false;

	// Use this for initialization
	void Start () 
    {
        origin = platform.transform.position;
        target = new Vector3(origin.x + 3, origin.y, origin.z);
	}
	
	// Update is called once per frame
	void Update () 
    {
        current = platform.transform.position;

        if (current.x <= origin.x)
        {
            moveRight = true;
        }
        else if (current.x >= target.x)
        {
            moveRight = false;
        }

        if (moveRight)
        {
            platform.transform.Translate(Vector3.right * speed);
        }
        else if (!moveRight)
        {
            platform.transform.Translate(Vector3.left * speed);
        }
	}
}
