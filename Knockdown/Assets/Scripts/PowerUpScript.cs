using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    TutorialScript tutorialScript = GameObject.Find("SpawnManager").GetComponent<TutorialScript>();
        if (!tutorialScript.tutorialLevel)
        {
            transform.parent = GameObject.Find("ItemsParent").transform;
            gameObject.SetActive(false);
        }
    }
}
