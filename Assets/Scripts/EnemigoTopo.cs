using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoTopo : MonoBehaviour
{
    [SerializeField] private float healthPoints;
    [SerializeField] public float da�oCausado;


    void Start()
    {
        da�oCausado = 1f;
    }


    void Update()
    {

    }

    public void TomarDa�o(float da�o)
    {
        healthPoints -= da�o;

        if (healthPoints <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        Destroy(gameObject);
    }
}
