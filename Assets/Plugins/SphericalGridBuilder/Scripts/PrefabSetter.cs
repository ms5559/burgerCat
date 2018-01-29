using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 * for demo purposes only - you don't need this in your project
 * but may show you an quick and dirty way of using gridbuiler methods
 */
public class PrefabSetter : MonoBehaviour {
	// known prefabs to use for gridbuilder
	public GameObject prefabGrid;
	public GameObject prefabCube;
	public GameObject prefabPlane;

	// the reference sphere that has the gridbuilder script attached
	public GameObject refSphere;
	public Slider amountSlider;
	public Slider offsetSlider;

	// local gridbuilder reference
	private SphereGridBuilder myGridBuilder;
	private Rotater mySphereRotater;

	// Use this for initialization
	void Start () {
		myGridBuilder = refSphere.GetComponent<SphereGridBuilder> ();
		mySphereRotater = refSphere.GetComponent<Rotater> ();
	}

	public void change2Prefab(int prefabNr){
		switch (prefabNr) {
		case 0:		// set the custom shape
			myGridBuilder.rotateX = 0;
			myGridBuilder.objPrefab = prefabGrid;
			break;
		case 1: 	// set the cube
			myGridBuilder.rotateX = 0;
			myGridBuilder.objPrefab = prefabCube;
			break;
		case 2:		// set the plane
			myGridBuilder.rotateX = 90;
			myGridBuilder.objPrefab = prefabPlane;
			break;
		}
		rebuildGrid ();
	}

	public void updateGridCount(){
		myGridBuilder.points = amountSlider.value;
		rebuildGrid ();
	}

	public void updateGridOffset(){
		myGridBuilder.size = offsetSlider.value;
		rebuildGrid ();
	}

	void rebuildGrid(){
		// stop sphere rotation
		mySphereRotater.active = false;

		// rebuild grid
		myGridBuilder.rebuildGrid ();

		// restart rotation
		mySphereRotater.active = true;
	}
}