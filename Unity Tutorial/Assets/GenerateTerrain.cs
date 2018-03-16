using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour {
	int heightScale = 50;
	float detailScale = 5.0f;
	int octaves = 1;
	float persistance = 1;
	float lacunarity = 1;
	// Use this for initialization
	void Start () {
		Mesh mesh = this.GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;

		float maxNoiseHeight = float.MinValue;
		float minNoiseHeight = float.MaxValue;
		for(int v = 0; v < vertices.Length; v++)
		{
			float amplitude = 1;
			float frequency = 1;
			float noiseHeight = 0;
			for (int i = 0; i < octaves; i++){
				float perlinValue = Mathf.PerlinNoise((vertices[v].x + this.transform.position.x)/detailScale * frequency,
												(vertices[v].z + this.transform.position.z)/detailScale * frequency) * heightScale;
				noiseHeight += perlinValue * amplitude;

				amplitude *= persistance;
				frequency *= lacunarity;

			}
			vertices[v].y = noiseHeight;
		}
		mesh.vertices = vertices;
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();
		this.gameObject.AddComponent<MeshCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
