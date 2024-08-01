using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Normal : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float velocidad;
    [SerializeField] private Transform position2;
    [SerializeField] private GameObject objecMove;
    public bool move;
    
    void Start()
    {
        
    }
    private void Update()
    {
        efectoCillision();
    }

    public void efectoCillision()
    {
        if(move)
        {
            float paso = velocidad * Time.deltaTime;

            objecMove.transform.position = Vector3.MoveTowards(objecMove.transform.position, position2.position, paso);
        }
        
    }
}
