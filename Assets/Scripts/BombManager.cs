using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    public GameObject explosionPrefab;
    public LayerMask levelMask;
    private bool exploded = false;
    int counter = 0;

    void Start()
    {
        Invoke("Explode", 3f);

    }

    void Update()
    {

    }
    void Explode()
    {
        // Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        StartCoroutine(CreateExplosions(Vector3.forward, 5));
        StartCoroutine(CreateExplosions(Vector3.right, 5));
        StartCoroutine(CreateExplosions(Vector3.back, 5));
        StartCoroutine(CreateExplosions(Vector3.left, 5));


        GetComponent<MeshRenderer>().enabled = false;
        exploded = true;
        // transform.Find("Collider").gameObject.SetActive(false);
         

    }

    private IEnumerator CreateExplosions(Vector3 direction, int size)
    {
        Destroy(gameObject);
        for(int i = 1; i <= size; i++)
        {
            Instantiate(explosionPrefab, transform.position + direction * i, Quaternion.identity);
            Collider[] hitColliders = Physics.OverlapSphere(transform.position + direction + new Vector3(0, .5f, 0), 0.5f);

            foreach (var hitCollider in hitColliders)
            {
                Debug.Log(hitCollider);
                if(hitCollider.name.Equals("MetalBox(Clone)"))
                {
                    hitColliders = null;
                } 
                if (hitCollider.name.Equals("Wooden(Clone)") && counter == 0)
                {
                    Debug.Log("DESTROYED");
                    Destroy(hitCollider.gameObject);
                }

            }
            counter = 0;

        }
       
            yield return new WaitForSeconds(.05f);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (!exploded && other.CompareTag("Explosion"))
        {  
            CancelInvoke("Explode"); 
            Explode(); 
        }

    }


}
