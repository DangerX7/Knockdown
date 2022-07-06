using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeCode : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerLimit"))
        {
            Destroy(this);
        }
    }
}
