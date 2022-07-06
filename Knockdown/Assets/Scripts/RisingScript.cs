using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingScript : MonoBehaviour
{
    Vector3 startPos;
    public int movementStatus;
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        startPos = transform.position;
        StartCoroutine(RiseUpCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 5 * movementStatus * Time.deltaTime, transform.position.z);
        transform.localScale += new Vector3(0, 10 * movementStatus * Time.deltaTime, 0);

        if (movementStatus == 0)
        {
            rend.enabled = false;
        }
        else
        {
            rend.enabled = true;
        }
    }

    IEnumerator RiseUpCountdown()
    {
        yield return new WaitForSeconds(2);
        movementStatus = 1;
        yield return new WaitForSeconds(0.3f);
        movementStatus = -1;
        yield return new WaitForSeconds(0.3f);
        movementStatus = 0;
        transform.localScale = new Vector3(1.33f, 0.0004f, 1.33f);
        transform.position = startPos;
        StartCoroutine(RiseUpCountdown());
    }
}
