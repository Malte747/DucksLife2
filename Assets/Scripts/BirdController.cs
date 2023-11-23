using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float maxHeight = 10f;
    public float Tauchen = -10;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();    
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
                }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

    void Jump()
    {
        if (transform.position.y < maxHeight)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            }
    }

    void Dive()
    { 
        rb.velocity = new Vector3(rb.velocity.x, Tauchen, rb.velocity.z);
    }
}













