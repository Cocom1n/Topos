using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    [SerializeField] private float vidaJugador;
    [SerializeField] private float vidaMaxima;
    public Image Corazon;
    public RectTransform posicionPrimerCorazon;
    public Canvas myCanvas;
    private int offSet;
    private bool puedeRecibirDaño;
    private float cooldownDaño;
    private SpriteRenderer spriteRenderer;
    Transform PosCorazon;
    void Start()
    {
        vidaMaxima = 5f;
        vidaJugador = vidaMaxima;
        puedeRecibirDaño = true;
        cooldownDaño = 3f;
        offSet = 75;
        spriteRenderer = GetComponent<SpriteRenderer>();

        PosCorazon = posicionPrimerCorazon;

        for (int i = 0; i < vidaMaxima; i++)
        {
            Image newCorazon = Instantiate(Corazon, PosCorazon.position, Quaternion.identity);
            newCorazon.transform.SetParent(myCanvas.transform);
            PosCorazon.position = new Vector2(PosCorazon.position.x + offSet, PosCorazon.position.y);
        }
    }

    void Update()
    {
   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            if (!puedeRecibirDaño)
            {
                return;
            }

            puedeRecibirDaño = false;
            Color color = spriteRenderer.color;
            color.a = 0.5f;
            spriteRenderer.color = color;
            Destroy(myCanvas.transform.GetChild((int)vidaJugador + 1).gameObject);
            vidaJugador -= collision.GetComponent<EnemigoTopo>().dañoCausado;
            PosCorazon.position=new Vector2(PosCorazon.position.x - offSet, PosCorazon.position.y);
            gameObject.GetComponent<PlayerController>().AplicarGolpe();

            if (vidaJugador <= 0)
            {
                Destroy(gameObject);
                Destroy(Corazon);
            }

            Invoke("ActivarDaño", cooldownDaño);
        }
        if (collision.CompareTag("Player"))
        {
            if (vidaJugador < vidaMaxima) 
            {
                Transform PosCorazon = posicionPrimerCorazon;
                for (float i = vidaJugador; i < vidaJugador+1; i++)
                {
                    Image newCorazon = Instantiate(Corazon, PosCorazon.position, Quaternion.identity);
                    newCorazon.transform.SetParent(myCanvas.transform);
                    PosCorazon.position = new Vector2(PosCorazon.position.x + offSet, PosCorazon.position.y);
                    collision.GetComponent<ArmadilloVida>().Muerte();
                }
                vidaJugador += collision.GetComponent<ArmadilloVida>().aumentoVida;
            }
        }
    }

    void ActivarDaño()
    {
        puedeRecibirDaño = true;
        Color c = spriteRenderer.color;
        c.a = 1f;
        spriteRenderer.color = c;
    }

    public void AgregarVida()
    {
        vidaJugador += 1;
    }
}
