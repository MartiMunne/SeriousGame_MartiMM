using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordScript : MonoBehaviour
{
    //Mover la palabra
    [SerializeField] private float wordSpeed = 3f;
    [SerializeField] private Rigidbody2D rbWord;

    //Tag de la bala
    [SerializeField] private string balaTag;

    private void OnEnable()
    {
        //Las balas se mueven hacia abajo con la velocidad establecida
        rbWord.velocity = Vector2.down * wordSpeed;
    }

    void OnCollisionEnter2D(Collision2D col) 
    {
        //Comprueba con si ha colisionado con la bala correspondiente
        if(col.gameObject.tag == balaTag)
        {
            //Se desactiva y suma 1 punto
            gameObject.SetActive(false);
            GameManager.gameManager.SumarPuntos(1);
        }

        //Comprueba si ha colisionado con el limite de las palabras
        if(col.gameObject.tag == "WordLimit")
        {
            //Se desactiva y pierde la partida
            gameObject.SetActive(false);
            SceneManaging.sceneManaging.Lose();
        }
    }
}
