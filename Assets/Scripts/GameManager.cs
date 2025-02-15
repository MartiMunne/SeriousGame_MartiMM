using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] private float rangoX = 6.5f;
    [SerializeField] private float posY = 6f;
    [SerializeField] private float generateTime = 2f;
    [SerializeField] private float actualTime = 0f;
    [SerializeField] private int wordTipo = 0;
    [SerializeField] private int wordChoose = 0;
    [SerializeField] private List<string> susts;
    [SerializeField] private List<string> verbs;
    [SerializeField] private List<string> adjs;
    [SerializeField] private List<string> advs;
    [SerializeField] private List<string> preps;

    public int puntosActual;
    [SerializeField] private TMP_Text puntosNumber;

    private void Awake()
    {
        if(GameManager.gameManager != null && GameManager.gameManager != this)
        {
            Destroy(gameObject);
        }
        else
        {
            GameManager.gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        actualTime += Time.deltaTime;

        if(actualTime >= generateTime)
        {
            wordTipo = Random.Range(1,5);
            int wordChoose_ = Random.Range(1,10);
            wordChoose = wordChoose_ - 1;
            float posX = Random.Range(-rangoX, rangoX);
            GameObject word = WordsPool.InstancePool.RequestWord(wordTipo);
            TMP_Text wordText = word.GetComponent<TMP_Text>();
            word.transform.position = new Vector2(posX, posY);
            if(wordTipo == 1)
            { 
                wordText.text = susts[wordChoose];
            }
            if (wordTipo == 2)
            {
                wordText.text = verbs[wordChoose];
            }
            if (wordTipo == 3)
            {
                wordText.text = adjs[wordChoose];
            }
            if (wordTipo == 4)
            {
                wordText.text = advs[wordChoose];
            }
            if (wordTipo == 5)
            {
                wordText.text = preps[wordChoose];
            }
            actualTime = 0f;
        }
    }

    public void SumarPuntos(int puntos) 
    {
        puntosActual += puntos;
        puntosNumber.text = puntosActual.ToString();
        if (puntosActual % 5 == 0)
        {
            generateTime -= 0.2f;
        }
        if(generateTime <= 1f) 
        {
            generateTime = 1f;
        }
    }
}
