using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public GameObject terrainPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(terrainPrefab, new Vector3(0, 0, 0), terrainPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
