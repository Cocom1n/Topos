using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float runSpeed=7;    //velocidad de movimiento del personaje
    [SerializeField] public float jumpSpeed=10;   //Velocidad de salto
    [SerializeField] private float vidaPlayer=5;
    [SerializeField] Rigidbody2D rb2D;   //referencia al Rb2D del personaje
    private bool dobleSalto;
    private bool dobleSaltoPermitido;
    [SerializeField] private GameObject panelPerder;

    public SpriteRenderer spriteRenderer;
    public Animator animator;
 
    void Start()
    {
        dobleSaltoPermitido = false;
        panelPerder.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        //salto
        if(Input.GetKey("space"))
        {
            if(checkGround.isGrounded)
            {
                dobleSalto = true;
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            }
            else if(Input.GetKeyDown("space") && dobleSalto && dobleSaltoPermitido)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed+4);
                dobleSalto = false;
            }
            
        }

        if(checkGround.isGrounded==false)
        {   
            animator.SetBool("jump", true);
            animator.SetBool("walk", false);
        }
        if(checkGround.isGrounded==true)
        {   
            animator.SetBool("jump", false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movimiento hacia la derecha
        if(Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("walk", true);  //Establece que la animacion que se reproducira cuando se ejecute este movimiento
        }
        
        //Movimiento hacia la izquierda
        else if(Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("walk", true);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("walk", false); //si walk o jump son falsas el personaje se mostrara en un estado idle
        }

        
    }

    public void quitarVida()
    {
        vidaPlayer--;
        Debug.Log(vidaPlayer);
        if(vidaPlayer == 0)
        {
            Destroy(gameObject);
            panelPerder.SetActive(true);
            Time.timeScale = 0;
            
        }
    }

    public void setSalto(bool permitidoSaltar)
    {
        dobleSaltoPermitido = permitidoSaltar;
    }
}
