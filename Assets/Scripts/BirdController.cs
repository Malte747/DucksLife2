using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float minHeight = 0f;
    public float maxHeight = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
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
        // Check the current height during the jump and limit it to the specified maximum
        if (transform.position.y < maxHeight)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }
}













