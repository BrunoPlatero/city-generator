
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitySpawner : MonoBehaviour
{    
    private BuildingManager buildingManager;

    [Header("Settings")]
    public int blockWidth = 10;
    public int blockHeight = 10;
    public int blockSize = 3;

    public Material materialCube = null;
    
    public void Start()
    {
        BuildingManager[] _buildingManager = GameObject.FindObjectsOfType<BuildingManager>();
        buildingManager = _buildingManager[0];
    }

    void DeleteGrid()
    {
        GameObject[] buildings = GameObject.FindGameObjectsWithTag(buildingManager.buildingTag);
        foreach (GameObject obj in buildings)
        {
            Destroy(obj);
        }
    }

    public void GenerateCity()
    {
        DeleteGrid();
        SpawnGrid();
    }

    void SpawnGrid()
    {
        Vector3 position = new Vector3(0, 0, 0);
        for (int row = 0; row < blockWidth; row++)
        {
            for (int column = 0; column < blockHeight; column++)
            {
                SpawnBlock(position);
                position.x += blockSize + 1; 
            }
            position.z += blockSize + 1;
            position.x = 0;
        }
    }

    void SpawnBlock(Vector3 position)
    {
        for (int row = 0; row < blockSize; row++)
        {
            SpawnBuilding(position, new Vector3(1, Random.Range(buildingManager.minimumHeight, buildingManager.maximumHeight), 1));
            position.x += 1;
        }
        position.x -= 1;
        for (int column = 1; column < blockSize; column++)
        {
            position.z += 1;
            SpawnBuilding(position, new Vector3(1, Random.Range(buildingManager.minimumHeight, buildingManager.maximumHeight), 1));
        }
        for (int row = 1; row < blockSize; row++)
        {
            position.x -= 1;
            SpawnBuilding(position, new Vector3(1, Random.Range(buildingManager.minimumHeight, buildingManager.maximumHeight), 1));
        }
        for (int column = 2; column < blockSize; column++)
        {
            position.z -= 1;
            SpawnBuilding(position, new Vector3(1, Random.Range(buildingManager.minimumHeight, buildingManager.maximumHeight), 1));
        }
    }

    void SpawnBuilding(Vector3 position, Vector3 scale)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        position.y += scale.y / 2;
        cube.transform.position = position;
        cube.transform.localScale = scale;

        Renderer rend = cube.GetComponent<Renderer>();
        rend.material = materialCube;
        cube.tag = buildingManager.buildingTag;
    }
}
