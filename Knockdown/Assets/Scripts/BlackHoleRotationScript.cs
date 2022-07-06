using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleRotationScript : MonoBehaviour
{
    private Renderer rend;
    public bool isPortalVertical;
    public bool showGfx;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Spin code
        if (!isPortalVertical)
        {
            transform.Rotate(Vector3.up, 200 * Time.deltaTime, Space.World);
        }
        //Not sure if it's true anymore
        else
        {
            transform.Rotate(Vector3.forward, 200 * Time.deltaTime, Space.World);
        }

        if (showGfx)
        {
            StartCoroutine(PortalAppears());
        }
    }

    IEnumerator PortalAppears()
    {
        //    rend.enabled = true;
        transform.GetChild(7).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        //    rend.enabled = false;
        transform.GetChild(7).gameObject.SetActive(false);
        showGfx = false;
    }
}
