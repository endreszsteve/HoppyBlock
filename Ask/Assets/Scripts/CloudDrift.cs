using UnityEngine;
using System.Collections;

public class CloudDrift : MonoBehaviour 
{
    public Transform cloud;
    public Rigidbody cloudbody;
    [SerializeField]
    private float Float = 0.0f;
    private float floatChangeTimer = 10.0f;
    [SerializeField]
    private float timer = 0.0f;
	// Use this for initialization
	void Start () 
    {
        timer = 10.0f;
        Float = Random.Range(0.1f, 0.4f);
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer -= Time.deltaTime;

        if (timer < 0.0f)
        {
            timer = floatChangeTimer;
            Float = Random.Range(0.1f, 0.4f);
            cloudbody.velocity = new Vector3(Random.Range(-Float, Float), cloudbody.velocity.y, cloudbody.velocity.z);
        }
	}
}
