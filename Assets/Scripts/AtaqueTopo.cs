using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueTopo : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("ataqueTopo", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("ataqueTopo", false);
        }
    }
}
