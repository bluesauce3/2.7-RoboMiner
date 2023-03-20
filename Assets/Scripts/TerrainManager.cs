using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public GameObject terrainPrefab;
    public Vector3[] borderingChunkEdgeNorth;
    public Vector3[] borderingChunkEdgeSouth;
    public Vector3[] borderingChunkEdgeEast;
    public Vector3[] borderingChunkEdgeWest;
    public int renderDistance = 2;

    public GameObject[,] terrainChunks;
    public int size = 250;

    private ChunkGeneration chunkGeneration;

    void Start()
    {
        borderingChunkEdgeNorth = new Vector3[size + 1];
        borderingChunkEdgeSouth = new Vector3[size]; //+1 maybe
        borderingChunkEdgeEast = new Vector3[size];
        borderingChunkEdgeWest = new Vector3[size];
        
        int []locationA = new int[] {0, 0};
        GenerateTerrain();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateTerrain()
    {
        terrainChunks = new GameObject[renderDistance, renderDistance];
        Vector3[] vertices;
        //0,0 is self, 1,0 north, 0,1 east, -1,0 south, 0,-1 west
        terrainChunks[0, 0] = Instantiate(terrainPrefab, new Vector3(0, 0, 0), terrainPrefab.transform.rotation);
        if (terrainChunks[1, 0] is GameObject){
            /* if (terrainChunks[1, 0].CompareTag("Ground")) {
                vertices = terrainChunks[1, 0].GetComponent<ChunkGeneration>().vertices;
                for (int i = 0; i < size; i++) {
                    borderingChunkEdgeNorth[i] = vertices[size * (size + 1) + i];
                }
            } */ 
        } else {
                chunkGeneration = terrainChunks[0, 0].GetComponent<ChunkGeneration>();
                vertices = chunkGeneration.vertices;
                for (int i = 0; i < size + 1; i++) {
                Debug.Log(vertices.Length);
                Debug.Log(terrainChunks[0, 0].GetComponent<ChunkGeneration>().vertices.Length);
                Debug.Log(borderingChunkEdgeNorth.Length);
                borderingChunkEdgeNorth[i] = vertices[size * (size - 1) + i];
                }
            }
        
    }
}