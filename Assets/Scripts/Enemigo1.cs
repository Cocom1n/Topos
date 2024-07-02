using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    public Transform pointA; 
    public Transform pointB; 

    public float speed = 5f; 

    private bool movingToA = true; 
    public SpriteRenderer spriteRenderer;
    public Animator animator;
     void Start()
    {
        StartCoroutine(patrullaje());
    }

    IEnumerator patrullaje()
    {
        while (true) // mantiene la siguiente accion en un loop infinito

        {   
            Vector3 targetPosition = movingToA ? pointA.position : pointB.position;
            while (transform.position != targetPosition) 
            {
                animator.SetBool("move", true);
                animator.SetBool("ataqueTopo", false);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            if(movingToA)
            {
                spriteRenderer.flipX = false;
            } else {
                spriteRenderer.flipX = true;
                
            }
            }
            movingToA = !movingToA;//invierte la variable para cambiar el targetPosition
            animator.SetBool("move", false);
            animator.SetBool("ataqueTopo", false);
             
            yield return new WaitForSeconds(1.0f);
        }
    }


}
