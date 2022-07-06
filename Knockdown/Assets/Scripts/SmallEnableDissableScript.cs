using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnableDissableScript : MonoBehaviour
{
    public GameObject EnableMe, DissableMe;
    
    public void Enable_Dissable ()
    {
        EnableMe.gameObject.SetActive(true);
        DissableMe.gameObject.SetActive(false);
    }
}
