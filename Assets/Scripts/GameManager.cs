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
    [SerializeField] private float generateTime = 3f;
    [SerializeField] private float actualTime = 0f;
    [SerializeField] private int wordTipo = 0;

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
            float posX = Random.Range(-rangoX, rangoX);
            GameObject word = WordsPool.InstancePool.RequestWord(wordTipo);
            word.transform.position = new Vector2(posX, posY);
            actualTime = 0f;
        }
    }
}
