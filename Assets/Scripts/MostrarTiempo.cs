using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MostrarTiempo : MonoBehaviour
{
    private float tiempo;
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textMesh.text = tiempo.ToString("00");
    }

    public void TotalTiempo(float tiempoActual)
    {
        tiempo = tiempoActual;
    }
}
