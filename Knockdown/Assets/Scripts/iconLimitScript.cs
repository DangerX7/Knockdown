using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iconLimitScript : MonoBehaviour
{
    public bool rotation;
    public bool control;
    public bool lockTeleport;
    private float startY;
    public bool yDir;
    private void Start()
    {
        startY = transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        if (rotation)
        {
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * 60f);
        }
        if (rotation)
        {

            if (!yDir)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.005f, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.005f, transform.position.z);
            }
            if (transform.position.y > startY + 1.25f)
            {
                yDir = true;
            }
            if (transform.position.y < startY - 1.25f)
            {
                yDir = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Selector"))
        {
            rotation = true; 
        }
        if (!lockTeleport)
        {
            if (control)
            {
                if (other.gameObject.tag.Equals("limitLeft"))
                {
                    transform.position = new Vector3(transform.position.x + 149.68f, transform.position.y, transform.position.z);
                    StartCoroutine(PauseTeleport());
                }
                if (other.gameObject.tag.Equals("limitRight"))
                {
                    transform.position = new Vector3(transform.position.x - 149.68f, transform.position.y, transform.position.z);
                    StartCoroutine(PauseTeleport());
                }
                if (other.gameObject.tag.Equals("LimitLeftX"))
                {
                    transform.position = new Vector3(transform.position.x + 1560.965f, transform.position.y, transform.position.z);
                    StartCoroutine(PauseTeleport());
                }
                if (other.gameObject.tag.Equals("LimitRightX"))
                {
                    transform.position = new Vector3(transform.position.x - 1560.965f, transform.position.y, transform.position.z);
                    StartCoroutine(PauseTeleport());
                }
            }
            else
            {
                if (other.gameObject.tag.Equals("LimitLeftX"))
                {
                    transform.position = new Vector3(transform.position.x + 1560.965f, transform.position.y, transform.position.z);
                    StartCoroutine(PauseTeleport());
                }
                if (other.gameObject.tag.Equals("LimitRightX"))
                {
                    transform.position = new Vector3(transform.position.x - 1560.965f, transform.position.y, transform.position.z);
                    StartCoroutine(PauseTeleport());
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Selector"))
        {
            rotation = false;
            transform.position = new Vector3(transform.position.x, startY, transform.position.z);
        }
    }

    IEnumerator PauseTeleport()
    {
        lockTeleport = true;
        yield return new WaitForSeconds(0.1f);
        lockTeleport = false;
    }
}
