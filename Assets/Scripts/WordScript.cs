using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordScript : MonoBehaviour
{
    [SerializeField] private float wordSpeed = 3f;
    [SerializeField] private Rigidbody2D rbWord;
    [SerializeField] private string balaTag;
    private void OnEnable()
    {
        rbWord.velocity = Vector2.down * wordSpeed;
    }

    void OnCollisionEnter2D(Collision2D col) 
    {
        if(col.gameObject.tag == balaTag)
        {
            gameObject.SetActive(false);
            GameManager.gameManager.SumarPuntos(1);
        }
        if(col.gameObject.tag == "WordLimit")
        {
            gameObject.SetActive(false);
            SceneManaging.sceneManaging.Lose();
        }
    }
}
