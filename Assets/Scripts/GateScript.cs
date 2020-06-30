using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateScript : MonoBehaviour
{
    //Variables
    public string sceneNameObm;
    private bool visitSceneObm = false;
    public Animator gateAnimatorObm;
    public Animator animatorSceneObm;
    private GameObject playerObm;

    void Start()
    {
        //puts gameobject with tag player into playerObm
        playerObm = GameObject.FindWithTag("Player");
    }

    // Selects level on collision
    void OnTriggerEnter2D(Collider2D a_collisionObm)
    {
        if (a_collisionObm.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter");
            visitSceneObm = true;
            gateAnimatorObm.SetTrigger("Enter");
        }
    }

    private void OnTriggerStay2D(Collider2D a_collisionObm)
    {
        // If player presses the W key it will load the new scene using a fadeout animation
        if (Input.GetKeyDown(KeyCode.W) && visitSceneObm)
        {
            animatorSceneObm.SetTrigger("FadeOut");
            Debug.Log(this.animatorSceneObm.GetCurrentAnimatorStateInfo(0).IsName("blackSceneFadeOut"));
        }
        if (this.animatorSceneObm.GetCurrentAnimatorStateInfo(0).IsName("blackSceneFadeOut"))
        {
            Debug.Log("Going to: " + sceneNameObm);
            SceneManager.LoadScene(sceneNameObm);
        }
        Debug.Log(sceneNameObm);
    }

    private void OnTriggerExit2D(Collider2D a_collisionObm)
    {
        if (a_collisionObm.gameObject.CompareTag("Player"))
        {
            Debug.Log("Exit");
            visitSceneObm = false;
            gateAnimatorObm.SetTrigger("Exit");
        }
    }
}
