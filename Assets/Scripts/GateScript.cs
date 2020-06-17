using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateScript : MonoBehaviour
{
    public string sceneNameObm;
    private bool visitSceneObm = false;
    public Animator gateAnimatorObm;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && visitSceneObm)
        {
            SceneManager.LoadScene(sceneNameObm);
        }
    }

    void OnTriggerEnter2D(Collider2D a_collisionObm)
    {
        if (a_collisionObm.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter");
            visitSceneObm = true;
            gateAnimatorObm.SetTrigger("Enter");
        }
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
