using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Transform Player;
    public Rigidbody p_rigidbody;
    private SquareEnemy enemy;

    private float jumpPower = 6.5f;
    private float bouncePower = 300f;
    private float runSpeed = 4.0f;
    [SerializeField]
    private float walkSpeed = 2.0f;
    [SerializeField]
    private bool isGrounded = false;
    [SerializeField]
    private bool walledLeft = false;
    [SerializeField]
    private bool walledRight = false;
    private bool isSwimming = false;
    private bool inWater = false;

    private float hopTime = 0.3f;
    [SerializeField]
    private float timer = 0.0f;
    private float audioTime = 0.1f;

    // Audio
    AudioSource audio;
    public AudioClip boing;
    public AudioClip swim;
    public AudioClip collect;
    public AudioClip superCollect;


    void Awake()
    {
        timer = 0.3f;
        enemy = GetComponent<SquareEnemy>();
        audio = GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update () 
    {
        timer -= Time.deltaTime;

        if(isGrounded)
        {
            if(timer < 0.0 && !isSwimming)
            {
                timer = hopTime;
                p_rigidbody.AddForce(p_rigidbody.velocity.x, bouncePower, p_rigidbody.velocity.z);
            }
        }
	    if(Input.GetButton("right"))
        {
            if(walledRight == false)
            { 
                p_rigidbody.velocity = new Vector3(walkSpeed, p_rigidbody.velocity.y, p_rigidbody.velocity.z);
            }
        }

        if (Input.GetButton("left"))
        {
            if (walledLeft == false)
            {
                p_rigidbody.velocity = new Vector3(-walkSpeed, p_rigidbody.velocity.y, p_rigidbody.velocity.z);
            }
        }

        if (Input.GetButton("Run"))
        {
            walkSpeed = runSpeed;
        }
        else
        {
            walkSpeed = 2.0f;
        }

        if (isGrounded)
        {

            if (Input.GetButton("jump"))
            {
                p_rigidbody.velocity = new Vector3(p_rigidbody.velocity.x, jumpPower, p_rigidbody.velocity.z);
                isGrounded = false;
                isSwimming = false;
                audioTime -= Time.deltaTime;
                if (inWater && audioTime < 0)
                {
                    audio.PlayOneShot(swim, 1.0f);
                    audioTime = 0.1f;
                }
                else if (!inWater)
                {
                    audio.PlayOneShot(boing, 1.0f);
                    audioTime = 0.1f;
                }
            }
        }

        if (Input.GetButton("crouch"))
        {            
            Player.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            timer = 0.25f;
        }
        else
        {
            Player.localScale = new Vector3(0.5f, 1.0f, 0.5f);
        }      
	}

    void OnCollisionStay(Collision other)
    {
        if (other.contacts.Length > 0)
        {
            ContactPoint contact = other.contacts[0];
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.5)
            {
                isGrounded = true;
            }

            if (Vector3.Dot(contact.normal, -Vector3.right) > 0.5 && isGrounded == false)
            {
                walledRight = true;
            }
            else
            {
                walledRight = false;
            }

            if (Vector3.Dot(contact.normal, Vector3.right) > 0.5 && isGrounded == false)
            {
                walledLeft = true;
            }
            else
            {
                walledLeft = false;
            }
        }

        // Check to see if its a boundary
        if (other.gameObject.tag == "Boundary")
        {
            p_rigidbody.velocity = new Vector3(2.0f, 2.0f, 0.0f);
        }

        // Check if on soild ground
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Platform")
        {
            walkSpeed = 2.0f;
            p_rigidbody.drag = 0.0f;
            isSwimming = false;
            inWater = false;
        }
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bit")
        {
            audio.PlayOneShot(collect, 1.0f);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "SuperBit")
        {
            audio.PlayOneShot(superCollect, 1.0f);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Dead")
        {
            Application.LoadLevel("buildTest");
        }
    }
   
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            inWater = true;
            walkSpeed = 1.0f;
            p_rigidbody.drag = 5.0f;
            isSwimming = true;
            isGrounded = true;
        }
    }
}