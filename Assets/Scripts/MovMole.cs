using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovMole : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Transform sueloEnemigo;
    [SerializeField] private Transform detectarPared;
    [SerializeField] private Transform detectarSuelo;
    [SerializeField] private bool enemigoQuieto;
    [SerializeField] private bool enemigoCaminando;
    [SerializeField] private bool enemigoCegado;
    [SerializeField] private bool paredDetectada;
    [SerializeField] private bool sueloDetectado;
    [SerializeField] private bool estaSuelo;
    [SerializeField] private float radioDeteccion;
    [SerializeField] private LayerMask tipoSuelo;
    private Rigidbody2D rigidEnemigo;
    private Animator anim;
    private bool caminaDerecha;
    [SerializeField] GameObject ataque;

    void Start()
    {
        rigidEnemigo = GetComponent<Rigidbody2D>();
        velocidad = 120f;
        anim = GetComponent<Animator>();
        enemigoCegado = false;
    }

    
    void Update()
    {
        sueloDetectado = !Physics2D.OverlapCircle(sueloEnemigo.position, radioDeteccion, tipoSuelo);
        paredDetectada = Physics2D.OverlapCircle(detectarPared.position, radioDeteccion, tipoSuelo);
        estaSuelo = Physics2D.OverlapCircle(detectarSuelo.position, radioDeteccion, tipoSuelo);

        if (sueloDetectado || paredDetectada && estaSuelo)
        {
            Gira();
        }
    }

    private void FixedUpdate()
    {
        if (enemigoQuieto)
        {
            anim.SetBool("move", false);
            rigidEnemigo.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if (enemigoCaminando)
        {

            rigidEnemigo.constraints = RigidbodyConstraints2D.FreezeRotation;
            anim.SetBool("move", true);
            if (!caminaDerecha)
            {

                rigidEnemigo.velocity = new Vector2(velocidad * Time.deltaTime, rigidEnemigo.velocity.y);
            }
            else
            {
                rigidEnemigo.velocity = new Vector2(-velocidad * Time.deltaTime, rigidEnemigo.velocity.y);
            }
        }
        if (enemigoCegado)
        {
            anim.SetBool("blind",true);
            rigidEnemigo.constraints = RigidbodyConstraints2D.FreezeAll;
            ataque.SetActive(false);
        }
    }

    private void Gira()
    {
        caminaDerecha = !caminaDerecha;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    public void SetEnemigoCegado(bool cegado) 
    {
        enemigoCegado=cegado;
        enemigoCaminando = false;
    }
}
