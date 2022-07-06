using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrandFather : MonoBehaviour
{
    private MasterScript masterScript;
    // Start is called before the first frame update
    void Start()
    {
        masterScript = GameObject.Find("MASTER OBJECT").GetComponent<MasterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
