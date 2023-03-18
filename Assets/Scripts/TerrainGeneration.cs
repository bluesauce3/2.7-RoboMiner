using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class TerrainGeneration : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    public int xSize = 100;
    public int zSize = 100;
    // Start is called before the first frame update
    void Start()
    {
        //Create a new mesh 
        mesh = new Mesh();
        CreateShape();
        UpdateMesh();
        
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateShape() {
        //Create vertices for mesh
        vertices = new Vector3[(xSize + 1 ) * (zSize + 1)];

        for (int i = 0, z = 0; z < zSize + 1; z++) {
            for (int x = 0; x < xSize + 1; x++) {

                float y = Mathf.PerlinNoise(x * .3f, z * .3f);
                vertices[i] = new Vector3(x, y, z); //WHY WHEN Z IN Y_VALUE IT WORK???
                i++;
            }
        }

        //Create triangles for mesh
        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++) {
            for (int x = 0; x < xSize; x++) 
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }

    }

    void UpdateMesh() {
        //Reset and update mesh
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}
