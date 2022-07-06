using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInCircle : MonoBehaviour
{
    private GameObject grandParent, parent;
    private MeshRenderer rend;
    public float RotateSpeed;
    public float Radius;

    private Rigidbody rb;
    public Vector3 startingPos;
    private Vector3 _centre;
    private float _angle;

    public bool type;

    public bool lockPos;

    public byte ballNumber;

    private void Start()
    {
        #region Find Parent To Follow
        if (ballNumber == 1)
        {
            grandParent = GameObject.Find("Player");
            parent = grandParent.transform.GetChild(0).gameObject;
            transform.parent = parent.transform;

            Debug.Log("READ1");
        }
        if (ballNumber == 2)
        {
            grandParent = GameObject.Find("Player 2");
            parent = grandParent.transform.GetChild(0).gameObject;
            transform.parent = parent.transform;

            Debug.Log("READ2");
        }
        if (ballNumber == 3)
        {
            grandParent = GameObject.Find("Player 3");
            parent = grandParent.transform.GetChild(0).gameObject;
            transform.parent = parent.transform;

            Debug.Log("READ3");
        }
        if (ballNumber == 4)
        {
            grandParent = GameObject.Find("Player 4");
            parent = grandParent.transform.GetChild(0).gameObject;
            transform.parent = parent.transform;

            Debug.Log("READ4");
        }
        transform.position = startingPos;
        if (ballNumber == 9)
        {
            parent = GameObject.Find("Dizzy Parent");
        }
        if (type)
        {
            rb = GetComponent<Rigidbody>();
            parent = transform.parent.gameObject;
        }
        rend = GetComponent<MeshRenderer>();
        if (ballNumber > 0)
        {
            StartCoroutine(Appear());
        }
        #endregion
    }

    IEnumerator Appear()
    {
        yield return new WaitForSeconds(0.1f);
        rend.enabled = true;
    }

    private void Update()
    {
        if (!lockPos)
        {
            //    _centre = parent.transform.position;
            _centre = parent.transform.position;
            _angle += RotateSpeed * Time.deltaTime;

            if (!type)
            {
                var offset = new Vector3(Mathf.Sin(_angle), 1.4f, Mathf.Cos(_angle)) * Radius;
                transform.position = _centre + offset;
            }
            else
            {
                rb.AddTorque(Vector3.up * 200 * RotateSpeed * Time.deltaTime);
                var offset = new Vector3(Mathf.Sin(_angle), 0, Mathf.Cos(_angle)) * Radius * 6;
                transform.position = _centre + offset;
            }
        }

    }

    #region Wrecking Ball Code
    private void OnCollisionEnter(Collision collision)
    {
        if (type)
        {
            if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
            {
                Rigidbody colObjRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
                if (collision.transform.gameObject.name == "Boss")
                {
                    colObjRigidbody.AddForce(awayFromPlayer * 20, ForceMode.Impulse);
                }
                else
                {
                    colObjRigidbody.AddForce(awayFromPlayer * 200, ForceMode.Impulse);
                }
            }
            else if (collision.gameObject.CompareTag("Obj"))
            {
                Rigidbody colObjRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
                colObjRigidbody.AddForce(awayFromPlayer * 50, ForceMode.Impulse);
            }
        }
    }
    #endregion

}
