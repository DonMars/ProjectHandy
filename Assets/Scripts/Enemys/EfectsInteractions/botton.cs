using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class botton : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Transform positionThisObject;
    [SerializeField] private Transform nextPositionSwitchObject;
    
    [SerializeField] private GameObject switchObject;
    public bool move;

    public Animator botonAnimator;
    

    private void Update()
    {
        efectoCollision();
    }

    public void efectoCollision()
    {
        if (move)
        {
            float paso = velocidad * Time.deltaTime;

            this.transform.position = Vector3.MoveTowards(this.transform.transform.position, positionThisObject.position, paso);
            switchObject.transform.position = Vector3.MoveTowards(switchObject.transform.transform.position, nextPositionSwitchObject.position, paso);

            botonAnimator.SetTrigger("botonPush");
        }
        
    }
}
