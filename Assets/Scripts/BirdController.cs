using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float maxHeight = 10f;
    public float minHeight = -19f;
    public float Tauchen = -10;
    private Animator anim;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();   
        anim = GetComponent<Animator>(); 
    }

    void Update()
    {
        Transform myTransform = gameObject.transform;

            if (Input.GetKeyDown(KeyCode.Space) &&  gameObject.transform.position.y >= 0)
                {
                    Jump();
                    
                }

            else if (Input.GetKey(KeyCode.Space) && gameObject.transform.position.y <= 0)
                {
                    Dive();
                   
                }
            else if(gameObject.transform.position.y <= 0)
                {
                    rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                }

            if(gameObject.transform.position.y == 0)
                {
                    myTransform.position = new Vector3(myTransform.position.x, 0f, myTransform.position.z);
                    anim.SetBool("Swim", false);
                }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            anim.SetTrigger("Death");
            Invoke("Death", 0.5f);
            
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }

    void Jump()
    {
        if (transform.position.y < maxHeight)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                anim.SetTrigger("Jump");
            }
    }

    void Dive()
    { 
        if (transform.position.y < minHeight)
    {
        rb.velocity = new Vector3(rb.velocity.x, Tauchen, rb.velocity.z);
         anim.SetBool("Swim", true);
    }
    }
}













