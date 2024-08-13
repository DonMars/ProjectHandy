using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Material materialCube;

    private void Awake()
    {
        // Obtener el material del objeto
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = new Material(renderer.material); // Crear una instancia del material para evitar modificar otros objetos
        materialCube = renderer.material;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que colisiona tiene la tag "Player"
        if (other.CompareTag("Player"))
        {
            // Cambiar el color de emisión a verde
            materialCube.SetColor("_EmissionColor", Color.green * 4);
            Debug.Log("Player has entered the trigger, color changed!");
        }
    }
}
