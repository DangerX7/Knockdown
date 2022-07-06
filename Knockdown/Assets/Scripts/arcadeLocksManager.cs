using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arcadeLocksManager : MonoBehaviour
{
    private MasterScript masterScript;
    private SaveTest jsonScript;
    // Start is called before the first frame update
    void Start()
    {
        masterScript = GameObject.Find("MASTER OBJECT").GetComponent<MasterScript>();
        jsonScript = GameObject.Find("MASTER OBJECT").GetComponent<SaveTest>();

        RemoveLocks();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RemoveLocks()
    {
        if (jsonScript.so.isSkin2Available)
        {
            GameObject.Find("Lock2").SetActive(false);
        }
        if (jsonScript.so.isSkin3Available)
        {
            GameObject.Find("Lock3").SetActive(false);
        }
        if (jsonScript.so.isSkin4Available)
        {
            GameObject.Find("Lock4").SetActive(false);
        }
        if (jsonScript.so.isSkin5Available)
        {
            GameObject.Find("Lock5").SetActive(false);
        }
        if (jsonScript.so.isSkin6Available)
        {
            GameObject.Find("Lock6").SetActive(false);
        }
        if (jsonScript.so.isSkin7Available)
        {
            GameObject.Find("Lock7").SetActive(false);
        }
        if (jsonScript.so.isSkin8Available)
        {
            GameObject.Find("Lock8").SetActive(false);
        }
        if (jsonScript.so.isSkin9Available)
        {
            GameObject.Find("Lock9").SetActive(false);
        }
        if (jsonScript.so.isSkin10Available)
        {
            GameObject.Find("Lock10").SetActive(false);
        }
        if (jsonScript.so.isSkin11Available)
        {
            GameObject.Find("Lock11").SetActive(false);
        }
        if (jsonScript.so.isSkin12Available)
        {
            GameObject.Find("Lock12").SetActive(false);
        }
        if (jsonScript.so.isSkin13Available)
        {
            GameObject.Find("Lock13").SetActive(false);
        }
        if (jsonScript.so.isSkin14Available)
        {
            GameObject.Find("Lock14").SetActive(false);
        }
        if (jsonScript.so.isSkin15Available)
        {
            GameObject.Find("Lock15").SetActive(false);
        }
        if (jsonScript.so.isSkin16Available)
        {
            GameObject.Find("Lock16").SetActive(false);
        }
        if (jsonScript.so.isSkin101Available)
        {
            GameObject.Find("Lock17").SetActive(false);
        }
        if (jsonScript.so.isSkin102Available)
        {
            GameObject.Find("Lock18").SetActive(false);
        }
        if (jsonScript.so.isSkin103Available)
        {
            GameObject.Find("Lock19").SetActive(false);
        }
        if (jsonScript.so.isSkin104Available)
        {
            GameObject.Find("Lock20").SetActive(false);
        }
        if (jsonScript.so.isSkin111Available)
        {
            GameObject.Find("Lock21").SetActive(false);
        }
        if (jsonScript.so.isSkin112Available)
        {
            GameObject.Find("Lock22").SetActive(false);
        }
    }
}
