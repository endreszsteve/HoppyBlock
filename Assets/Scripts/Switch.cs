using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour 
{
    public GameObject switchbox;
    public GameObject platform;
    private float timer = 25;

    // Switchbox variables
    private bool isSwitched;
    private Vector3 originPos;
    private Vector3 targetPos;
    private float startTime;

    // Platform variables
    private Vector3 p_origin;
    private Vector3 p_target;
    private Vector3 p_current;
    
    private float p_speed = 0.025f;

    private bool p_isUpping = false;
    private bool p_isMoving = false;

	// Use this for initialization
	void Start () 
    {
        startTime = Time.deltaTime;
        isSwitched = false;

        originPos = switchbox.transform.position;
        targetPos = new Vector3(originPos.x, originPos.y - 0.2f, originPos.z);

        p_origin = platform.transform.position;
        p_target = new Vector3(p_origin.x, p_origin.y + 3, p_origin.z);
        p_current = platform.transform.position;
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        p_current = platform.transform.position;

        if (isSwitched)
        {
            timer -= Time.deltaTime;
            p_isMoving = true;
        }

        if (isSwitched && timer <= 0.0f)
        {
            //Move box down into ground while the box is triggered to move the platform
            timer = 25f;

            switchbox.transform.position = originPos;
            isSwitched = false;
            p_isMoving = false;
        }

        // Platform direction
        if (p_current.y <= p_origin.y)
        {
            p_isUpping = true;
        }
        else if (p_current.y >= p_target.y)
        {
            p_isUpping = false;
        }

        // Check if the switch is pressed and then move platform between origin and target destination
        if (p_isMoving)
        {
            if (p_isUpping)
            {
                platform.transform.Translate(Vector3.up * p_speed);
            }
            else if (!p_isUpping)
            {
                platform.transform.Translate(Vector3.down * p_speed);
            }
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if (!isSwitched && other.gameObject.tag == "Player")
        {
            switchbox.transform.position = targetPos;   // move box down to ground level 
            isSwitched = true;   
        }   
    }
}
