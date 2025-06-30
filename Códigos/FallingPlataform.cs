using UnityEngine;

public class FallingPlatformRespawn : MonoBehaviour
{
    public float delayBeforeFall = 1.0f;     
    public float respawnDelay = 3.0f;        

    private Rigidbody2D rb;
    private Collider2D col;
    private Vector3 startPosition;
    private bool isFalling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        startPosition = transform.position;
        rb.bodyType = RigidbodyType2D.Kinematic; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isFalling && collision.gameObject.CompareTag("Player"))
        {
            isFalling = true;
            Invoke(nameof(Fall), delayBeforeFall);
        }
    }

    void Fall()
    {
        rb.bodyType = RigidbodyType2D.Dynamic; 
        col.enabled = false;                    
        Invoke(nameof(Respawn), respawnDelay);
    }

    void Respawn()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;   
        rb.linearVelocity = Vector2.zero;                 
        transform.position = startPosition;         
        col.enabled = true;                          
        isFalling = false;                           
    }
}
