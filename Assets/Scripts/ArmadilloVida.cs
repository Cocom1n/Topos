using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadilloVida : MonoBehaviour
{
    //[SerializeField] GameObject player;

    [SerializeField] public int aumentoVida;

    private void Start()
    {
        aumentoVida = 10;
    }


    public void Muerte()
    {
        Destroy(gameObject);    
    }
}
