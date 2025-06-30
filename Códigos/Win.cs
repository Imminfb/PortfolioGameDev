using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrofeuVitoria : MonoBehaviour
{
    public Animator anim;                     
    public GameObject mensagemVitoriaUI;     
    private AudioSource backgroundMusic;
    private AudioSource victorySound;

    void Start()
    {
        backgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        victorySound = GameObject.Find("VictorySound").GetComponent<AudioSource>();

        if (mensagemVitoriaUI != null)
            mensagemVitoriaUI.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            backgroundMusic.Stop();
            victorySound.Play();

            if (anim != null)
                anim.SetTrigger("Comemoration");

            Player playerScript = collision.GetComponent<Player>();
            if (playerScript != null)
                playerScript.podeMover = false;

            if (mensagemVitoriaUI != null)
                mensagemVitoriaUI.SetActive(true);
        }
    }
}
