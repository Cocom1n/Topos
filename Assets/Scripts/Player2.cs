using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    private bool puedeRecibirDaño;
    private float cooldownDaño;
    private SpriteRenderer spriteRenderer;
    public GameObject gameOver;
    public Image barraVida;
    [SerializeField] private GameObject contadorVida;
    void Start()
    {
        gameOver.SetActive(false);
        puedeRecibirDaño = true;
        cooldownDaño = 3f;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        barraVida.fillAmount = GameManager.Instance.vidaMaxima / 100;
        contadorVida.GetComponent<CantidadVida>().TotalVida(GameManager.Instance.vidaMaxima);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            if (!puedeRecibirDaño)
            {
                return;
            }

            puedeRecibirDaño = false;
            Color color = spriteRenderer.color;
            color.a = 0.5f;
            spriteRenderer.color = color;
            if (collision.GetComponent<Enemigos>().nombreEnemigo == "topo")
            {
                GameManager.Instance.restarVida(collision.GetComponent<Enemigos>().dañoCausado);
            }
            if (collision.GetComponent<Enemigos>().nombreEnemigo == "spider")
            {
                GameManager.Instance.restarVida(collision.GetComponent<Enemigos>().dañoCausado);
            }
            if (collision.GetComponent<Enemigos>().nombreEnemigo == "topoLentes")
            {
                GameManager.Instance.restarVida(collision.GetComponent<Enemigos>().dañoCausado);
            }
            if (collision.GetComponent<Enemigos>().nombreEnemigo == "topoArmadura")
            {
                GameManager.Instance.restarVida(collision.GetComponent<Enemigos>().dañoCausado);
            }
            gameObject.GetComponent<PlayerController>().AplicarGolpe();

            if (GameManager.Instance.vidaMaxima <= 0)
            {
                //Destroy(gameObject);
                gameOver.SetActive(true);
                Time.timeScale = 0;
            }

            Invoke("ActivarDaño", cooldownDaño);
        }
        if (collision.CompareTag("AttackBos"))
        {
            if (!puedeRecibirDaño)
            {
                return;
            }

            puedeRecibirDaño = false;
            Color color = spriteRenderer.color;
            color.a = 0.5f;
            spriteRenderer.color = color;
            GameManager.Instance.restarVida(10);
            gameObject.GetComponent<PlayerController>().AplicarGolpe();

            if (GameManager.Instance.vidaMaxima <= 0)
            {
                //Destroy(gameObject);
                gameOver.SetActive(true);
            }

            Invoke("ActivarDaño", cooldownDaño);
        }
        if (collision.CompareTag("Player"))
        {
            if (GameManager.Instance.vidaMaxima<100) 
            {
                GameManager.Instance.sumarVida(collision.GetComponent<ArmadilloVida>().aumentoVida);
                collision.GetComponent<ArmadilloVida>().Muerte();
            }
        }
    }

    void ActivarDaño()
    {
        puedeRecibirDaño = true;
        Color c = spriteRenderer.color;
        c.a = 1f;
        spriteRenderer.color = c;
    }

}
