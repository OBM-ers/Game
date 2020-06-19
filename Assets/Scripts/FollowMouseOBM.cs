using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class FollowMouseOBM : MonoBehaviour
{
    private bool facingrightObm = true;

    public void OnMouseOverExitObm()
    {
        if(facingrightObm == false)
        {
            //facingrightObm = !facingrightObm;
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
            //facingrightObm = !facingrightObm;
            Vector2 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
            facingrightObm = false;
        }
    }
}
