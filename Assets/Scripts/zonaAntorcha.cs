using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zonaAntorcha : MonoBehaviour
{
    //[SerializeField] GameObject enemigo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            if (collision.GetComponent<Enemigos>().nombreEnemigo == "topo")
            {
                collision.GetComponent<MovMole>().SetEnemigoCegado(true);
            }
            if (collision.GetComponent<Enemigos>().nombreEnemigo == "spider")
            {
                collision.GetComponent<MovSpider>().SetEnemigoCegado(true);
            }
        }   
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemigo")
        {
            if (col.GetComponent<Enemigos>().nombreEnemigo == "spider")
            {
                col.GetComponent<MovSpider>().SetEnemigoCegado(false);
                col.GetComponent<MovSpider>().SetEnemigoCaminando(true);
            }
        }
    }

}

