using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntradaEventoAraña : MonoBehaviour
{
    private void Start()
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(6);
        }
    }

    public void ActivarEntrada()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
