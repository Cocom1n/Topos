using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilarAttak : MonoBehaviour
{
    public bool active = false;
    private int speed = 6;
    public Transform[] puntos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ataque");
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator ataque()
    {
        int i = 1;
        Vector3 puntoObjetivo = new Vector3(transform.position.x, puntos[i].position.y);
        while (true)
        {
            if (active == true)
            {
                while (transform.position != puntoObjetivo)
                {
                    
                    transform.position = Vector3.MoveTowards(transform.position, puntoObjetivo, speed * Time.deltaTime);
                    yield return null;
                }
                yield return new WaitForSeconds(2);
                if (i < 1) i++; else i = 0;
                puntoObjetivo = new Vector3(transform.position.x, puntos[i].position.y);

            }
            yield return null;
        }
    }
}
