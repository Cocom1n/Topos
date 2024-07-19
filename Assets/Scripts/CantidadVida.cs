using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CantidadVida : MonoBehaviour
{
    private float vida;
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textMesh.text = vida.ToString() + "/100";
    }

    public void TotalVida(float vidaActual)
    {
        vida = vidaActual;
    }
}
