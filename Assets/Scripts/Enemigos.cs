using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    [SerializeField] private float healthPoints;
    [SerializeField] public float dañoCausado;
    [SerializeField] public string nombreEnemigo;


    void Start()
    {
        if (nombreEnemigo == "spider")
        {
            dañoCausado = 1f;
            healthPoints = 1f;
        }
        if (nombreEnemigo == "topo")
        {
            dañoCausado = 5f;
        }
        if (nombreEnemigo == "topoLentes")
        {
            dañoCausado = 10f;
        }
        if (nombreEnemigo == "topoArmadura")
        {
            dañoCausado = 10f;
        }

    }


    void Update()
    {

    }

    public void TomarDaño(float daño)
    {
        healthPoints -= daño;

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
