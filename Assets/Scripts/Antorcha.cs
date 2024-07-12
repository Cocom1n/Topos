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

    void Start()
    {
        antorchaApagada.SetActive(true);
        antorchaEncendida.SetActive(false);
        sePuedeEnceder = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && sePuedeEnceder == true)
        {
            contardAntorcha.SumarAntorcha(cantidadAntorcha);
            antorchaApagada.SetActive(false);
            antorchaEncendida.SetActive(true);
            sePuedeEnceder = false;
        }
    }

    public int GetAntorcha()
    {
        return cantidadAntorcha;
    }
}
