using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    public bool stop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            transform.position += Vector3.up * Time.deltaTime / 4;
        }
    }
}
