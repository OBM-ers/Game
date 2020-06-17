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

    void FixedUpdate()
    {
        //Death
        if (playerObm.position.y < -25f)
        {
            playerObjectObm.GetComponent<PlayerHudOBM>().TakeDamageOBM(20);
            //Debug.Log("Ik wil dood");
            //FindObjectOfType<PlayerHudOBM>().TakeDamageOBM(20);
            //GameObject.Find("Player").GetComponent<PlayerHudOBM>().TakeDamageOBM(20);
            //IK WIL ECHT ZELFMOORD PLEGEN VUILE DIKKE HOERENZOON GEDOE DA DI IS. FUCKING 1 FUCKING ZIN
            //HZO WERKT DIT NIET MEE. EN GEEN ENKELE VUILE HOMO OP HET INTERNET HEEFT EEN OPLOSSING. DOEN ALLEMAAL HETZELFDE
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
        }
    }
}
