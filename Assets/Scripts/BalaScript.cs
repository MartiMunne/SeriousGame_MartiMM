using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaScript : MonoBehaviour
{
    //Mover la bala
    [SerializeField] private float balaSpeed = 25f;
    [SerializeField] private Rigidbody2D rbBala;

    private void OnEnable()
    {
        //La bala sube a la velocidad establecida
        rbBala.velocity = Vector2.up * balaSpeed;
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        //Se desactiva al colisionar
        gameObject.SetActive(false);
    }
}
