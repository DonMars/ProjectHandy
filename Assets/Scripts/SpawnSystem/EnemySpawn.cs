
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] preFabs = new GameObject[2];

    [SerializeField] private int ProbabilidadPrimerEnemigo;
    [SerializeField] private int cantidadEnemigos;
    [SerializeField] private int spawnRate;

    [SerializeField] private Transform minPos;
    [SerializeField] private Transform maxPos;
    private Vector3 ZonaMin;
    private Vector3 ZonaMax;
    private Vector3 posicionAleatoria;

    [SerializeField]private int contCollider;

    [SerializeField] private Transform parentSpawn;

    private void Start()
    {
        IncializarVectores();
        //StartCoroutine(Spawn());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            contCollider++;
            StartCoroutine(Spawn());
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            StartCoroutine(EliminarPersonajes());
            
        }
    }
    private void IncializarVectores()
    {
        ZonaMin = minPos.position;
        ZonaMax = maxPos.position;
    }
    Vector3 PosicionAleatoria()
    {
        float posX = Random.Range(ZonaMin.x, ZonaMax.x);
        float posy = Random.Range(ZonaMin.y, ZonaMax.y);
        float posz = Random.Range(ZonaMin.z, ZonaMax.z);

        return posicionAleatoria = new Vector3(posX, posy, posz);

    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < cantidadEnemigos; i++)
        {
            if (ProbabilidadPrimerEnemigo >= RandomNum())
            {
                GameObject object1 = Instantiate(preFabs[0],PosicionAleatoria(),Quaternion.identity);
                object1.transform.SetParent(parentSpawn);
                Patrullaje patrullaje = object1.GetComponent<Patrullaje>();
                patrullaje.ZonaMax = ZonaMax;
                patrullaje.ZonaMin = ZonaMin;


            }
            else
            {
                GameObject object1 = Instantiate(preFabs[1], PosicionAleatoria(), Quaternion.identity);
                object1.transform.SetParent(parentSpawn);
                Patrullaje patrullaje = object1.GetComponent<Patrullaje>();
                patrullaje.ZonaMax = ZonaMax;
                patrullaje.ZonaMin = ZonaMin;

            }
            yield return new WaitForSeconds(spawnRate);
        }
    }
    private IEnumerator EliminarPersonajes()
    {
        foreach(Transform child in parentSpawn)
        {
            Destroy(child.gameObject);
        }

        yield return new WaitForSeconds(spawnRate);
    }
    private int RandomNum() // Lo unico que hace es darte un random
    {
        int num = Random.Range(1, 10);
        return num;
    }

    public void InstanceEnemy()
    {
        
        if (ProbabilidadPrimerEnemigo >= RandomNum())
        {
            GameObject object1 = Instantiate(preFabs[0], PosicionAleatoria(), Quaternion.identity);
            object1.transform.SetParent(parentSpawn);
            Patrullaje patrullaje = object1.GetComponent<Patrullaje>();
            patrullaje.ZonaMax = ZonaMax;
            patrullaje.ZonaMin = ZonaMin;


        }
        else
        {
            GameObject object1 = Instantiate(preFabs[1], PosicionAleatoria(), Quaternion.identity);
            object1.transform.SetParent(parentSpawn);
            Patrullaje patrullaje = object1.GetComponent<Patrullaje>();
            patrullaje.ZonaMax = ZonaMax;
            patrullaje.ZonaMin = ZonaMin;

        }
    }

}
