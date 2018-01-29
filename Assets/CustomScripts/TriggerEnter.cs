using UnityEngine;
using System.Collections;

public class TriggerEnter : MonoBehaviour {

	public AudioClip meow;
	public AudioClip pointExplosion;
    AudioSource audio;
    public GameObject explosionPrefab;

    void Start() {
    	audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);

        audio.PlayOneShot(meow, 0.5F);
        audio.PlayOneShot(pointExplosion, 1.0F);

        var newExplode    = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }

}
