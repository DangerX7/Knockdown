using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    [SerializeField] float speed;
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
