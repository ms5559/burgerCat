using UnityEngine;
using System.Collections;

/*
 * for demo purposes only - you don't need this in your project
 * a simple rotator script to enhance the look and feel of the demo scene
 */
public class Rotater : MonoBehaviour {
	public float RotX, RotY, RotZ;
	public bool active = true;
	
	void FixedUpdate(){
		if (!active)
			return;

		Vector3 rotation = new Vector3(RotX, RotY, RotZ);
		transform.Rotate (rotation);
	}
}
