using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleIconRemove : MonoBehaviour
{
    public int iconNumber;
    private MasterScript masterScript;
    private SaveTest jsonScript;
    // Start is called before the first frame update
    void Start()
    {
        masterScript = GameObject.Find("MASTER OBJECT").GetComponent<MasterScript>();
        jsonScript = GameObject.Find("MASTER OBJECT").GetComponent<SaveTest>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (iconNumber)
        {
            case 1:
                //Always active
                break;
            case 2:
                if (jsonScript.so.textureResolution < 2)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    gameObject.SetActive(true);
                }
                break;
            case 3:
                if (jsonScript.so.textureResolution < 3)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    gameObject.SetActive(true);
                }
                break;
            case 4:
                if (jsonScript.so.textureResolution < 4)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    gameObject.SetActive(true);
                }
                break;
            case 5:
                if (jsonScript.so.textureResolution < 5)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    gameObject.SetActive(true);
                }
                break;
            case 6:
                if (jsonScript.so.textureResolution < 6)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    gameObject.SetActive(true);
                }
                break;
            case 7:
                if (jsonScript.so.textureResolution < 7)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    gameObject.SetActive(true);
                }
                break;
        }
    }
}
