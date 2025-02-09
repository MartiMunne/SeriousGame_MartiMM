using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaScript : MonoBehaviour
{
    [SerializeField] private float balaSpeed = 25f;
    [SerializeField] private Rigidbody2D rbBala;

    private void OnEnable()
    {
        rbBala.velocity = Vector2.up * balaSpeed;
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        gameObject.SetActive(false);
    }
}
