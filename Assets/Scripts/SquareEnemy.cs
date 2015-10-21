using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SquareEnemy : MonoBehaviour 
{
    public Transform enemy;
    public Rigidbody s_rigidbody;
    public GameObject player;
    public Text score;
    public Collider coll;
    [SerializeField]
    public bool isHurt = false;
    [SerializeField]
    private float timer = 0.0f;
    [SerializeField]
    private float walkSpeed = 2.0f;
    [SerializeField]
    private float bounce = 800.0f;
    [SerializeField]
    private bool isWalkingLeft = false;
    private float time = 2.0f;
    [SerializeField]
    private float bounceTimer = 0.0f;

    void Awake()
    {
        bounceTimer = Random.Range(5.0f, 1.0f);
        isWalkingLeft = true;
    }

    void OnBecameVisible()
    {
        enabled = true;
    }

    void OnBecameInvisible()
    {
        enabled = false;
    }

     void Update()
    {
        bounceTimer -= Time.deltaTime;

         if (bounceTimer < 0.0f)
         {
             bounceTimer = time;
             s_rigidbody.AddForce(0, bounce, 0);
         }
        
      
        if (isWalkingLeft)
        {
            s_rigidbody.velocity = new Vector3(-walkSpeed, s_rigidbody.velocity.y, s_rigidbody.velocity.z);
        }
        else
        {
            s_rigidbody.velocity = new Vector3(walkSpeed, s_rigidbody.velocity.y, s_rigidbody.velocity.z);
        }

        if (isHurt)
        {
            isDying();
        }
           
       
    }

    void OnCollisionEnter(Collision other)
    {            
        if (other.gameObject.tag == "Boundary")
        {
            s_rigidbody.velocity = new Vector3(2.0f, 2.0f, 0.0f);
            
            if(isWalkingLeft)
            {
                isWalkingLeft = false;
            }
        }

        if (other.contacts.Length > 0)
        {
            ContactPoint contact = other.contacts[0];

            if (Vector3.Dot(contact.normal, -Vector3.right) > 0.5 )
            {
                isWalkingLeft = true;
            }

            if (Vector3.Dot(contact.normal, Vector3.right) > 0.5 )
            {
                isWalkingLeft = false;
            }

            if (Vector3.Dot(contact.normal, -Vector3.up) > 0.5 )
            {
                if (other.gameObject.tag == "Player")
                {
                    isHurt = true;
                }
            }
            
        }
    }

    void startTimer()
    {
        if (timer <= 1.0f)
        {
            timer += Time.deltaTime;
        }
    }

   private void isDying()
    {
        startTimer();
        enemy.gameObject.transform.localScale = new Vector3(0.5f, 0.1f, 0.5f);
        s_rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        bounceTimer = 100.0f;
        coll.enabled = false;

        if (timer >= 1.0f)
        {
            Destroy(this.gameObject);
        }  
    }
}

