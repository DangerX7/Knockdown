using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastSphereCol : MonoBehaviour
{
    private GameObject Player;
    private bool didSound;
    private int growthLimit; // 2 for players, 4 for boss
    private int pushForce;
    private Rigidbody enemyRB;
    private SpawnManagerScript spawnManagerScript;
    public bool isUsedByPlayer;
    private void Start()
    {
        if (isUsedByPlayer)
        {
            GameObject Father = transform.parent.gameObject;
            Player = Father.transform.GetChild(0).gameObject;
        }
        enemyRB = GetComponent<Rigidbody>();
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
        if (spawnManagerScript.gameMode == 0)
        {
            growthLimit = 4;
            pushForce = 120;
        }
        else if (spawnManagerScript.gameMode == 7)
        {
            growthLimit = 3;
            pushForce = 100;
        }
    }
    private void Update()
    {
        if (isUsedByPlayer)
        {
            transform.position = Player.transform.position;
        }
        if (!didSound)
        {
            SoundsScript soundScript = GameObject.Find("Sound").GetComponent<SoundsScript>();
            soundScript.PlaySound("ShockWave");
            didSound = true;
        }
        if (transform.localScale.x < growthLimit && transform.localScale.y < growthLimit && transform.localScale.z < growthLimit)
        {
            transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
        }
        if (transform.localScale.x >= growthLimit && transform.localScale.y >= growthLimit && transform.localScale.z >= growthLimit)
        {
            transform.localScale = new Vector3(1, 1, 1);
            didSound = false;
            transform.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && other.gameObject!= Player)
        {
            //Create Script Reference For Collided Object
         //   PlayerScript playerScript = other.gameObject.GetComponent<PlayerScript>();
          //  enemyRB.velocity = new Vector3(0, 0, 0);
            Rigidbody playerRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromEnemy = other.gameObject.transform.position - transform.position;
            playerRigidbody.AddForce(awayFromEnemy * pushForce, ForceMode.Impulse);
        }
    }
}
