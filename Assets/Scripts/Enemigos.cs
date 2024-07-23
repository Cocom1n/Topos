using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    [SerializeField] private float healthPoints;
    [SerializeField] public float da�oCausado;
    [SerializeField] public string nombreEnemigo;


    void Start()
    {
        if (nombreEnemigo == "spider")
        {
            da�oCausado = 1f;
            healthPoints = 1f;
        }
        if (nombreEnemigo == "topo")
        {
            da�oCausado = 5f;
        }
        if (nombreEnemigo == "topoLentes")
        {
            da�oCausado = 10f;
        }
        if (nombreEnemigo == "topoArmadura")
        {
            da�oCausado = 10f;
        }

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
