using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisionOBM : MonoBehaviour
{
    public Text soulAmountObm;

    public Rigidbody2D playerObm;
    public GameObject playerObjectObm;
    public Transform spawnObm;
    private bool soulCollectedObm = false;
    private int soulAmountIntegerObm = 0;
    private bool fallThroughMapObm = false;
    private int damage = 20;

    void FixedUpdate()
    {
        //Death
        if (playerObm.position.y <= -25)
        {
            playerObm.position = spawnObm.position;
            fallThroughMapObm = true;
        }

        //Add soul amount
        if (soulCollectedObm == true)
        {
            soulAmountIntegerObm++;
            soulAmountObm.text = soulAmountIntegerObm.ToString("00");
            soulCollectedObm = false;
        }
    }

    void Update()
    {
        if (fallThroughMapObm == true)
        {
            playerObjectObm.GetComponent<PlayerHudOBM>().TakeDamageOBM(damage);
            fallThroughMapObm = false;
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
        }
    }
}
