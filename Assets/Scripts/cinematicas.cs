using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cinematicas : MonoBehaviour
{
    [SerializeField] private GameObject AnimacionElric;
    [SerializeField] private GameObject AnimacionCiudad;
    [SerializeField] private GameObject panelDialogo;
    [SerializeField] private TMP_Text textoDeDialogo;
    [SerializeField, TextArea(4,5)] private string[] lineas;
    private bool dialogoIniciado;
    [SerializeField] private GameObject panelDialogo2;
    [SerializeField] private TMP_Text textoDeDialogo2;
    [SerializeField, TextArea(4,5)] private string[] lineas2;
    
    private bool dialogoIniciado2;
    private int lineasIndex2;
    private bool dialogo1Terminado = false;
    private int lineasIndex;

    void Start()
    {
        //dialogo1Terminado = false;
        Time.timeScale = 1;
        AnimacionCiudad.SetActive(true);
        AnimacionElric.SetActive(false);
        panelDialogo.SetActive(false);
        panelDialogo2.SetActive(false);
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && !dialogo1Terminado)
        {
            if(!dialogoIniciado)
            {
                IniciarNarracion();
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

        if(Input.GetButtonDown("Fire1") && dialogo1Terminado)
        {
            if(!dialogoIniciado2)
            {
                IniciarSegundaNarracion();
            }
            else if(textoDeDialogo2.text == lineas2[lineasIndex2])
            {
                SiguienteDialogo2();
            }
            else
            {
                StopAllCoroutines();
                textoDeDialogo2.text = lineas2[lineasIndex2];
            }
        }
    }

    private void IniciarNarracion()
    {
        dialogoIniciado = true;
        panelDialogo.SetActive(true);
        lineasIndex = 0;
        StartCoroutine(MostrarLinea());
    }

    private void SiguienteDialogo()
    {
        lineasIndex++;
        if(lineasIndex < lineas.Length)
        {
            StartCoroutine(MostrarLinea());
        }
        else
        {
            dialogoIniciado = false;
            panelDialogo.SetActive(false);
            AnimacionCiudad.SetActive(false);
            StartCoroutine(EsperarYIniciarSegundaNarracion());
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

    private IEnumerator EsperarYIniciarSegundaNarracion()
    {
        AnimacionElric.SetActive(true);
        yield return new WaitForSeconds(1f);
        dialogo1Terminado = true;
        //IniciarSegundaNarracion();
    }

    private void IniciarSegundaNarracion()
    {
        dialogoIniciado2 = true;
        panelDialogo2.SetActive(true);
        lineasIndex2 = 0;
        AnimacionElric.SetActive(false);
        StartCoroutine(MostrarLinea2());
    }

    private void SiguienteDialogo2()
    {
        lineasIndex2++;
        if(lineasIndex2 < lineas2.Length)
        {
            StartCoroutine(MostrarLinea2());
        }
        else
        {
            dialogoIniciado2 = false;
            panelDialogo2.SetActive(false);
        }
    }

    private IEnumerator MostrarLinea2()
    {
        textoDeDialogo2.text = string.Empty;
        foreach(char ch in lineas2[lineasIndex2])
        {
            textoDeDialogo2.text += ch;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }
}

