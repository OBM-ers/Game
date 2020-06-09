using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisionOBM : MonoBehaviour
{
    public Rigidbody2D playerObm;
    public Transform spawnObm;

    void FixedUpdate()
    {
        //Death
        if (playerObm.position.y < -25f)
        {
            playerObm.position = spawnObm.position;
        }
    }
}
