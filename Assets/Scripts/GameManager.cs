using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Instance
    public static GameManager gameManager;

    //Generar palabras
    [SerializeField] private float rangoX = 6.5f;
    [SerializeField] private float posY = 6f;
    [SerializeField] private float generateTime = 2f;
    [SerializeField] private float actualTime = 0f;
    [SerializeField] private int wordTipo = 0;
    [SerializeField] private int wordChoose = 0;

    //Listas de palabras por cada tipo
    [SerializeField] private List<string> susts;
    [SerializeField] private List<string> verbs;
    [SerializeField] private List<string> adjs;
    [SerializeField] private List<string> advs;
    [SerializeField] private List<string> preps;

    //Contador de puntos
    public int puntosActual;
    [SerializeField] private TMP_Text puntosNumber;
    public int recordActual;
    [SerializeField] private TMP_Text recordNumber;
    [SerializeField] private GameObject newRecordText;
    [SerializeField] private GameObject hardcoreText;

    //Instance
    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start() 
    {
        LoadRecord();
        recordNumber.text = recordActual.ToString();
    }

    void Update()
    {
        //El tiempo actual aumenta mediante pasa el tiempo
        actualTime += Time.deltaTime;

        //Si el tiempo actual iguala al tiempo de generacion, spawnea una palabra
        if(actualTime >= generateTime)
        {
            //Genera un numero aleatorio para elegir el tipo de palabra y la palabra que aparecera
            wordTipo = Random.Range(1,6);
            int wordChoose_ = Random.Range(1,11);
            wordChoose = wordChoose_ - 1;

            //Spawnea la palabra en un lugar aleatorio del rango
            float posX = Random.Range(-rangoX, rangoX);
            GameObject word = WordsPool.InstancePool.RequestWord(wordTipo);
            TMP_Text wordText = word.GetComponent<TMP_Text>(); //Coje el componente TMP_Text de la palabra
            word.transform.position = new Vector2(posX, posY);

            //Escribe la palabra correspondiente dependiendo del tipo de palabra
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

            //Reinicia el tiempo actual para que vuelva a contar
            actualTime = 0f;
        }
    }

    public void SumarPuntos(int puntos) 
    {
        //Suma una cantidad de puntos indicada al llamar a la funcion y la escribe en la UI
        puntosActual += puntos;
        puntosNumber.text = puntosActual.ToString();

        //Cada vez que los puntos aumentan en 5 reducen el tiempo de generacion en 0.2
        if (puntosActual % 5 == 0)
        {
            generateTime -= 0.2f;
        }

        //Evita que el tiempo de generacion baje de 1 segundo por debajo de 50 puntos
        if(generateTime <= 1f && puntosActual <= 50) 
        {
            generateTime = 1f;
        }

        //Baja el tiempo de generacion a 0.7 si se pasan los 50 puntos
        if(generateTime <= 1f && puntosActual >= 50)
        {
            generateTime = 0.7f;
            hardcoreText.SetActive(true);
        }

        //Actualiza el record si este se supera
        if(puntosActual > recordActual)
        {
            recordActual = puntosActual;
            recordNumber.text = recordActual.ToString();
            newRecordText.SetActive(true);
            SaveRecord();
        }
    }

    //Guarda el valor del record
    public void SaveRecord()
    {
        PlayerPrefs.SetInt("Record", recordActual);
        PlayerPrefs.Save();
        Debug.Log("Record Saved");
    }

    //Carga el valor del record
    public void LoadRecord()
    {
        recordActual = PlayerPrefs.GetInt("Record", recordActual);
        Debug.Log("Record Loaded");
    }
}
