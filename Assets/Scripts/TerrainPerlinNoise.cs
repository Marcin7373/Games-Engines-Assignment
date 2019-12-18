using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPerlinNoise : MonoBehaviour
{
    private Mesh meshFilter;
    private MeshCollider meshCollider;
    public float multiplier = 5f, gradient = 0.1f;
    private float perlinNoise, sineLen = 0.57f, amp = 25f, sine;

    void Awake()
    {
        meshFilter = GetComponent<MeshFilter>().mesh;
        meshCollider = GetComponent<MeshCollider>();
    }

    void Start()
    {
        Vector3[] vertices = meshFilter.vertices;
        float x = 0, z = 0, y = transform.position.y;

        for (int i = 0; i < vertices.Length; i++)
        {
            x = (transform.position.x + vertices[i].x) / gradient;
            z = (transform.position.z + vertices[i].z) / gradient;

            perlinNoise = (Mathf.PerlinNoise(x, z) - 0.5f) * multiplier;

            //flattening the bottom, 3.1 move the wave in the middle creating a valley
            if ((Mathf.Sin((i + 3.1f) * sineLen) * amp) > 9f)
            {
                sine = (Mathf.Sin((i + 3.1f) * sineLen) * amp);
            }
            else
            {
                sine = 0f;
            }
            vertices[i].y = sine + perlinNoise;
        }

        meshFilter.vertices = vertices;
        meshFilter.RecalculateBounds();
        meshFilter.RecalculateNormals();
        meshCollider.sharedMesh = meshFilter;
    }
}
