using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VFolders.Libs;

public class GoldenPoopCollectable : MonoBehaviour
{
    public Collider collectableCollider;
    public MeshRenderer collectableMeshRenderer;

    private void OnTriggerEnter(Collider other)
    {
        //int chance = Random.Range(1, 5);

        //if (chance == 1)
        //{
        //    //AudioManager.Instance.goldenPoopColl1.pitch = Random.Range(0.85f, 1.15f);
        //    AudioManager.Instance.goldenPoopColl1.Play();
        //}
        //else if (chance == 2)
        //{
        //    //AudioManager.Instance.goldenPoopColl2.pitch = Random.Range(0.85f, 1.15f);
        //    AudioManager.Instance.goldenPoopColl2.Play();
        //}
        //else if (chance == 3)
        //{
        //    //AudioManager.Instance.goldenPoopColl3.pitch = Random.Range(0.85f, 1.15f);
        //    AudioManager.Instance.goldenPoopColl3.Play();
        //}
        //else if (chance == 4)
        //{
        //    //AudioManager.Instance.goldenPoopColl4.pitch = Random.Range(0.85f, 1.15f);
        //    AudioManager.Instance.goldenPoopColl4.Play();
        //}
        
        GameManager.Instance.goldenPoop++;
        collectableCollider.enabled = false;
        collectableMeshRenderer.enabled = false;

        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.4f);
        this.gameObject.Destroy();
    }
}
