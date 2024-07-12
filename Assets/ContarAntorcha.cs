using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContarAntorcha : MonoBehaviour
{
    private int antorcha;
    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textMesh.text = "x 0"+ antorcha.ToString();
    }

    public void SumarAntorcha(int antorchaNueva)
    {
        antorcha += antorchaNueva;
    }

    public int GetAntorcha()
    {
        return antorcha;
    }
}
