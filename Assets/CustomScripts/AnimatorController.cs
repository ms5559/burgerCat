using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace VRStandardAssets.Utils
{
public class AnimatorController : MonoBehaviour {
    
    Animator animator;
    public AudioClip meow;
    public GameObject tutorialObject;
    AudioSource audio;
    public bool grow = false;
    public GameObject theCameraObject;
    
    // Use this for initialization
    void Start () {

        animator = GetComponent<Animator>();

        StartCoroutine("MyEvent");

        audio = GetComponent<AudioSource>();

    }
    
    // Update is called once per frame
    void Update () {


        if(Input.GetKeyDown("k")){
        	 animator.SetBool("becomeIdle", true);
        }

        if (grow){
        Vector3 scale = new Vector3(1.1f,1.0f,1.1f);
        transform.localScale = Vector3.Lerp (transform.localScale, scale, Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("Enemy"))
        {
            animator.SetTrigger("Die");
        }
    }

    private IEnumerator MyEvent(){

    while(true)
    {
        yield return new WaitForSeconds(12.5f); // wait half a second
        animator.SetBool("becomeIdle", true);

        yield return new WaitForSeconds(4.0f); // wait half a second
        tutorialObject.SetActive(true);

        yield return new WaitForSeconds(6.0f); // wait half a second
        animator.SetBool("becomePlayful", true);
        tutorialObject.SetActive(false);

        yield return new WaitForSeconds(8.0f); // wait half a second
        animator.SetBool("becomeStare", true);

        yield return new WaitForSeconds(17.0f);
        //audio.PlayOneShot(meow, 0.7F);
        grow = true;
        animator.SetBool("becomeIdle2", true);
        
        theCameraObject.GetComponent<VRCameraFade>().FadeOut(4.0F, true);



        yield return new WaitForSeconds(7.0f); // wait half a second
        Application.LoadLevel("BurgerCat_v1");
    }
}
}

}
