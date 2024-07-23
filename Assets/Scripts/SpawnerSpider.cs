using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpider : MonoBehaviour
{
    [SerializeField] GameObject araņas;
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

        if (GameManager.Instance.eventoAraņaCompletado == true)
        {
            iniciaSpawn = false;
            Destroy(gameObject);
        }
    }

    IEnumerator SpawnSpider()
    {
        while (iniciaSpawn == false)
        {
            yield return null;
        }

        while (iniciaSpawn == true)
        {
            Instantiate(araņas,transform.position,Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }
}
