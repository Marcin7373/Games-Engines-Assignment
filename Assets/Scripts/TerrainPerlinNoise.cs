using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPerlinNoise : MonoBehaviour
{
    private Mesh meshFilter;
    private MeshCollider meshCollider;
    public float multiplier = 5f, gradient = 5f, gradSmall, multSmall, perlinNoise;

    void Awake()
    {
        meshFilter = GetComponent<MeshFilter>().mesh;
        meshCollider = GetComponent<MeshCollider>();
    }

    void Start()
    {
        Vector3[] vertices = meshFilter.vertices;
        float x = 0, z = 0;

        for (int i = 0; i < vertices.Length; i++)
        {
            x = (transform.position.x + vertices[i].x) / gradient;
            z = (transform.position.z + vertices[i].z) / gradient;

            perlinNoise = (Mathf.PerlinNoise(x, z) - 0.5f) * multiplier;
            vertices[i].y = perlinNoise;
        }

        meshFilter.vertices = vertices;
        meshFilter.RecalculateBounds();
        meshFilter.RecalculateNormals();
        meshCollider.sharedMesh = meshFilter;
    }

    void Update()
    {
        
    }
}
