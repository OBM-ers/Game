using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateScript : MonoBehaviour
{
    //public Animator transitionAnimatorObm;
    public string sceneNameObm;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Scene");
            SceneManager.LoadScene(sceneNameObm);
        }
    }
}
