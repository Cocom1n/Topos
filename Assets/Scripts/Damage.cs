using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private int vidas = 2;

    public void restarVida()
    {
        vidas--;
        Debug.Log(vidas);
        if(vidas == 0)
        {
            Destroy(gameObject);
        }
    }

}
