﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateScript : MonoBehaviour
{
    public string sceneNameObm;
    private string sceneTargetObm;
    private bool visitSceneObm = false;
    public Animator gateAnimatorObm;
    public Animator animatorSceneObm;

    void Update()
    {
        // If player presses the 
        if (Input.GetKeyDown(KeyCode.W) && visitSceneObm)
        {
            animatorSceneObm.SetTrigger("FadeOut");
            Debug.Log(this.animatorSceneObm.GetCurrentAnimatorStateInfo(0).IsName("blackSceneFadeOut"));
        }
        if (this.animatorSceneObm.GetCurrentAnimatorStateInfo(0).IsName("blackSceneFadeOut"))
        {
            Debug.Log("Going to: " + sceneTargetObm);
            SceneManager.LoadScene(sceneTargetObm);
        }
    }

    // Selects level on collision
    void OnTriggerEnter2D(Collider2D a_collisionObm)
    {
        if (a_collisionObm.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter");
            visitSceneObm = true;
            sceneTargetObm = sceneNameObm;
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
