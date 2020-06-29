using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private bool facingrightObm = true;

    //the grandpa flips depending on which button is hovered over
    public void OnMouseOverExitObm()
    {
        if(facingrightObm == false)
        {
            Vector2 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
            facingrightObm = true;
        }
    }

    public void OnMouseOverContinueObm()
    {
        if (facingrightObm == true)
        {
            Vector2 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
            facingrightObm = false;
        }
    }
}
