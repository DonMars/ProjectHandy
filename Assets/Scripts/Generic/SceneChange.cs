using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string sceneName;
    public int timeToChange;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Change());
    }

    private IEnumerator Change()
    {
        yield return new WaitForSeconds(timeToChange);
    }
}
