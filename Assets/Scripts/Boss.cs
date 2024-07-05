using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] puntos; //Puntos a los que se movera el enemigo
    public PilarAttak pilares;
 
    public float speed = 3f;
    public int i = 1; 
    public int random = 3;
    public int lastR = 0;

    void Start()
    {
        StartCoroutine("Moverse");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
        }
    }

    IEnumerator Moverse()
    {   
        Vector3 puntoObjetivo = new Vector3(puntos[i].position.x, puntos[i].position.y);
        while (true)
        {
            lastR = random;
            random = Random.Range(0, 100);
            if (lastR == random)
            {
                random = Random.Range(0, 100);
            }
            while (transform.position != puntoObjetivo)
            {
              

                transform.position = Vector3.MoveTowards(puntoObjetivo, puntoObjetivo, speed * Time.deltaTime);
                yield return null;
            }
            yield return new WaitForSeconds(5);
            pilares.active = false;

            if (random <= 40)
            {
                i = 0;
                
            }
            else if (random > 40 && random < 70)
            {
                i = 1;
            }
            else if (random >= 60 && random < 90)
            {
                i = 2;
            }
            else if (random >= 90)
            {
                i = 3;
                pilares.active = true;
            }
            puntoObjetivo = new Vector3(puntos[i].position.x, puntos[i].position.y);
        }
    }
}
