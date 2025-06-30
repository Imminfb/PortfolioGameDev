using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private AudioSource trampolineSound;

    public float bounceForce = 15f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trampolineSound = GameObject.Find("TrampolineSound").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            trampolineSound.Play();
        }
    }
}
