using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    public float vidaMaxima;
    public int antorchaTotales;
    public bool eventoAra�a;
    public bool eventoAra�aCompletado;

private void Awake()
    {
        if (GameManager.Instance == null)
        {
            GameManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void restarVida(float vidaRestar)
    {
        vidaMaxima -= vidaRestar;
    }

    public void sumarVida(float vidaSumar)
    {
        vidaMaxima += vidaSumar;
    }

    public void sumarAntorcha(int antorchaSumada)
    {
        antorchaTotales += antorchaSumada;
    }

    public void ActivarEvento()
    {
        eventoAra�a = true;
    }

    public void EventoCompletado()
    {
        eventoAra�aCompletado = true;
    }
}
