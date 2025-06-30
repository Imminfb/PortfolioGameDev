using UnityEngine;

public class Strawberry : MonoBehaviour
{
    private AudioSource strawberrySound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        strawberrySound = GameObject.Find("StrawberrySound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameManager.score += 1;
            strawberrySound.Play();
        }

    }
}
