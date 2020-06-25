using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollisionOBM : MonoBehaviour
{
    public Text soulAmountObm;
    public Text soulsNeededTextObm;
    public Rigidbody2D playerObm;
    public GameObject playerObjectObm;
    public Transform spawnObm;
    public AudioSource collectSoundObm;
    public Animator animatorSceneObm;
    public float requiredSoulsObm;
    private bool soulCollectedObm = false;
    private int soulAmountIntegerObm = 0;
    private bool fallThroughMapObm = false;
    private int damage = 20;

    private void Awake()
    {
        soulsNeededTextObm.text = requiredSoulsObm.ToString("00");
    }

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

        //Go back to hub when found all souls
        if (requiredSoulsObm == soulAmountIntegerObm)
        {
            animatorSceneObm.SetTrigger("FadeOut");
            if (this.animatorSceneObm.GetCurrentAnimatorStateInfo(0).IsName("blackSceneFadeOut"))
            {
                SceneManager.LoadScene("HubScene");
            }
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
            collectSoundObm.Play();
        }
    }
}
