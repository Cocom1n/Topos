using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovTopo : MonoBehaviour
{
    [SerializeField] Transform[] puntos;
    [SerializeField] float velocidad;
    [SerializeField] bool espera;

    void Start()
    {
        //velocidad = 3f;
        StartCoroutine("MueveTopo");
        espera = false;
        StartCoroutine("EnemigoCamina");
    }

    private void Update()
    {
        if (espera == true)
        {
            velocidad = 0;
            //espera = false;
        }
        else
        {
            velocidad = 4;
        }
    }

    IEnumerator MueveTopo()
    {
            int i = 1;
            Vector2 nuevaPosicion = new Vector2(puntos[i].position.x, puntos[i].position.y);
            while (true)
            {
                while (Vector2.Distance(transform.position, nuevaPosicion) > 0.001f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, nuevaPosicion, velocidad * Time.deltaTime);
                    yield return null;
                }
                yield return new WaitForSeconds(1);
                if (i < 1) i++; else i = 0;
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                nuevaPosicion = new Vector2(puntos[i].position.x, puntos[i].position.y);
            }
    }
    public void SetEspera( bool esperar)
    {
        espera = esperar;
    }
}
