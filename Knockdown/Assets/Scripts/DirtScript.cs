using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtScript : MonoBehaviour
{
    public GameObject parent;
    private PlayerScript playerScript;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = parent.GetComponent<PlayerScript>();
        playerController = parent.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.dead || playerController.dashState != 2)
        {
            transform.gameObject.SetActive(false);
        }
    }
}
