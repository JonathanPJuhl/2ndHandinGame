using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTileSystem;
    public GameObject edge;
    public GameObject metalBox;
    public GameObject woodenBox;
    public int mapSize;
    public int boxFrequency;
    public Canvas canvas;
    Vector3 SpawnPoint;

    public void SpawnMap(string mapSize, string amountOfBoxes)
    {
        int mapSizeInt = 0;
        int boxLow = 0;
        int boxHigh = 0;
        if (mapSize == "Small")
        {
            mapSizeInt = 3;
        }else if (mapSize == "Medium")
        {
            mapSizeInt = 4;
        }else if (mapSize == "Large")
        {
            mapSizeInt = 5;
        }
        if(amountOfBoxes == "Few")
        {
            boxLow = 1;
            boxHigh = 8;
        }else if(amountOfBoxes == "Medium")
        {
            boxLow = 3;
            boxHigh = 6;
        }else if(amountOfBoxes == "Many")
        {
            boxLow = 2;
            boxHigh = 4;
        }

        canvas.enabled = false;
        SpawnPlane(mapSizeInt, boxLow, boxHigh);

    }

    public void SpawnPlane(float mapSize, int boxFrequencyLow, int boxFrequencyHigh)
    {
        SpawnPoint.x = (mapSize * 5);
        SpawnPoint.y = 0;
        SpawnPoint.z = (-mapSize * 5);
        
        groundTileSystem.transform.localScale = new Vector3(mapSize, 1f, mapSize);
        GameObject temp = Instantiate(groundTileSystem, SpawnPoint, Quaternion.identity);

        SpawnEdges(new Vector3(1,2, mapSize * 5 * 2), new Vector3(-0.5f, 0.5f, -mapSize * 5));
        SpawnEdges(new Vector3(mapSize * 5 * 2, 2, 1), new Vector3(mapSize * 5, 0.5f, -mapSize * 5 *2 + 0.5f));
        SpawnEdges(new Vector3(mapSize * 5 * 2, 2 , 1), new Vector3(mapSize * 5, 0.5f, 0.5f));
        SpawnEdges(new Vector3(1, 2 , 5 * mapSize * 2), new Vector3(mapSize * 5 * 2 -0.5f, 0.5f, -mapSize * 5));
        SpawnHardBoxes(mapSize, boxFrequencyLow, boxFrequencyHigh);
        SpawnWoodenBoxes(mapSize, boxFrequencyLow, boxFrequencyHigh);
    }

    public void SpawnEdges(Vector3 scale, Vector3 position)
    {
        GameObject obstacleToSpawn = edge;
        
        GameObject temp = Instantiate(obstacleToSpawn, transform);
        temp.transform.localScale = scale;
        temp.transform.position = position;
    }
    public void SpawnHardBoxes(float mapSize, int low, int high)
    {
        GameObject obstacleToSpawn = metalBox;

        int toughness;
       
        for (float z = -1.5f; z >= -mapSize * 5 * 2; z += -toughness)
        {  
             toughness = Random.Range(low, high);
          
            for (float x = 1.5f; x <= mapSize * 5 * 2; x += toughness)
            {
                toughness = Random.Range(low, high);

                Vector3 position;
                position.x = x;
                position.z = z;
                position.y = 0.5f;

                GameObject temp = Instantiate(obstacleToSpawn, transform);
                temp.transform.position = position;
            }
        }
    }

    public void SpawnWoodenBoxes(float mapSize, int low, int high)
    {
        GameObject obstacleToSpawn = woodenBox;
        int toughness;

        for (float z = -2.5f; z > -mapSize * 5 * 2; z -= toughness)
        {
            toughness = Random.Range(low, high);

            for (float x = 2.5f; x < mapSize * 5 * 2; x += toughness)
            {
                toughness = Random.Range(low, high);
                Vector3 position;
                position.x = x;
                position.z = z;
                position.y = 0.5f;

                GameObject temp = Instantiate(obstacleToSpawn, transform);

                temp.transform.position = position;
            }
        }

    }
}
