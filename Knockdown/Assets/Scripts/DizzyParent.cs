using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DizzyParent : MonoBehaviour
{
    public GameObject ball1, ball2, ball3, ball4;
    GameObject PlayerParent;
    PlayerScript playerscript;
    private int playerNumber;

    public void Start()
    {
        PlayerParent = transform.parent.gameObject;
        playerscript = PlayerParent.GetComponent<PlayerScript>();
        playerNumber = playerscript.playerNumber;
    }
    #region Make Balls Appear
    public void MakeBallsAppear()
    {
        StartCoroutine(AppearDelay());
    }
    IEnumerator AppearDelay()
    {
        float delay = 0.2f;
        switch(playerNumber)
        {
            case 1:
                Instantiate(ball1, transform.position, ball1.transform.rotation);
                break;
            case 2:
                Instantiate(ball2, transform.position, ball2.transform.rotation);
                break;
            case 3:
                Instantiate(ball3, transform.position, ball3.transform.rotation);
                break;
            case 4:
                Instantiate(ball4, transform.position, ball4.transform.rotation);
                break;
        }
        yield return new WaitForSeconds(delay);
        switch (playerNumber)
        {
            case 1:
                Instantiate(ball1, transform.position, ball1.transform.rotation);
                break;
            case 2:
                Instantiate(ball2, transform.position, ball2.transform.rotation);
                break;
            case 3:
                Instantiate(ball3, transform.position, ball3.transform.rotation);
                break;
            case 4:
                Instantiate(ball4, transform.position, ball4.transform.rotation);
                break;
        }
        yield return new WaitForSeconds(delay);
        switch (playerNumber)
        {
            case 1:
                Instantiate(ball1, transform.position, ball1.transform.rotation);
                break;
            case 2:
                Instantiate(ball2, transform.position, ball2.transform.rotation);
                break;
            case 3:
                Instantiate(ball3, transform.position, ball3.transform.rotation);
                break;
            case 4:
                Instantiate(ball4, transform.position, ball4.transform.rotation);
                break;
        }
        yield return new WaitForSeconds(delay);
        switch (playerNumber)
        {
            case 1:
                Instantiate(ball1, transform.position, ball1.transform.rotation);
                break;
            case 2:
                Instantiate(ball2, transform.position, ball2.transform.rotation);
                break;
            case 3:
                Instantiate(ball3, transform.position, ball3.transform.rotation);
                break;
            case 4:
                Instantiate(ball4, transform.position, ball4.transform.rotation);
                break;
        }
    }
    #endregion


    #region Make Balls Dissapear
    public void MakeBallsDissapear1()
    {
        GameObject[] balls1 = GameObject.FindGameObjectsWithTag("D1");
        foreach (GameObject ball1 in balls1)
            GameObject.Destroy(ball1);
        Debug.Log("fgh");
    }
    public void MakeBallsDissapear2()
    {
        GameObject[] balls2 = GameObject.FindGameObjectsWithTag("D2");
        foreach (GameObject ball2 in balls2)
            GameObject.Destroy(ball2);
    }
    public void MakeBallsDissapear3()
    {
        GameObject[] balls3 = GameObject.FindGameObjectsWithTag("D3");
        foreach (GameObject ball3 in balls3)
            GameObject.Destroy(ball3);
    }
    public void MakeBallsDissapear4()
    {
        GameObject[] balls4 = GameObject.FindGameObjectsWithTag("D4");
        foreach (GameObject ball4 in balls4)
            GameObject.Destroy(ball4);
    }
    #endregion
}
