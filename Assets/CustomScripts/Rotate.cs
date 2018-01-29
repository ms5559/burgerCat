using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float rotation = rotationSpeed * Time.deltaTime;

		transform.Rotate(rotation, 0, 0, Space.World);
		
	}
}
