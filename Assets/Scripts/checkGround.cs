using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour
{
    //Script que se encarga de verificar si el jugador esta colicionando con las plataformas
    
    [SerializeField] public static bool isGrounded; //Static significa que la variable puede ser usada en otros scripts
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
