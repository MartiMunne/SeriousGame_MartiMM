using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoScript : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform balaInstantiate;
    public float balaSpeed;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("PUM");
            var bala = Instantiate(balaPrefab, balaInstantiate.position, balaInstantiate.rotation);
            bala.GetComponent<Rigidbody2D>().velocity = balaInstantiate.up * balaSpeed;
        }
    }
}
