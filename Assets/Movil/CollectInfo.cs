using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VrGamesDev;

public class CollectInfo : MonoBehaviour
{

    public string m_texto = "";
    void Start()
    {
        StartCoroutine(voyalserver());
    }

    // Update is called once per frame
    private IEnumerator voyalserver()
    {
        yield return VRG_Remote.IsValid();

        this.m_texto = VRG_Remote.GetString("CollectInfo.m_texto");

        yield return null;
    }
}
