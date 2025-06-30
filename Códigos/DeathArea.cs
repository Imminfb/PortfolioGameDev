using UnityEngine;
using UnityEngine.SceneManagement;

public class DeatheArea : MonoBehaviour
{
    public Animator anim;
    private AudioSource deathSound;
    private AudioSource backgroundMusic;

    void Start()
    {
        deathSound = GameObject.Find("DeathSound").GetComponent<AudioSource>();
        backgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !GameManager.instance.estaMorto)
        {
            GameManager.instance.estaMorto = true;

            backgroundMusic.Stop();
            deathSound.Play();
            anim.SetTrigger("Death");

            GameManager.instance.vidasAtuais--;
            GameManager.instance.AtualizarHUDVidas();

            Player playerScript = collision.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.podeMover = false;
            }

            Invoke("ReposicionarPlayer", 3.2f);
        }
    }

    void ReposicionarPlayer()
    {
        GameManager.instance.estaMorto = false;

        if (GameManager.instance.vidasAtuais <= 0)
        {
            GameManager.score = 0;
            GameManager.instance.vidasAtuais = GameManager.instance.vidasMaximas;
            SceneManager.LoadScene(0);
        }
        else
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                Player playerScript = player.GetComponent<Player>();
                if (playerScript != null)
                {
                    playerScript.ResetarPosicao();
                    playerScript.podeMover = true;

                    if (backgroundMusic != null && !backgroundMusic.isPlaying)
                    {
                        backgroundMusic.Play();
                    }
                }
            }
        }
    }

    public void ResetarMorte()
    {
      
    }
}
