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
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            saveGameObject = collision.gameObject;
            saveGameObject.GetComponent<PlayerController>()/*.AnimacionAhogar*/;
            saveGameObject.GetComponent<PlayerController>()/*.vida -= 1*/;
            iniciarConteo = true;
        }
    }
}
