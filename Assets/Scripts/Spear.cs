using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public bool left = true;
    public Transform puntos;
    public Transform boss;
    private int speed=7;
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
    
        Vector3 puntoObjetivo = new Vector3(puntos.position.x, transform.position.y);
        while (true)
        {
          
            
                while (transform.position != puntoObjetivo)
                {

                    transform.position = Vector3.MoveTowards(transform.position, puntoObjetivo, speed * Time.deltaTime);
                    yield return null;
                }
                yield return new WaitForSeconds(2);
              
                puntoObjetivo = new Vector3(puntos.position.x, transform.position.y);
        }
    }

}
