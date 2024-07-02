using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    private SpriteRenderer playerSprite;
    private BoxCollider2D colliderbox;
    public Animator animator;
    public GameObject espada;

    private float cooldown = 1f;
    private float nextAtack = 0f;
    void Start()
    {
        playerSprite = transform.root.GetComponent<SpriteRenderer>();
        colliderbox  = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time>=nextAtack)
        {
            attack();
        }
      

        if(playerSprite.flipX == true)
        {
            espada.transform.rotation = Quaternion.Euler(0,180,0);
        }
        else
        {
            espada.transform.rotation = Quaternion.Euler(0,0,0);

        }
    }

    private void attack()
    {
        animator.SetBool("attack", true);
        colliderbox.enabled = true;
        Invoke("offattack",0.5f);
        nextAtack = Time.time + cooldown;
    }

    public void offattack()
    {
        animator.SetBool("attack", false);
        colliderbox.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            other.gameObject.GetComponent<Damage>().restarVida();
            colliderbox.enabled = false;
        }
    }
}
