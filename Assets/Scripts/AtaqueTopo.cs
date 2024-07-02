using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueTopo : MonoBehaviour
{
    public Animator animator;
    private bool jugadorEnRango = false; // Para controlar si el jugador está en el área de ataque
    private GameObject player; // Referencia al jugador

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            jugadorEnRango = true;
            StartCoroutine(DelayedAttack());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnRango = false;
        }
    }

    private IEnumerator DelayedAttack()
    {
        yield return new WaitForSeconds(0.5f); // Esperar 2 segundos
        animator.SetBool("ataqueTopo", true);
        if (jugadorEnRango && player != null) // Verificar si el jugador aún está en el área de ataque
        {
            player.GetComponent<Player>().quitarVida();
        }
    }
/*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DelayedAttack(other.gameObject));
        }
    }

    private IEnumerator DelayedAttack(GameObject player)
    {
        yield return new WaitForSeconds(1.5f); // Esperar 2 segundos
        if (player != null) // Verificar si el jugador aún está en el área de ataque
        {
            animator.SetBool("ataqueTopo", true);
            player.GetComponent<Player>().quitarVida();
        }
    }*/

}
