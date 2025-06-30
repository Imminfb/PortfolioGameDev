using UnityEngine;

public class MovimentoAutomatico : MonoBehaviour
{
    public float velocidade = 3f;      
    public float distancia = 5f;       

    private Vector3 posicaoInicial;
    private bool indoParaFrente = true;

    void Start()
    {
        posicaoInicial = transform.position;  
    }

    void Update()
    {
        if (indoParaFrente)
        {
            
            transform.position += Vector3.right * velocidade * Time.deltaTime;

            
            if (transform.position.x >= posicaoInicial.x + distancia)
            {
                indoParaFrente = false;
            }
        }
        else
        {
            
            transform.position += Vector3.left * velocidade * Time.deltaTime;

            
            if (transform.position.x <= posicaoInicial.x)
            {
                indoParaFrente = true;
            }
        }
    }
}
