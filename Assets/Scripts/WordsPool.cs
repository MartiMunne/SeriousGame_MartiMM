using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsPool : MonoBehaviour
{
    //Crear pool
    [SerializeField] private List<GameObject> wordPrefabs;
    [SerializeField] private int poolSizePorTipo = 4;
    [SerializeField] private List<GameObject> wordsList;
    private GameObject word;

    //Instance pool
    private static WordsPool instancePool;
    public static WordsPool InstancePool { get { return instancePool; } }

    private void Awake()
    {
        if (instancePool == null)
        {
            instancePool = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //Llenar pool
        wordsList = new List<GameObject>();
        AddBalasToPool();
    }

    //Anadir las palabras a la pool
    private void AddBalasToPool() 
    {
        //Por cada espacio de la lista wordPrefabs(5 en total) pone 4 palabras del tipo correspondiente en la lista
        for (int i = 0; i < wordPrefabs.Count; i++)
        {
            for(int j = 0; j < poolSizePorTipo; j++) 
            { 
               word = Instantiate(wordPrefabs[i]);
               word.SetActive(false);
               wordsList.Add(word);
               word.transform.parent = transform;
            }
        }
    }

    //Cada X tiempo se generara una palabra de diferente cada tipo dependiendo de un número aleatorio
    public GameObject RequestWord(int tipoWord) 
    {
        //Si el tipo de palabra es menos de 1 o mas de 5, no devuelve nada
        if (tipoWord < 1 || tipoWord > wordPrefabs.Count)
        {
            return null;
        }

        //Calcula el rango de posicion en la lista del tipo de palabra requerido
        int startIndex = (tipoWord - 1) * poolSizePorTipo;
        int endIndex = startIndex + poolSizePorTipo;

        //En el rango seleccionado, activa las palabras disponibles
        for (int i = startIndex; i < endIndex; i++) 
        {
            if (!wordsList[i].activeSelf) 
            { 
                wordsList[i].SetActive(true);
                return wordsList[i];
            }
        }
        return null;
    }
}
