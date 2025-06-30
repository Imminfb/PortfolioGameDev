using UnityEngine;

public class AtivarFogueira : MonoBehaviour
{
    public GameObject fogo;        
    public Animator animatorFogo;  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            fogo.SetActive(true);                     
            animatorFogo.SetTrigger("Acender");        
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animatorFogo.SetTrigger("Apagar"); 
        }
    }
}
