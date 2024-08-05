using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenPoopCollectable : MonoBehaviour
{
    public Collider collectableCollider;
    public MeshRenderer collectableMeshRenderer;
    public AudioSource goldenPoopColl1;
    public AudioSource goldenPoopColl2;
    public AudioSource goldenPoopColl3;
    public AudioSource goldenPoopColl4;
    public ParticleSystem goldenPoopParticles1;
    public ParticleSystem goldenPoopParticles2;
    HUDManager hudManager;

    private void Awake()
    {
        hudManager = FindObjectOfType<HUDManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int chance = Random.Range(1, 5);

            if (chance == 1)
            {
                goldenPoopColl1.pitch = Random.Range(0.85f, 1.15f);
                goldenPoopColl1.Play();
            }
            else if (chance == 2)
            {
                goldenPoopColl2.pitch = Random.Range(0.85f, 1.15f);
                goldenPoopColl2.Play();
            }
            else if (chance == 3)
            {
                goldenPoopColl3.pitch = Random.Range(0.85f, 1.15f);
                goldenPoopColl3.Play();
            }
            else if (chance == 4)
            {
                goldenPoopColl4.pitch = Random.Range(0.85f, 1.15f);
                goldenPoopColl4.Play();
            }

            GameManager.Instance.goldenPoop++;
        
            collectableCollider.enabled = false;
            collectableMeshRenderer.enabled = false;

            goldenPoopParticles1.Play();
            goldenPoopParticles2.Play();

            hudManager.TreasureCollect();

            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
