using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public int renderDistance;
    public GameObject terrainPrefab;
    private ChunkGeneration chunkGeneration;
    private int size;
    // Start is called before the first frame update
    void Start()
    {
        GenerateTerrain();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateTerrain()
    {
        chunkGeneration = terrainPrefab.GetComponent<ChunkGeneration>();
        size = chunkGeneration.size;
        for (int x = 0; x < renderDistance; x++) {
            for (int z = 0; z < renderDistance; z++) {
                Instantiate(terrainPrefab, new Vector3(x*size, 0, z*size), terrainPrefab.transform.rotation);
            }
        }
    }
}
