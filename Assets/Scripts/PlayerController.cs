using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    private float speed;    //velocidad de movimiento del personaje
    private float jumpForce;
    [SerializeField] private LayerMask capaSuelo;
    [SerializeField] private Transform suelo;
    private bool tocarSuelo;
    private float tocarSueloRadio;
    private Animator animator;
    private Rigidbody2D rigidBody;
    private float velX;
    private float velY;
    private float fuerzaGolpe;
    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;
    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private float tiempoSiguienteAtaque;

    private bool dobleSalto;
    private bool dobleSaltoPermitido;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        speed = 5f;
        jumpForce = 7f;
        tocarSueloRadio = 0.2f;
        fuerzaGolpe = 500f;
        if (GameManager.Instance.eventoAraña == true && GameManager.Instance.eventoArañaCompletado == true && SceneManager.GetActiveScene().buildIndex == 5)
        {
            gameObject.transform.position = new Vector3(33.83f, -72.89f, 0f);
        }
    }

    
    void Update()
    {
        tocarSuelo = Physics2D.OverlapCircle(suelo.position, tocarSueloRadio, capaSuelo);
        Flip();

        if (tocarSuelo)
        {
            animator.SetBool("jump", false);
        }
        else
        {
            animator.SetBool("jump", true);
        }

        Ataque();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Jump()
    {
        if(Input.GetKey("space"))
        {
            if(tocarSuelo)
            {
                dobleSalto = true;
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            }
            else if(Input.GetKeyDown("space") && dobleSalto && dobleSaltoPermitido )
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 12);
                dobleSalto = false;
            }
            
        }
    }

    void Move()
    {
        velX = Input.GetAxis("Horizontal");
        velY = rigidBody.velocity.y;
        rigidBody.velocity = new Vector2(velX * speed, velY);

        if (rigidBody.velocity.x != 0)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }

    }

    void Flip()
    {
        if (rigidBody.velocity.x > 1)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (rigidBody.velocity.x < -1)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }




    void Ataque()
    {
        if (tiempoSiguienteAtaque > 0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1") && tiempoSiguienteAtaque <= 0)
        {
            animator.SetBool("attack", true);
            Golpe();
            tiempoSiguienteAtaque = tiempoEntreAtaques;
        }
        else
        {
            animator.SetBool("attack", false);
        }
    }

    public void AplicarGolpe()
    {

        Vector2 direccionGolpe;

        if (rigidBody.velocity.x > 0)
        {
            direccionGolpe = new Vector2(-1, 1);
        }
        else
        {
            direccionGolpe = new Vector2(1, 1);
        }

        rigidBody.AddForce(direccionGolpe * fuerzaGolpe);

    }

    private void Golpe()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemigo"))
            {
                colisionador.transform.GetComponent<Enemigos>().TomarDaño(dañoGolpe);

            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioGolpe);
    }

    public void setSalto(bool permitidoSaltar)
    {
        dobleSaltoPermitido = permitidoSaltar;
    }
}
