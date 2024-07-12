using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesbloquearPuerta : MonoBehaviour
{
    [SerializeField] private GameObject antorchaTotales;

    void Update ()
    {
        if (antorchaTotales.GetComponent <ContarAntorcha>().GetAntorcha() == 7)
        {
            Destroy(gameObject);
        }
    }
}
