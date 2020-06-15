using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateScript : MonoBehaviour
{
    public string sceneNameObm;

    public LayerMask layerMask;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && )
        {
            Debug.Log(sceneNameObm);
            SceneManager.LoadScene(sceneNameObm);
        }
    }
}
