using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCollision : MonoBehaviour
{
    public bool lavaException;
    private void OnCollisionEnter(Collision collision)
    {
        if (!lavaException)
        {
            if (collision.transform.gameObject.tag != "Ground" && collision.gameObject.tag != ("Player"))
            {
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.tag.Equals("Player"))
            {
                PlayerScript playerScript = collision.gameObject.GetComponent<PlayerScript>();
                playerScript.Death();
            }
        }
        else
        {
            if ((collision.transform.gameObject.tag != "Ground") && (collision.transform.gameObject.tag != "Player"))
            {
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.tag.Equals("Player"))
            {
                StartCoroutine(BurnCoroutine());
            }
        }
    }

    IEnumerator BurnCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        SpawnManagerScript spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
        spawnManager.GameOver();
        GameObject.Find("Player").SetActive(false);
        LavaScript lavaScript = GetComponent<LavaScript>();
        lavaScript.stop = true;
    }
}
