using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float Jump;

    private float move;
    private bool isOnFloor;
    private bool isRunning;

    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sprite;

    private AudioSource jumpSound;
    private AudioSource backgroundMusic;

    public Transform posicaoInicio;

    public bool podeMover = true; 

    void Start()
    {
        jumpSound = GameObject.Find("JumpSound").GetComponent<AudioSource>();
        backgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();

    }

    void Update()
    {
        if (!podeMover || speed == 0f) return;

        move = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && isOnFloor)
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, Jump));
            isOnFloor = false;
            jumpSound.Play();
        }

        if (move > 0)
        {
            isRunning = true;
            sprite.flipX = false;
        }
        else if (move < 0)
        {
            isRunning = true;
            sprite.flipX = true;
        }
        else
        {
            isRunning = false;
        }

        anim.SetBool("isRunning", isRunning);
        anim.SetBool("isOnFloor", isOnFloor);
        anim.SetFloat("VerticalVelocity", rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnFloor = true;
        }
    }

    public void ResetarPosicao()
    {
        if (posicaoInicio != null)
        {
            transform.position = posicaoInicio.position;
            rb.linearVelocity = Vector2.zero;
            anim.SetBool("isRunning", false);  
        }
    }
}
