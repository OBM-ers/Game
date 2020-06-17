using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class FollowMouseOBM : MonoBehaviour
{
    private bool facingrightObm = true;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(
        mousePosition.x - transform.position.x,
        mousePosition.y - transform.position.y
        );

        transform.right = direction;

        //transform.right = direction;
        /*if (mousePosition.x > transform.position.x && facingrightObm == true)
        {
            Vector2 localScale = gameObject.transform.localScale;
            localScale.x = 1;
            transform.localScale = localScale;
            facingrightObm = true;
        }
        else
        {
            facingrightObm = !facingrightObm;
            Vector2 localScale = gameObject.transform.localScale;
            localScale.x = -1;
            transform.localScale = localScale;
            facingrightObm = false;
        }*/
    }
}
