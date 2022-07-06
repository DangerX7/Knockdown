using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailScript : MonoBehaviour
{
    GameObject father, player;
    // Start is called before the first frame update
    void Start()
    {
        father = transform.parent.gameObject;
        player = father.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }
}
