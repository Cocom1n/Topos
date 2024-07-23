using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Conejo : MonoBehaviour
{
    private bool jugadorDentroDelRango;
    [SerializeField] private GameObject panelDialogo;
    [SerializeField] private GameObject imgElric;
    [SerializeField] private GameObject imgConejo;
    [SerializeField] private TMP_Text textoDeDialogo;
    [SerializeField, TextArea(4,6)] private string[] lineas;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject player;
    [SerializeField] private string nombre;
    [SerializeField] private GameObject boton;
    [SerializeField] private GameObject boton2;

    private bool dialogoIniciado;
    private int lineasIndex;


    void Update()
    {
        if(jugadorDentroDelRango && Input.GetButtonDown("Fire2"))
        {
            if(!dialogoIniciado)
            {
                IniciarDialogo();
            }
            else if(textoDeDialogo.text == lineas[lineasIndex])
            {
                SiguienteDialogo();
            }
            else
            {
                StopAllCoroutines();
                textoDeDialogo.text = lineas[lineasIndex];
            }
            
        }
    }

    private void IniciarDialogo()
    {
        if (nombre == "conejo")
        {
            dialogoIniciado = true;
            panelDialogo.SetActive(true);
            animator.SetBool("PuedeHablar", false);
            lineasIndex = 0;
            StartCoroutine(MostrarLinea());
            Time.timeScale = 0;
        }

        if (nombre == "conejoEvento")
        {
            dialogoIniciado = true;
            panelDialogo.SetActive(true);
            animator.SetBool("PuedeHablar", false);
            lineasIndex = 0;
            StartCoroutine(MostrarLinea());
            Time.timeScale = 0;
        }
    }

    private void SiguienteDialogo()
    {
        if (nombre =="conejo")
        {
            lineasIndex++;
            if (lineasIndex < lineas.Length)
            {
                StartCoroutine(MostrarLinea());
            }
            else
            {
                dialogoIniciado = false;
                panelDialogo.SetActive(false);
                animator.SetBool("PuedeHablar", true);
                Time.timeScale = 1;
                player.gameObject.GetComponent<PlayerController>().setSalto(true);
            }
            if (lineasIndex % 2 == 0)
            {
                Debug.Log("elric");
                imgElric.SetActive(true);
                imgConejo.SetActive(false);
            }
            if (lineasIndex % 2 != 0)
            {
                Debug.Log("conejo");
                imgConejo.SetActive(true);
                imgElric.SetActive(false);
            }
        }

        if (nombre == "conejoEvento")
        {
            lineasIndex++;
            if (lineasIndex < lineas.Length)
            {
                StartCoroutine(MostrarLinea());
            }
            else
            {
                dialogoIniciado = false;
                panelDialogo.SetActive(false);
                animator.SetBool("PuedeHablar", true);
                boton.SetActive(false);
                boton2.SetActive(false);
                Time.timeScale = 1;
            }
            if (lineasIndex == 0)
            {
                imgElric.SetActive(false);
                imgConejo.SetActive(true);
            }
            if (lineasIndex == 1)
            {
                imgConejo.SetActive(false);
                imgElric.SetActive(true);
            }
            if (lineasIndex == 2)
            {
                imgElric.SetActive(false);
                imgConejo.SetActive(true);
                boton.SetActive(true);
                boton2.SetActive(true);
            }
        }

    }

    private IEnumerator MostrarLinea()
    {
        textoDeDialogo.text = string.Empty;
        foreach(char ch in lineas[lineasIndex])
        {   
            textoDeDialogo.text += ch;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            jugadorDentroDelRango = true;
            animator.SetBool("PuedeHablar", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            jugadorDentroDelRango = false;
            animator.SetBool("PuedeHablar", false);
        }
    }

    public void SalirDialogo()
    {
        dialogoIniciado = false;
        panelDialogo.SetActive(false);
        animator.SetBool("PuedeHablar", true);
        boton.SetActive(false);
        boton2.SetActive(false);
        Time.timeScale = 1;
    }
}
