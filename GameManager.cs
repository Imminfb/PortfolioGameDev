using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static int score;

    public int vidasMaximas = 5;
    public int vidasAtuais;

    public bool estaMorto = false;

    private TextMeshProUGUI scoreText;

    public Image[] coracoes;
    public Sprite coracaoCheio;
    public Sprite coracaoVazio;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        vidasAtuais = vidasMaximas;
        AtualizarReferenciasUI();
        AtualizarHUDVidas();
    }

    void Update()
    {
        if (scoreText == null)
        {
            EncontrarScoreText();
        }

        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    public void AtualizarHUDVidas()
    {
        if (coracoes == null || coracoes.Length == 0)
            return;

        int totalCoracoes = coracoes.Length;
        int vidasRestantes = vidasAtuais;

        for (int i = 0; i < totalCoracoes; i++)
        {
            int index = totalCoracoes - 1 - i;

            if (coracoes[index] != null)
            {
                if (i < vidasRestantes)
                    coracoes[index].sprite = coracaoCheio;
                else
                    coracoes[index].sprite = coracaoVazio;
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AtualizarReferenciasUI();
        AtualizarHUDVidas();
        estaMorto = false;
    }

    private void AtualizarReferenciasUI()
    {
        EncontrarScoreText();
        AtualizarReferenciasCoracoes();
    }

    private void EncontrarScoreText()
    {
        GameObject scoreObj = GameObject.Find("ScoreText");
        if (scoreObj != null)
        {
            scoreText = scoreObj.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            scoreText = null;
        }
    }

    private void AtualizarReferenciasCoracoes()
    {
        GameObject[] hearts = GameObject.FindGameObjectsWithTag("Heart");

        if (hearts == null || hearts.Length == 0)
        {
            coracoes = new Image[0];
            return;
        }

        System.Array.Sort(hearts, (a, b) => b.transform.position.x.CompareTo(a.transform.position.x));

        coracoes = new Image[hearts.Length];

        for (int i = 0; i < hearts.Length; i++)
        {
            coracoes[i] = hearts[i].GetComponent<Image>();
        }
    }

    public void ResetarJogo()
    {
        score = 0;
        vidasAtuais = vidasMaximas;
        AtualizarHUDVidas();
    }
}
