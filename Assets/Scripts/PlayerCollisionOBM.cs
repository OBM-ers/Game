using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisionOBM : MonoBehaviour
{
    public Text soulAmountObm;

    public Rigidbody2D playerObm;
    public Transform spawnObm;
    public AudioSource collectSoundObm;
    private bool soulCollectedObm = false;
    private int soulAmountIntegerObm = 0;

    void FixedUpdate()
    {
        //Death
        if (playerObm.position.y < -25f)
        {
            playerObm.position = spawnObm.position;
        }

        //Add soul amount
        if (soulCollectedObm == true)
        {
            soulAmountIntegerObm++;
            soulAmountObm.text = soulAmountIntegerObm.ToString("00");
            soulCollectedObm = false;
        }
    }

    //OnTriggerEnter is a static function made by unity so no Creator Identifier possible
    public void OnTriggerEnter2D(Collider2D collectibleObm)
    {
        //collectibles
        if (collectibleObm.gameObject.CompareTag("Collectible"))
        {
            Destroy(collectibleObm.gameObject);
            soulCollectedObm = true;
            collectSoundObm.Play();
        }
    }
}
