using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * How-To:
 * > Attach this script to a gameobject you want to build a spherical grid around
 * > Build a prefab of a single gridobject and refer it to "objPrefab", make sure the prefab has the desired scale
 * > play with the public variables of this script to find the desired amount, position and facing
 */
public class SphereGridBuilder : MonoBehaviour {
	// this prefab will be placed at each point around the sphere
	public GameObject objPrefab;			
	
	// parameters for grid size and amount of point
	public float points = 500;
	public float size = 5.0f;

	// instantiated objects are child of THIS gameobject?
	public bool sphereAsParent = true;		

	// grid objects rotation settings (placed objects face what way?)
	public float rotateX = 0.0f;
	public float rotateY = 180.0f;
	public float rotateZ = 0.0f;
	
	// keep track of each instantiated object by Index
	public List<GameObject> gridObjects = new List<GameObject>();

	// initialization
	void Start(){
		rebuildGrid ();
	}

	// destroy and build
	public void rebuildGrid(){
		destroyGrid ();
		buildGrid ();
	}

	// calculates the point around the sphere and instantiates the prefab at each point
	public void buildGrid(){
		for(int i = 0; i < points; i++) {
			// calculate coordinates around a sphere
			float y = i * 2 / points - 1 + (1 / points);
			float r = Mathf.Sqrt(1 - y * y);
			float phi = i * Mathf.PI * (3 - Mathf.Sqrt(5));
			float x = Mathf.Cos(phi) * r;
			float z = Mathf.Sin(phi) * r;
			
			// scale them out by 'size'
			x = x * size;
			y = y * size;
			z = z * size;
			Vector3 position = new Vector3(x, y, z);
			
			// place object
			GameObject clone = Instantiate(objPrefab,position, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)) as GameObject;
			clone.name = i.ToString();
			gridObjects.Add(clone);

			if(sphereAsParent == true)
				clone.transform.SetParent(gameObject.transform);

			// TODO tell the 'clone' what ListIndex it has received (using var int 'i' from for loop)
			
			// look away from origin-point by looking at it and invert it
			clone.transform.LookAt(transform.position);
			clone.transform.Rotate(new Vector3(rotateX, rotateY, rotateZ));
		}
	}

	// destroy the entire grid
	public void destroyGrid(){
		foreach (GameObject gridObject in gridObjects) {
			Destroy(gridObject);
		}
		gridObjects.Clear ();
	}

	// unregister and destroy a specific object by Index
	public void destroyGridObject(int ListIndex){
		// destroy the actual gameobject first
		Destroy (gridObjects[ListIndex]);

		// now remove it from gridList
		gridObjects.RemoveAt (ListIndex);
	}
}