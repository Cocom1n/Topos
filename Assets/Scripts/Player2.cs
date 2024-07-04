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
    private bool puedeRecibirDa�o;
    private float cooldownDa�o;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        vidaMaxima = 5f;
        vidaJugador = vidaMaxima;
        puedeRecibirDa�o = true;
        cooldownDa�o = 3f;
        offSet = 75;
        spriteRenderer = GetComponent<SpriteRenderer>();

        Transform PosCorazon = posicionPrimerCorazon;

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
            if (!puedeRecibirDa�o)
            {
                return;
            }

            puedeRecibirDa�o = false;
            Color color = spriteRenderer.color;
            color.a = 0.5f;
            spriteRenderer.color = color;
            Destroy(myCanvas.transform.GetChild((int)vidaJugador + 1).gameObject);
            vidaJugador -= collision.GetComponent<EnemigoTopo>().da�oCausado;
            gameObject.GetComponent<PlayerController>().AplicarGolpe();

            if (vidaJugador <= 0)
            {
                Destroy(gameObject);
                Destroy(Corazon);
            }

            Invoke("ActivarDa�o", cooldownDa�o);
        }
    }

    void ActivarDa�o()
    {
        puedeRecibirDa�o = true;
        Color c = spriteRenderer.color;
        c.a = 1f;
        spriteRenderer.color = c;
    }
}