using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceScript : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] bool orb;
    private float speed;
    private int dirrection;
    private Vector3 rotateDir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = Random.Range(2, 6);
        dirrection = Random.Range(0, 6);
        switch (dirrection)
        {
            case 0:
                rotateDir = Vector3.up;
                break;
            case 1:
                rotateDir = Vector3.down;
                break;
            case 2:
                rotateDir = Vector3.forward;
                break;
            case 3:
                rotateDir = Vector3.back;
                break;
            case 4:
                rotateDir = Vector3.left;
                break;
            case 5:
                rotateDir = Vector3.right;
                break;
            case 6:
                rotateDir = Vector3.up;
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!orb)
        {
            rb.AddTorque(Vector3.right * 4 * Time.deltaTime);
        }
        else
        {
            rb.AddTorque(rotateDir * speed * Time.deltaTime);
        }
    }
}
