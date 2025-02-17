using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Variables cambio de lapiz
    public int lapizActual = 1;
    public Sprite[] _sprites;
    SpriteRenderer playerSprite;

    //Movimiento
    public float speed;

    //Disparo
    public Transform balaInstantiate;
    [SerializeField] private AudioSource audioShoot;

    void Awake()
    {
        playerSprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        //Cambio de lapiz

        //Cambio con teclas
        for (KeyCode key = KeyCode.Alpha1; key <= KeyCode.Alpha5; key++)
        {
            if(Input.GetKeyDown(key))
            {
                int keyNumber = key - KeyCode.Alpha0;
                lapizActual = keyNumber;
            }
        }

        //Cambio con rueda del raton
        if (Input.GetAxis("Mouse ScrollWheel") > 0f ) //Rueda arriba
        {
            lapizActual++;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) //Rueda abajo
        {
            lapizActual--;
        }

        //Cambio del sprite segun el paliz actual
        //Por cada valor del lapiz, cambia al sprite pertinente
        switch (lapizActual)
        {
            case 1:
                playerSprite.sprite = _sprites[0];
                break;
            case 2:
                playerSprite.sprite = _sprites[1];
                break;
            case 3:
                playerSprite.sprite = _sprites[2];
                break;
            case 4:
                playerSprite.sprite = _sprites[3];
                break;
            case 5:
                playerSprite.sprite = _sprites[4];
                break;
            default:
                playerSprite.sprite = _sprites[0];
                break;
        }

        //Evita que el valor del lapiz sea menor de 1
        if (lapizActual <= 0)
        {
            lapizActual = 5;
        }

        //Evita que el valor del lapiz sea mayor de 5
        if (lapizActual >= 6)
        {
            lapizActual = 1;
        }

        //Disparo
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            audioShoot.Play();

            //Dependiendo del lapiz actual se dispara un tipo de bala distinto
            if (lapizActual == 1)
            {
                GameObject bala = BalasPool.InstancePool.RequestBala(1);
                bala.transform.position = balaInstantiate.position;
            }
            if (lapizActual == 2)
            {
                GameObject bala = BalasPool.InstancePool.RequestBala(2);
                bala.transform.position = balaInstantiate.position;
            }
            if (lapizActual == 3)
            {
                GameObject bala = BalasPool.InstancePool.RequestBala(3);
                bala.transform.position = balaInstantiate.position;
            }
            if (lapizActual == 4)
            {
                GameObject bala = BalasPool.InstancePool.RequestBala(4);
                bala.transform.position = balaInstantiate.position;
            }
            if (lapizActual == 5)
            {
                GameObject bala = BalasPool.InstancePool.RequestBala(5);
                bala.transform.position = balaInstantiate.position;
            }
        }
    }

    private void FixedUpdate() 
    {
        //Mueve el lapiz hacia los lados a la velocidad establecida
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(moveX, 0, 0);
    }
}
