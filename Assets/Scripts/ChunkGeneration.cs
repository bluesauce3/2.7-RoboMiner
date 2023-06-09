﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
public class ChunkGeneration : MonoBehaviour
{
    public GameObject TerrainManager;
    private TerrainManager TerrainManagerCs;
    private Vector3[] borderingChunkEdgeNorth;
    private Vector3[] borderingChunkEdgeSouth;
    private Vector3[] borderingChunkEdgeEast;
    private Vector3[] borderingChunkEdgeWest; 

    Mesh mesh;
    public Vector3[] vertices;
    int[] triangles;

    private int size;
    // Start is called before the first frame update
    void Start()
    {
        TerrainManager = GameObject.Find("TerrainManager");
        TerrainManagerCs = TerrainManager.GetComponent<TerrainManager>();
        size = TerrainManagerCs.size;
        //Create a new mesh 
        mesh = new Mesh();
        CreateShape();
        UpdateMesh();
        
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;

        

    }

    // Update is called once per frame
    void Update()
    {}

    void CreateShape() {
        //Create vertices for mesh
        vertices = new Vector3[(size + 1 ) * (size + 1)];

        for (int i = 0, z = 0; z < size + 1; z++) {
            for (int x = 0; x < size + 1; x++) {

                //Add variation with Perlin Noise and Random
                float y = Mathf.PerlinNoise(x * 0.05f, z * 0.05f) * 3f;
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }
        //Create triangles for mesh
        triangles = new int[size * size * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < size; z++) {
            for (int x = 0; x < size; x++) {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + size + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + size + 1;
                triangles[tris + 5] = vert + size + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }
    }

    void UpdateMesh() {
        Vector3[] borderingChunkEdgeNorth = TerrainManagerCs.borderingChunkEdgeNorth;
        Vector3[] borderingChunkEdgeSouth = TerrainManagerCs.borderingChunkEdgeSouth;
        Vector3[] borderingChunkEdgeEast = TerrainManagerCs.borderingChunkEdgeEast;
        Vector3[] borderingChunkEdgeWest = TerrainManagerCs.borderingChunkEdgeWest;
        //Reset and update mesh
        mesh.Clear();
        for (int i = 0; i < size; i++) {
            vertices[size * (size + 1) + i] = borderingChunkEdgeNorth[i];
        }
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }
}
