using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private PlayerScript playerScript;
    public float power;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GetComponent<PlayerScript>();
        power = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.localScale += new Vector3(0.001f * power, 0.001f * power, 0.001f * power);
    }
}
