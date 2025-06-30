using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    public Animator anim;
    private AudioSource backgroundMusic;
    private AudioSource levelComplete;

    public string nextLevel;

    private Fade fade;

    void Start()
    {
        levelComplete = GameObject.Find("LevelCompleteSound").GetComponent<AudioSource>();
        backgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();

        
        fade = Object.FindFirstObjectByType<Fade>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            backgroundMusic.Stop();
            levelComplete.Play();
            anim.SetTrigger("Comemoration");

            Player playerScript = collision.GetComponent<Player>();
            if (playerScript != null)
                playerScript.podeMover = false;

            if (fade != null)
            {
                StartCoroutine(FadeAndLoad());
            }
            else
            {
                Invoke("LoadNextLevel", 2.5f);
            }
        }
    }

    private System.Collections.IEnumerator FadeAndLoad()
    {
        
        yield return new WaitForSeconds(1.5f);

        
        yield return StartCoroutine(fade.FadeIn());

        
        LoadNextLevel();
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
