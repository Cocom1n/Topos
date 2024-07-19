using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zonaAntorcha : MonoBehaviour
{
    [SerializeField] GameObject enemigo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            if (collision.GetComponent<Enemigos>().nombreEnemigo == "topo")
            {
                enemigo.GetComponent<MovMole>().SetEnemigoCegado(true);
            }
            if (collision.GetComponent<Enemigos>().nombreEnemigo == "spider")
            {
                enemigo.GetComponent<MovSpider>().SetEnemigoCegado(true);
            }
        }   
    }

}

