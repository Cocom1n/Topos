using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antorcha : MonoBehaviour
{
    [SerializeField] private GameObject antorchaApagada;
    [SerializeField] private GameObject antorchaEncendida;
    [SerializeField] private int cantidadAntorcha;
    [SerializeField] private ContarAntorcha contardAntorcha;
    [SerializeField] private bool sePuedeEnceder;
    [SerializeField] private string nombre;
    [SerializeField] private float tiempoEncendido;
    [SerializeField] private bool antorchaEvento;

    void Start()
    {
        antorchaApagada.SetActive(true);
        antorchaEncendida.SetActive(false);
        sePuedeEnceder = true;
        tiempoEncendido = 3;
        antorchaEvento = false;

    }

    private void Update()
    {
        if (tiempoEncendido > 0 && sePuedeEnceder == false && antorchaEvento == true)
        {
            tiempoEncendido -= Time.deltaTime;
        }
        if (tiempoEncendido <= 0)
        {
            tiempoEncendido = 3;
            antorchaApagada.SetActive(true);
            antorchaEncendida.SetActive(false);
            sePuedeEnceder = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && sePuedeEnceder == true && nombre == "antorcha")
        {
            GameManager.Instance.sumarAntorcha(cantidadAntorcha);
            antorchaApagada.SetActive(false);
            antorchaEncendida.SetActive(true);
            sePuedeEnceder = false;
        }

        if (collision.gameObject.tag == "Player" && nombre == "antorchaEvento" && sePuedeEnceder == true)
        {
            antorchaApagada.SetActive(false);
            antorchaEncendida.SetActive(true);
            sePuedeEnceder = false;
            antorchaEvento = true;
        }
    }
}
