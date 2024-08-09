
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class EnemySpawn : MonoBehaviour
{
    

    public GameObject objectToSpawn1;  // Primer prefab del objeto a instanciar
    public GameObject objectToSpawn2;  // Segundo prefab del objeto a instanciar
    public float probabilidadEnemDeDies;
    public int numberOfObjects = 10;   // Número de objetos a instanciar
    public float spawnRadius = 10f;    // Radio en el que se instanciarán los objetos

    private NavMeshTriangulation navMeshData;
    

    public BoxCollider spawnArea;
    public Transform padreObjetos;
    public float spawnRate;
    

    void Start()
    {
        // Obtener los datos del NavMesh
        navMeshData = NavMesh.CalculateTriangulation();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entró en el collider es el jugador
        if (other.CompareTag("Player"))
        {
            
            StartCoroutine(RateVoid());
        }
    }
    IEnumerator RateVoid()
    {

        for (int i = 0; i < numberOfObjects; i++)
        {
            // Elegir aleatoriamente cuál prefab instanciar
            GameObject selectedPrefab = GetRandomPrefab();

            // Obtener una posición random sobre el NavMesh
            Vector3 randomPosition = GetRandomPointOnNavMesh();

            // Instanciar el prefab seleccionado
            Instantiate(selectedPrefab, randomPosition, Quaternion.identity, padreObjetos);
            yield return new WaitForSeconds(spawnRate);

        }
        
        
    }
    private void OnTriggerExit(Collider other)
    {
        
       if(other.CompareTag("Player"))
       {
            foreach(Transform child in padreObjetos)
            {
                Destroy(child.gameObject);
            }
       }
       
    }

    GameObject GetRandomPrefab()
    {
        // Seleccionar uno de los dos prefabs de manera aleatoria
        if (probabilidadEnemDeDies >= randomNum())
        {
            return objectToSpawn1;


        }
        else
        {
            return objectToSpawn1;

        }
        
    }

    Vector3 GetRandomPointOnNavMesh()
    {
        Vector3 randomPoint = new Vector3(Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x), spawnArea.bounds.center.y, Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z));

        NavMeshHit hit;
        if(NavMesh.SamplePosition(randomPoint, out hit, 0.1f, NavMesh.AllAreas))
        {
            return hit.position;
        }
        return randomPoint;
    }

    private float randomNum()
    {
        return Random.Range(1,10);
    }

    private void OnDrawGizmos()
    {
        if (spawnArea != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(spawnArea.bounds.center, spawnArea.bounds.size);
        }
    }



}
