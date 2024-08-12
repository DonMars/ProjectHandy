
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject objetoParaGenerar1;  // Primer prefab del objeto a instanciar
    [SerializeField] private GameObject objetoParaGenerar2;  // Segundo prefab del objeto a instanciar
    [SerializeField] private float probabilidadDeGenerar1;  // Probabilidad de generación del primer prefab
    [SerializeField] private int numeroDeObjetos = 10;   // Número de objetos a instanciar
    [SerializeField] private BoxCollider areaDeGeneracion; // Área dentro de la cual se generarán los objetos
    [SerializeField] private Transform padreDeObjetos; // Transform que actuará como el padre de los objetos generados
    [SerializeField] private float tasaDeGeneracion; // Tiempo entre la generación de cada objeto

    private NavMeshTriangulation datosDelNavMesh;

    void Start()
    {
        // Obtener los datos del NavMesh al inicio
        datosDelNavMesh = NavMesh.CalculateTriangulation();
    }

    private void OnTriggerEnter(Collider otro)
    {
        if (otro.CompareTag("Player"))
        {
            Debug.Log("Player ha entrado en el área de generación.");
            StartCoroutine(GenerarObjetos());
        }
    }

    IEnumerator GenerarObjetos()
    {
        for (int i = 0; i < numeroDeObjetos; i++)
        {
            GameObject prefabSeleccionado = ObtenerPrefabAleatorio();
            Vector3 posicionAleatoria = ObtenerPuntoAleatorioEnNavMesh();

            if (prefabSeleccionado != null && padreDeObjetos != null)
            {
                GameObject instancia = Instantiate(prefabSeleccionado, posicionAleatoria, Quaternion.identity, padreDeObjetos);

                // Verificar y ajustar el NavMeshAgent si está presente en el prefab instanciado
                NavMeshAgent agent = instancia.GetComponent<NavMeshAgent>();
                if (agent != null)
                {
                    agent.enabled = true; // Asegúrate de que el agente esté habilitado
                    if (!agent.isOnNavMesh)
                    {
                        Debug.LogWarning($"El NavMeshAgent en {instancia.name} no está en un NavMesh.");
                    }
                }
            }

            yield return new WaitForSeconds(tasaDeGeneracion);
        }
    }

    private void OnTriggerExit(Collider otro)
    {
        if (otro.CompareTag("Player"))
        {
            Debug.Log("Player ha salido del área de generación.");
            if (padreDeObjetos != null)
            {
                foreach (Transform hijo in padreDeObjetos)
                {
                    Debug.Log($"Destruyendo objeto: {hijo.name}");
                    Destroy(hijo.gameObject);
                }
            }
        }
    }

    private GameObject ObtenerPrefabAleatorio()
    {
        // Seleccionar el prefab basado en la probabilidad
        return Random.value < probabilidadDeGenerar1 ? objetoParaGenerar1 : objetoParaGenerar2;
    }

    private Vector3 ObtenerPuntoAleatorioEnNavMesh()
    {
        Vector3 puntoAleatorio;
        NavMeshHit hit;

        int maxIntentos = 10;
        for (int i = 0; i < maxIntentos; i++)
        {
            puntoAleatorio = new Vector3(
                Random.Range(areaDeGeneracion.bounds.min.x, areaDeGeneracion.bounds.max.x),
                0, // Inicialmente se coloca en y=0, luego se ajusta
                Random.Range(areaDeGeneracion.bounds.min.z, areaDeGeneracion.bounds.max.z)
            );

            if (NavMesh.SamplePosition(puntoAleatorio, out hit, 0.1f, NavMesh.AllAreas))
            {
                return hit.position; // hit.position ya incluye la altura correcta
            }
        }

        // Si no se encuentra una posición válida en los intentos, retornamos la posición central del área de generación
        Debug.LogWarning("No se pudo encontrar una posición válida en el NavMesh. Usando la posición central.");
        return areaDeGeneracion.bounds.center;
    }

    private void OnDrawGizmos()
    {
        if (areaDeGeneracion != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(areaDeGeneracion.bounds.center, areaDeGeneracion.bounds.size);
        }
    }

}
