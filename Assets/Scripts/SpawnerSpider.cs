using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpider : MonoBehaviour
{
    [SerializeField] GameObject ara�as;
    [SerializeField] GameObject detectarInicioEvento;
    [SerializeField] private bool iniciaSpawn;
    void Start()
    {
        iniciaSpawn = false;
        StartCoroutine(SpawnSpider());
    }

   
    void Update()
    {
        if (detectarInicioEvento.GetComponent<TimeEventSpider>().ActivarTiempo() == true)
        {
            iniciaSpawn = true;
        }
    }

    IEnumerator SpawnSpider()
    {
        while (iniciaSpawn == false)
        {
            yield return null;
        }

        while (true)
        {
            Instantiate(ara�as,transform.position,Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }
}
