using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DesbloquearPuerta : MonoBehaviour
{
    [SerializeField] private string nombre;
    [SerializeField] private Transform punto;
    [SerializeField] private float velocidad;


    private void Start()
    {
        velocidad = 3f;
    }

    void Update ()
    {
        if (nombre == "puerta" && GameManager.Instance.antorchaTotales == 7)
        {
                Destroy(gameObject);
        }

        if (nombre == "pared" && GameManager.Instance.eventoAra�aCompletado == true)
        {
                Destroy(gameObject);
        }

        if (nombre == "bloque" && GameManager.Instance.eventoAra�a == true)
        {
            transform.position = Vector3.MoveTowards(transform.position,punto.position,velocidad * Time.deltaTime);
        }

        if (nombre == "bloqueEvento" && GameManager.Instance.eventoAra�aCompletado == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, punto.position, velocidad * Time.deltaTime);
        }
    }
}
