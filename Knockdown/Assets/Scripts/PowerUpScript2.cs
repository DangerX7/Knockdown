using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript2 : MonoBehaviour
{
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rb.AddTorque(Vector3.up * 100 * Time.deltaTime);
        SpawnManagerScript spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
        if ((transform.position.y < -2 && spawnManagerScript.gameMode != 2) || (transform.position.y < -5 && spawnManagerScript.gameMode == 2))
        {
            transform.position = new Vector3(Random.Range(-2.5f, 2.5f), 0.66f, Random.Range(-2.5f, 2.5f));
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Obj"))
        {
        //    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.1f);
        }
    }
}
