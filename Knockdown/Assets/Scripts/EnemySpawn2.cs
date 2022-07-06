using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn2 : MonoBehaviour
{
    public Renderer rend;
    Collider sphereCollider;
    public float xRotation;
    public float yRotation;
    public float zRotation;
    Vector3 RotationPos;
    // Start is called before the first frame update
    void Start()
    {
        rend.enabled = true;
        //    StartCoroutine(EnemySpawnDelay());
        xRotation = Random.Range(-1, 2);
        yRotation = Random.Range(-1, 2);
        zRotation = Random.Range(-1, 2);
        RotationPos = new Vector3 (xRotation, yRotation, zRotation);
        sphereCollider = GetComponent<Collider>();
    }

    IEnumerator EnemySpawnDelay()
    {
        yield return new WaitForSeconds(1);
        transform.GetChild(0).gameObject.SetActive(true);
        rend.enabled = false;
    }   

    // Update is called once per frame
    void Update()
    {
        if (rend.enabled)
        {
            transform.Rotate(RotationPos, 300 * Time.deltaTime, Space.World);
        }

    }

    public void SpawnEnemy()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        rend.enabled = false;
        transform.gameObject.tag = "Parent";
        sphereCollider.enabled = false;
    }
}
