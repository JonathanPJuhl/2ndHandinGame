using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CathrinePlayer : MonoBehaviour
{
    public GameObject bombPrefab;

    void Start()
    {

    }

    void Update()
    {

    }

    private void DropBomb()
    {
        if (bombPrefab)
        {
            Instantiate(bombPrefab, new Vector3(Mathf.RoundToInt(transform.position.x),
                bombPrefab.transform.position.y, Mathf.RoundToInt(transform.position.z)),
                bombPrefab.transform.rotation);

        }
    }
}
