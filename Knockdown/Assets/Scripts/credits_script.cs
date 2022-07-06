using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class credits_script : MonoBehaviour
{
    public GameObject Page1, Page2, Page3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScrollCredits());
    }

    IEnumerator ScrollCredits()
    {
        Page1.SetActive(true);
        yield return new WaitForSeconds(10);
        Page1.SetActive(false);
        Page2.SetActive(true);
        yield return new WaitForSeconds(10);
        Page2.SetActive(false);
        Page3.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Title Screen");
    }
}
