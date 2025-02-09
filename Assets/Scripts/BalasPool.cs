using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasPool : MonoBehaviour
{
    //Crear pool
    [SerializeField] private List<GameObject> balaPrefabs;
    [SerializeField] private int poolSizePorTipo = 4;
    [SerializeField] private List<GameObject> balasList;
    private GameObject bala;

    //Instance pool
    private static BalasPool instancePool;
    public static BalasPool InstancePool { get { return instancePool; } }

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
        balasList = new List<GameObject>();
        AddBalasToPool();
    }

    //Añadir las balas a la pool
    private void AddBalasToPool() 
    {
        //Por cada espacio de la lista balaPrefabs(5 en total) pone 4 balas del tipo correspondiente en la lista
        for (int i = 0; i < balaPrefabs.Count; i++)
        {
            for(int j = 0; j < poolSizePorTipo; j++) 
            { 
               bala = Instantiate(balaPrefabs[i]);
               bala.SetActive(false);
               balasList.Add(bala);
               bala.transform.parent = transform;
            }
        }
    }

    //Cuando se dispare se generará una bala de diferente tipo dependiendo del lápiz actual
    public GameObject RequestBala(int tipoBala) 
    {
        //Si el tipo de bala es menos de 1 o más de 5, no devuelve nada
        if (tipoBala < 1 || tipoBala > balaPrefabs.Count)
        {
            return null;
        }

        //Calcula el rango de posición en la lista del tipo de bala requerido
        int startIndex = (tipoBala - 1) * poolSizePorTipo;
        int endIndex = startIndex + poolSizePorTipo;

        //En el rango seleccionado, activa las balas disponibles
        for (int i = startIndex; i < endIndex; i++) 
        {
            if (!balasList[i].activeSelf) 
            { 
                balasList[i].SetActive(true);
                return balasList[i];
            }
        }
        return null;
    }
}
