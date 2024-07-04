using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainPanel : MonoBehaviour
{
    //Entrada del sonido
    public AudioSource boton;

    //Los paneles del menu de inicio
    public GameObject mainPanel;
    //public GameObject levelSelectPanel;

    //Metodo que cambia de escena segun el nombre que se ponga desde el inspector
    public void PlayLevel(string levelName)
    {
        SceneManager.LoadScene (levelName);
    }
    //quitar el juego
    public void ExitGame()
    {
        Application.Quit();
    }

    //Metodo que cambia entre los paneles del menu de inicio
    /*
    public void OpenPanel (GameObject panel)
    {
        mainPanel.SetActive(false);
        levelSelectPanel.SetActive(false);

        panel.SetActive(true);
    }*/

    //Metodo que se encarga de reproducir un sonido cuando se preciona un boton del canvas
    public void botonSonido ()
    {
        boton.Play();
    }
}
