using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position -= new Vector3(0.01f, 0, 0);
        if (transform.position.x < -50)
        {
            transform.position = startPos;
        }
    }
}
