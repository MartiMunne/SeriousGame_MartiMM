using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvScript : MonoBehaviour
{
    [SerializeField] private float wordSpeed = 3f;
    [SerializeField] private Rigidbody2D rbWord;

    private void OnEnable()
    {
        rbWord.velocity = Vector2.down * wordSpeed;
    }

    void OnCollisionEnter2D(Collision2D col) 
    {
        if(col.gameObject.tag == "Adv")
        {
            gameObject.SetActive(false);
        }
        if(col.gameObject.tag == "WordLimit")
        {
            gameObject.SetActive(false);
        }
    }
}
