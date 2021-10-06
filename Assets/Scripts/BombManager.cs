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
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        StartCoroutine(CreateExplosions(Vector3.forward, 5));
        StartCoroutine(CreateExplosions(Vector3.right, 5));
        StartCoroutine(CreateExplosions(Vector3.back, 5));
        StartCoroutine(CreateExplosions(Vector3.left, 5));


        GetComponent<MeshRenderer>().enabled = false;
        exploded = true;
        // transform.Find("Collider").gameObject.SetActive(false);
        Destroy(gameObject, .3f); 

    }

    private IEnumerator CreateExplosions(Vector3 direction, int size)
    {
        for (int i = 1; i < size; i++)
        {
            RaycastHit hit;
            float thickness = 1f;
            Vector3 origin = transform.position;
            origin.y = 0.5f;
            Debug.DrawRay(transform.position + new Vector3(0, .5f, 0), direction*i, Color.red, 10);
            Instantiate(explosionPrefab, transform.position + direction * i,
               Quaternion.identity);
            if (Physics.SphereCast(origin, thickness, direction, out hit, i, levelMask, QueryTriggerInteraction.UseGlobal))
            {

                if (hit.collider)
                {
                    if (hit.collider.tag.Equals("Player"))
                    {
                        //Player.takeDamage
                    }
                    if (hit.collider.tag.Equals("Wood"))
                    {

                        Debug.Log(hit.transform.gameObject);
                        Destroy(hit.transform.gameObject);
                    }

                }

            }


            // Debug.Log(counter += 1);
            //Instantiate(explosionPrefab, transform.position, 
            // Quaternion.identity);




            else
            {
                break;
            }

            yield return new WaitForSeconds(.05f);
        }

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
