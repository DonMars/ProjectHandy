using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Hielo : MonoBehaviour
{
    [SerializeField] private GameObject hieloObject;
    [SerializeField] private bool iniciarConteo;
    [SerializeField] private float cont;
    [SerializeField] private float duracionAnimacion;
    private GameObject saveGameObject;
    private float antyGravity= -20f;
    [SerializeField] private Transform PositionSpawn;
    

    public void efectoCillision(Vector3 positionContact)
    {
        Instantiate(hieloObject,positionContact,this.transform.rotation);
        //Destroy(gameObject);
    }
    private void Update()
    {
        if(iniciarConteo == true)
        {
            cont += Time.deltaTime;
        }
        if(cont >= duracionAnimacion)
        {
            saveGameObject.transform.position = PositionSpawn.position;
            saveGameObject.GetComponent<PlayerController>()/*.AnimacionAhogarTerminada*/;
            cont = 0;
            iniciarConteo= false;

            
            if (saveGameObject.GetComponent<PlayerController>() != null)
            {
                saveGameObject.GetComponent<PlayerController>().healthPoints--;
            }
            if (saveGameObject.GetComponent<PlayerController>() != null)
            {
                saveGameObject.GetComponent<PlayerController>().enabled = true;
            }
            if (saveGameObject.GetComponent<GrabMechanic>() != null)
            {
                saveGameObject.GetComponent<GrabMechanic>().enabled = true;
            }
            Vector3 customGrvity = Physics.gravity * 0;
            saveGameObject.GetComponent<Rigidbody>().AddForce(customGrvity, ForceMode.Acceleration);

        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            saveGameObject = other.gameObject;
            
            if (saveGameObject.GetComponent<PlayerController>() != null)
            {
                //saveGameObject.GetComponent<PlayerController>()/*.AnimacionAhogar*/;
            }
            if (saveGameObject.GetComponent<PlayerController>() != null)
            {
                saveGameObject.GetComponent<PlayerController>().enabled = false;
            }
            if(saveGameObject.GetComponent<GrabMechanic>() != null)
            {
                saveGameObject.GetComponent<GrabMechanic>().enabled = false;
            }
            Vector3 customGrvity = Physics.gravity * antyGravity;
            saveGameObject.GetComponent<Rigidbody>().AddForce(customGrvity, ForceMode.Acceleration);
            
            iniciarConteo = true;
        }
    }
}
