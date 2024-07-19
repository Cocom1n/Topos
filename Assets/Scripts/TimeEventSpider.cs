using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEventSpider : MonoBehaviour
{
    [SerializeField] private float tiempo;
    [SerializeField] private bool activarTiempo;
    [SerializeField] private GameObject tiempoPantalla;

    void Start()
    {
        tiempo = 10f;
        activarTiempo = false;
        tiempoPantalla.SetActive(false);
    }


    void Update()
    {
        tiempoPantalla.GetComponent<MostrarTiempo>().TotalTiempo(tiempo);
        if (activarTiempo == true && tiempo > 0)
        {
            tiempo -= Time.deltaTime;
        }

        if (tiempo <= 0)
        {
            tiempoPantalla.SetActive(false);
            GameManager.Instance.EventoCompletado();
            GameObject.Find("Araña").GetComponent<MovSpider>().SetEnemigoCegado(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && activarTiempo == false)
        {
            tiempoPantalla.SetActive(true);
            activarTiempo = true;
        }
    }

    public bool ActivarTiempo ()
    {
        return activarTiempo;
    }
}
