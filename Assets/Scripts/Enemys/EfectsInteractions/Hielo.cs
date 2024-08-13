using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class Hielo : MonoBehaviour
{
    [SerializeField] private GameObject hieloObject;


    public float floatHeight = 2.0f; // Altura a la que el objeto flotará
    public float bounceDamp = 0.05f; // Amortiguación para reducir el rebote
    public float underwaterDrag = 3f; // Resistencia al movimiento cuando está bajo el agua
    public float underwaterAngularDrag = 1f; // Resistencia a la rotación cuando está bajo el agua
    public Transform respawnPoint; // Punto de respawn específico
    public float respawnTime = 5f; // Tiempo en segundos antes de respawnear
    public float alturaY = 5f; // Tiempo en segundos antes de respawnear
    public int Daño;

    private Transform player;
    public void efectoCillision(Vector3 positionContact)
    {

        Vector3 pointCollision = positionContact;

        Vector3 PositionInstance = pointCollision + new Vector3(0, alturaY, 0);

        Instantiate(hieloObject, PositionInstance, Quaternion.identity);
        //Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject.transform;
            Rigidbody rb = player.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Comienza la simulación de flotación y desactiva los scripts
                StartCoroutine(HandleObjectInWater(rb, player));
            }
        }
        else if (other.CompareTag("Enemy") && other.GetComponent<Efect>().efectoHielo != true)
        {
            Destroy(other.gameObject);
        }
    }

    IEnumerator HandleObjectInWater(Rigidbody rb, Transform playe)
    {
        float originalDrag = rb.drag;
        float originalAngularDrag = rb.angularDrag;

        // Desactivar los scripts del objeto que toca el agua
        MonoBehaviour[] scriptsToDisable = playe.GetComponents<MonoBehaviour>();
        foreach (var script in scriptsToDisable)
        {
            script.enabled = false;
        }

        // Aplicar resistencia cuando está bajo el agua
        rb.drag = underwaterDrag;
        rb.angularDrag = underwaterAngularDrag;

        // Simulación de flotación
        float waterLevel = transform.position.y;
        while (playe.transform.position.y < waterLevel)
        {
            float displacementMultiplier = Mathf.Clamp01((waterLevel - playe.transform.position.y) / floatHeight);
            Vector3 floatForce = new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f);
            rb.AddForce(floatForce, ForceMode.Acceleration);

            // Aplicar amortiguación para reducir el rebote
            Vector3 dampForce = -rb.velocity * bounceDamp;
            rb.AddForce(dampForce, ForceMode.VelocityChange);

            yield return new WaitForFixedUpdate();
        }

        
        
        // Esperar antes de respawnear
        yield return new WaitForSeconds(respawnTime);
        //playe.transform.position = respawnPoint.position;
        //playe.transform.rotation = respawnPoint.rotation;
        //respaenActivate = true;

        player.GetComponent<CapsuleCollider>().enabled = false;
        // Respawnear el objeto en el punto específico
        rb.velocity = Vector3.zero; // Detener la velocidad del objeto
        rb.angularVelocity = Vector3.zero; // Detener la rotación del objeto

        playe.GetComponent<CapsuleCollider>().enabled = true;
        // Restaurar los valores originales de drag y angularDrag
        rb.drag = originalDrag;
        rb.angularDrag = originalAngularDrag;

        // Reactivar los scripts
        foreach (var script in scriptsToDisable)
        {
            script.enabled = true;
        }

        // Verificar la posición final después del respawn
        Debug.Log("Respawned at: " + playe.transform.position);
        playe.GetComponent<PlayerController>().healthPoints-=Daño;

    }
    private bool respaenActivate;
    
    



}