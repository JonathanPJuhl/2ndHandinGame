using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    [SerializeField] private Vector3 gridSize = default;
    public void OnDrawGizmos()
    {
        SnapTo2();
    }
    private void SnapTo()
    {
        var position = new Vector3(
            Mathf.RoundToInt(this.transform.position.x),
            Mathf.RoundToInt(this.transform.position.y),
            Mathf.RoundToInt(this.transform.position.z)
            );
        this.transform.position = position;
    }
    private void SnapTo2()
    {
        var position = new Vector3(
            Mathf.RoundToInt(this.transform.position.x / this.gridSize.x) * this.gridSize.x,
            Mathf.RoundToInt(this.transform.position.y / this.gridSize.y) * this.gridSize.y,
            Mathf.RoundToInt(this.transform.position.z / this.gridSize.z) * this.gridSize.z
            );
        this.transform.position = position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
