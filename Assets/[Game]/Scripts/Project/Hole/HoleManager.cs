using UnityEngine;
using System.Collections.Generic;

public class HoleManager : Singleton<HoleManager>
{
    #region Public Variables
    [Header("Hole mesh")]
	public MeshFilter meshFilter;
	public MeshCollider meshCollider;

	[Header("Hole vertices radius")]
	//Hole vertices radius from the hole's center
	public float radius;
	public Transform holeCenter;
    #endregion

    #region Private Variables
    Mesh mesh;
	List<int> holeVertices;
	//hole vertices offsets from hole center
	List<Vector3> offsets;
	int holeVerticesCount;
    #endregion

    #region Private Methods
    void OnEnable()
	{
		//Initializing lists
		holeVertices = new List<int>();
		offsets = new List<Vector3>();

		//get the meshFilter's mesh
		mesh = meshFilter.mesh;

		//Find Hole vertices on the mesh
		FindHoleVertices();
	}

	void FindHoleVertices()
	{
		for (int i = 0; i < mesh.vertices.Length; i++)
		{
			//Calculate distance between holeCenter & each Vertex
			float distance = Vector3.Distance(holeCenter.position, mesh.vertices[i]);

			if (distance < radius)
			{
				//this vertex belongs to the Hole
				holeVertices.Add(i);
				//offset: how far the Vertex from the HoleCenter
				offsets.Add(mesh.vertices[i] - holeCenter.position);
			}
		}
		//save hole vertices count
		holeVerticesCount = holeVertices.Count;
	}


	//Visualize Hole vertices Radius in the Scene view
	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(holeCenter.position, radius);
	}
    #endregion

    #region Public Methods
    public void UpdateHoleVerticesPosition(Transform holeCenter)
	{
		//Move hole vertices
		Vector3[] vertices = mesh.vertices;
		for (int i = 0; i < holeVerticesCount; i++)
		{
			vertices[holeVertices[i]] = holeCenter.position + offsets[i];
		}

		//update mesh vertices
		mesh.vertices = vertices;
		//update meshFilter's mesh
		meshFilter.mesh = mesh;
		//update collider
		meshCollider.sharedMesh = mesh;
	}
    #endregion
}