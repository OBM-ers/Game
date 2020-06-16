using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateScript : MonoBehaviour
{
    public string sceneNameObm;
    private bool visitSceneObm = false;

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
        }
    }

    private void OnTriggerExit2D(Collider2D a_collisionObm)
    {
        if (a_collisionObm.gameObject.CompareTag("Player"))
        {
            Debug.Log("Exit");
            visitSceneObm = false;
        }
    }
}
