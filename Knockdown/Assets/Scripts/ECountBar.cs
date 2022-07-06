using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECountBar : MonoBehaviour
{
    public Animator animator;
    public bool destroyBar;
    public int barNumber;
    void Start()
    {
    //    destroyBar = true;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("destroyBar", destroyBar);
        if (destroyBar)
        {//Play Enemy ball counter destroy animation
            StartCoroutine(RemoveObjectTimer());
        }
    }

    IEnumerator RemoveObjectTimer()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
