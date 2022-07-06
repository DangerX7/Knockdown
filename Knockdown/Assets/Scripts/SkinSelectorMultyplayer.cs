using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SkinSelectorMultyplayer : MonoBehaviour
{
//    public InputActionAsset primaryActions;
 //   InputActionMap playerActionMap;
    private MasterScript masterScript;
    private SaveTest jsonScript;
    private SoundsScript soundScript;
    public float movementX; //player x axis, use in both onMove and FixedUpdate functions
    public GameObject skinsP1, skinsP2, skinsP3, skinsP4, skins2X, Locks, lock2;
    public byte playerNumber;
    public bool selection;
    public bool iconTeleport;
    public int P1skin;
    public int P2skin;
    public int P3skin;
    public int P4skin;
    public bool extra;
    public bool limitLeft;
    public bool limitRight;
    float moveMeasure;
    public bool lockMovement;

    /*
    #region New Controls
    public void Awake()
    {
        playerActionMap = primaryActions.FindActionMap("Player");
    }
    private void OnEnable()
    {
        playerActionMap.Enable();
    }
    private void OnDisable()
    {

    }
    #endregion
    */
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("MASTER OBJECT") != null)
        {
            masterScript = GameObject.Find("MASTER OBJECT").GetComponent<MasterScript>();
            jsonScript = GameObject.Find("MASTER OBJECT").GetComponent<SaveTest>();
            if ((masterScript.multiplayerMode == 12 || masterScript.multiplayerMode == 22 ||
                masterScript.multiplayerMode == 32 || masterScript.multiplayerMode == 42 || masterScript.multiplayerMode == 50) && playerNumber == 3)
            {
                Destroy(skinsP3.gameObject);
                Destroy(this.gameObject);
                Destroy(Locks.gameObject);
            }
            if ((masterScript.multiplayerMode == 12 || masterScript.multiplayerMode == 13 ||
                masterScript.multiplayerMode == 22 || masterScript.multiplayerMode == 23 ||
                masterScript.multiplayerMode == 32 || masterScript.multiplayerMode == 33 ||
                masterScript.multiplayerMode == 42 || masterScript.multiplayerMode == 50) && playerNumber == 4)
            {
                Destroy(skinsP4.gameObject);
                Destroy(this.gameObject);
                Destroy(Locks.gameObject);
            }
            if (masterScript.multiplayerMode == 42)
            {
                GameObject ParentSk = GameObject.Find("Skins");
                ParentSk.transform.GetChild(4).gameObject.SetActive(true);
                ParentSk.transform.GetChild(1).gameObject.SetActive(false);
                GameObject ParentL = GameObject.Find("Locks");
                ParentL.transform.GetChild(4).gameObject.SetActive(true);
                ParentL.transform.GetChild(1).gameObject.SetActive(false);
                GameObject ParentSe = GameObject.Find("Selectors");
                ParentSe.transform.GetChild(4).gameObject.SetActive(true);
                ParentSe.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
        soundScript = GameObject.Find("Sound").GetComponent<SoundsScript>();
        moveMeasure = 2.14f;
    }

    #region Scrolling Code

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!selection)
        {
            if (movementX == -1)
            {
                iconTeleport = true;
                selection = true;
                StartCoroutine(GoLeftCoroutine());
            }
            if (movementX == 1)
            {
                iconTeleport = true;
                selection = true;
                StartCoroutine(GoRightCoroutine());
            }
        }

        if (movementX != 0)
        {
            Locks.SetActive(false);
        }
        else
        {
            Locks.SetActive(true);
        }
    }

    public void ToLeft()
    {
        if (!lockMovement)
        {
            movementX = -1;
        }
    }
    public void ToRight()
    {
        if (!lockMovement)
        {
            movementX = 1;
        }
    }
    public void StopMove()
    {
        movementX = 0;
    }

    public void LockMove()
    {
        soundScript.PlayChangeCategory();
        lockMovement = true;
    }
    public void UnlockMove()
    {
        soundScript.PlayChangeMode();
        lockMovement = false;
    }
    /*
    //Move1 from OnMove1 function is the name of the action map of the inputs
    private void OnMove1(InputValue movementValue)
    {
        if (playerNumber == 1)
        {
            Vector2 movementVector = movementValue.Get<Vector2>();
            movementX = movementVector.x;
        }
    }
    private void OnMove2(InputValue movementValue)
    {
        if (playerNumber == 2)
        {
            Vector2 movementVector = movementValue.Get<Vector2>();
            movementX = movementVector.x;
        }
    }
    private void OnMove3(InputValue movementValue)
    {
        if (playerNumber == 3)
        {
            Vector2 movementVector = movementValue.Get<Vector2>();
            movementX = movementVector.x;
        }
    }
    private void OnMove4(InputValue movementValue)
    {
        if (playerNumber == 4)
        {
            Vector2 movementVector = movementValue.Get<Vector2>();
            movementX = movementVector.x;
        }
    }
    */
    IEnumerator GoLeftCoroutine()
    {
        yield return new WaitForSeconds(0.01f);
        MoveLeft();
        yield return new WaitForSeconds(0.01f);
        MoveLeft();
        yield return new WaitForSeconds(0.01f);
        MoveLeft();
        yield return new WaitForSeconds(0.01f);
        MoveLeft();
        yield return new WaitForSeconds(0.01f);
        MoveLeft();
        yield return new WaitForSeconds(0.01f);
        MoveLeft();
        yield return new WaitForSeconds(0.01f);
        MoveLeft();
        yield return new WaitForSeconds(0.01f);
        MoveLeft();
        yield return new WaitForSeconds(0.01f);
        MoveLeft();
        yield return new WaitForSeconds(0.01f);
        MoveLeft();
        selection = false;
    }
    IEnumerator GoRightCoroutine()
    {
        yield return new WaitForSeconds(0.01f);
        MoveRight();
        yield return new WaitForSeconds(0.01f);
        MoveRight();
        yield return new WaitForSeconds(0.01f);
        MoveRight();
        yield return new WaitForSeconds(0.01f);
        MoveRight();
        yield return new WaitForSeconds(0.01f);
        MoveRight();
        yield return new WaitForSeconds(0.01f);
        MoveRight();
        yield return new WaitForSeconds(0.01f);
        MoveRight();
        yield return new WaitForSeconds(0.01f);
        MoveRight();
        yield return new WaitForSeconds(0.01f);
        MoveRight();
        yield return new WaitForSeconds(0.01f);
        MoveRight();
        selection = false;
    }

    public void GoLeft()
    {
        if (!selection)
        {
            selection = true;
            StartCoroutine(GoLeftCoroutine());
        }
    }
    public void GoRight()
    {
        if (!selection)
        {
            selection = true;
            StartCoroutine(GoRightCoroutine());
        }
    }

    private void MoveLeft()
    {
        soundScript.PlayChangeMode();
        switch (playerNumber)
        {
            case 1:
                skinsP1.transform.position += Vector3.right * moveMeasure;
                break;
            case 2:
                if (!limitLeft)
                {
                    skinsP2.transform.position += Vector3.right * moveMeasure;
                }
                break;
            case 3:
                skinsP3.transform.position += Vector3.right * moveMeasure;
                break;
            case 4:
                skinsP4.transform.position += Vector3.right * moveMeasure;
                break;
        }
    }
    private void MoveRight()
    {
        soundScript.PlayChangeMode();
        switch (playerNumber)
        {
            case 1:
                skinsP1.transform.position += Vector3.left * moveMeasure;
                break;
            case 2:
                if (!limitRight)
                {
                    skinsP2.transform.position += Vector3.left * moveMeasure;
                }
                break;
            case 3:
                skinsP3.transform.position += Vector3.left * moveMeasure;
                break;
            case 4:
                skinsP4.transform.position += Vector3.left * moveMeasure;
                break;
        }
    }

    #endregion


    #region Skin Read
    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.gameObject.name == ("s1"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 1;
                    break;
                case 2:
                    masterScript.P2skin = 1;
                    break;
                case 3:
                    masterScript.P3skin = 1;
                    break;
                case 4:
                    masterScript.P4skin = 1;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s2"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 2;
                    break;
                case 2:
                    masterScript.P2skin = 2;
                    break;
                case 3:
                    masterScript.P3skin = 2;
                    break;
                case 4:
                    masterScript.P4skin = 2;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s3"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 3;
                    break;
                case 2:
                    masterScript.P2skin = 3;
                    break;
                case 3:
                    masterScript.P3skin = 3;
                    break;
                case 4:
                    masterScript.P4skin = 3;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s4"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 4;
                    break;
                case 2:
                    masterScript.P2skin = 4;
                    break;
                case 3:
                    masterScript.P3skin = 4;
                    break;
                case 4:
                    masterScript.P4skin = 4;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s5"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 5;
                    break;
                case 2:
                    masterScript.P2skin = 5;
                    break;
                case 3:
                    masterScript.P3skin = 5;
                    break;
                case 4:
                    masterScript.P4skin = 5;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s6"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 6;
                    break;
                case 2:
                    masterScript.P2skin = 6;
                    break;
                case 3:
                    masterScript.P3skin = 6;
                    break;
                case 4:
                    masterScript.P4skin = 6;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s7"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 7;
                    break;
                case 2:
                    masterScript.P2skin = 7;
                    break;
                case 3:
                    masterScript.P3skin = 7;
                    break;
                case 4:
                    masterScript.P4skin = 7;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s8"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 8;
                    break;
                case 2:
                    masterScript.P2skin = 8;
                    break;
                case 3:
                    masterScript.P3skin = 8;
                    break;
                case 4:
                    masterScript.P4skin = 8;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s9"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 9;
                    break;
                case 2:
                    masterScript.P2skin = 9;
                    break;
                case 3:
                    masterScript.P3skin = 9;
                    break;
                case 4:
                    masterScript.P4skin = 9;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s10"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 10;
                    break;
                case 2:
                    masterScript.P2skin = 10;
                    break;
                case 3:
                    masterScript.P3skin = 10;
                    break;
                case 4:
                    masterScript.P4skin = 10;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s11"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 11;
                    break;
                case 2:
                    masterScript.P2skin = 11;
                    break;
                case 3:
                    masterScript.P3skin = 11;
                    break;
                case 4:
                    masterScript.P4skin = 11;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s12"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 12;
                    break;
                case 2:
                    masterScript.P2skin = 12;
                    break;
                case 3:
                    masterScript.P3skin = 12;
                    break;
                case 4:
                    masterScript.P4skin = 12;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s13"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 13;
                    break;
                case 2:
                    masterScript.P2skin = 13;
                    break;
                case 3:
                    masterScript.P3skin = 13;
                    break;
                case 4:
                    masterScript.P4skin = 13;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s14"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 14;
                    break;
                case 2:
                    masterScript.P2skin = 14;
                    break;
                case 3:
                    masterScript.P3skin = 14;
                    break;
                case 4:
                    masterScript.P4skin = 14;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s15"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 15;
                    break;
                case 2:
                    masterScript.P2skin = 15;
                    break;
                case 3:
                    masterScript.P3skin = 15;
                    break;
                case 4:
                    masterScript.P4skin = 15;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s16"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 16;
                    break;
                case 2:
                    masterScript.P2skin = 16;
                    break;
                case 3:
                    masterScript.P3skin = 16;
                    break;
                case 4:
                    masterScript.P4skin = 16;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s17"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 101;
                    break;
                case 2:
                    masterScript.P2skin = 101;
                    break;
                case 3:
                    masterScript.P3skin = 101;
                    break;
                case 4:
                    masterScript.P4skin = 101;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s18"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 18;
                    break;
                case 2:
                    masterScript.P2skin = 18;
                    break;
                case 3:
                    masterScript.P3skin = 18;
                    break;
                case 4:
                    masterScript.P4skin = 18;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s19"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 19;
                    break;
                case 2:
                    masterScript.P2skin = 19;
                    break;
                case 3:
                    masterScript.P3skin = 19;
                    break;
                case 4:
                    masterScript.P4skin = 19;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s20"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 20;
                    break;
                case 2:
                    masterScript.P2skin = 20;
                    break;
                case 3:
                    masterScript.P3skin = 20;
                    break;
                case 4:
                    masterScript.P4skin = 20;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s21"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 21;
                    break;
                case 2:
                    masterScript.P2skin = 21;
                    break;
                case 3:
                    masterScript.P3skin = 21;
                    break;
                case 4:
                    masterScript.P4skin = 21;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s22"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 22;
                    break;
                case 2:
                    masterScript.P2skin = 22;
                    break;
                case 3:
                    masterScript.P3skin = 22;
                    break;
                case 4:
                    masterScript.P4skin = 22;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s23"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 23;
                    break;
                case 2:
                    masterScript.P2skin = 23;
                    break;
                case 3:
                    masterScript.P3skin = 23;
                    break;
                case 4:
                    masterScript.P4skin = 23;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s24"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 24;
                    break;
                case 2:
                    masterScript.P2skin = 24;
                    break;
                case 3:
                    masterScript.P3skin = 24;
                    break;
                case 4:
                    masterScript.P4skin = 24;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s25"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 25;
                    break;
                case 2:
                    masterScript.P2skin = 25;
                    break;
                case 3:
                    masterScript.P3skin = 25;
                    break;
                case 4:
                    masterScript.P4skin = 25;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s26"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 26;
                    break;
                case 2:
                    masterScript.P2skin = 26;
                    break;
                case 3:
                    masterScript.P3skin = 26;
                    break;
                case 4:
                    masterScript.P4skin = 26;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s27"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 27;
                    break;
                case 2:
                    masterScript.P2skin = 27;
                    break;
                case 3:
                    masterScript.P3skin = 27;
                    break;
                case 4:
                    masterScript.P4skin = 27;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s28"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 28;
                    break;
                case 2:
                    masterScript.P2skin = 28;
                    break;
                case 3:
                    masterScript.P3skin = 28;
                    break;
                case 4:
                    masterScript.P4skin = 28;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s29"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 29;
                    break;
                case 2:
                    masterScript.P2skin = 29;
                    break;
                case 3:
                    masterScript.P3skin = 29;
                    break;
                case 4:
                    masterScript.P4skin = 29;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s30"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 30;
                    break;
                case 2:
                    masterScript.P2skin = 30;
                    break;
                case 3:
                    masterScript.P3skin = 30;
                    break;
                case 4:
                    masterScript.P4skin = 30;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s31"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 31;
                    break;
                case 2:
                    masterScript.P2skin = 31;
                    break;
                case 3:
                    masterScript.P3skin = 31;
                    break;
                case 4:
                    masterScript.P4skin = 31;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s32"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 32;
                    break;
                case 2:
                    masterScript.P2skin = 32;
                    break;
                case 3:
                    masterScript.P3skin = 32;
                    break;
                case 4:
                    masterScript.P4skin = 32;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s33"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 33;
                    break;
                case 2:
                    masterScript.P2skin = 33;
                    break;
                case 3:
                    masterScript.P3skin = 33;
                    break;
                case 4:
                    masterScript.P4skin = 33;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s34"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 34;
                    break;
                case 2:
                    masterScript.P2skin = 34;
                    break;
                case 3:
                    masterScript.P3skin = 34;
                    break;
                case 4:
                    masterScript.P4skin = 34;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s35"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 35;
                    break;
                case 2:
                    masterScript.P2skin = 35;
                    break;
                case 3:
                    masterScript.P3skin = 35;
                    break;
                case 4:
                    masterScript.P4skin = 35;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s36"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 36;
                    break;
                case 2:
                    masterScript.P2skin = 36;
                    break;
                case 3:
                    masterScript.P3skin = 36;
                    break;
                case 4:
                    masterScript.P4skin = 36;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s37"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 37;
                    break;
                case 2:
                    masterScript.P2skin = 37;
                    break;
                case 3:
                    masterScript.P3skin = 37;
                    break;
                case 4:
                    masterScript.P4skin = 37;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s38"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 38;
                    break;
                case 2:
                    masterScript.P2skin = 38;
                    break;
                case 3:
                    masterScript.P3skin = 38;
                    break;
                case 4:
                    masterScript.P4skin = 38;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s39"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 39;
                    break;
                case 2:
                    masterScript.P2skin = 39;
                    break;
                case 3:
                    masterScript.P3skin = 39;
                    break;
                case 4:
                    masterScript.P4skin = 39;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s40"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 40;
                    break;
                case 2:
                    masterScript.P2skin = 40;
                    break;
                case 3:
                    masterScript.P3skin = 40;
                    break;
                case 4:
                    masterScript.P4skin = 40;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s41"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 41;
                    break;
                case 2:
                    masterScript.P2skin = 41;
                    break;
                case 3:
                    masterScript.P3skin = 41;
                    break;
                case 4:
                    masterScript.P4skin = 41;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s42"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 42;
                    break;
                case 2:
                    masterScript.P2skin = 42;
                    break;
                case 3:
                    masterScript.P3skin = 42;
                    break;
                case 4:
                    masterScript.P4skin = 42;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s43"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 43;
                    break;
                case 2:
                    masterScript.P2skin = 43;
                    break;
                case 3:
                    masterScript.P3skin = 43;
                    break;
                case 4:
                    masterScript.P4skin = 43;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s44"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 44;
                    break;
                case 2:
                    masterScript.P2skin = 44;
                    break;
                case 3:
                    masterScript.P3skin = 44;
                    break;
                case 4:
                    masterScript.P4skin = 44;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s45"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 45;
                    break;
                case 2:
                    masterScript.P2skin = 45;
                    break;
                case 3:
                    masterScript.P3skin = 45;
                    break;
                case 4:
                    masterScript.P4skin = 45;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s46"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 46;
                    break;
                case 2:
                    masterScript.P2skin = 46;
                    break;
                case 3:
                    masterScript.P3skin = 46;
                    break;
                case 4:
                    masterScript.P4skin = 46;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s47"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 47;
                    break;
                case 2:
                    masterScript.P2skin = 47;
                    break;
                case 3:
                    masterScript.P3skin = 47;
                    break;
                case 4:
                    masterScript.P4skin = 47;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s48"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 48;
                    break;
                case 2:
                    masterScript.P2skin = 48;
                    break;
                case 3:
                    masterScript.P3skin = 48;
                    break;
                case 4:
                    masterScript.P4skin = 48;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s49"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 49;
                    break;
                case 2:
                    masterScript.P2skin = 49;
                    break;
                case 3:
                    masterScript.P3skin = 49;
                    break;
                case 4:
                    masterScript.P4skin = 49;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s50"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 50;
                    break;
                case 2:
                    masterScript.P2skin = 50;
                    break;
                case 3:
                    masterScript.P3skin = 50;
                    break;
                case 4:
                    masterScript.P4skin = 50;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s51"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 51;
                    break;
                case 2:
                    masterScript.P2skin = 51;
                    break;
                case 3:
                    masterScript.P3skin = 51;
                    break;
                case 4:
                    masterScript.P4skin = 51;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s52"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 52;
                    break;
                case 2:
                    masterScript.P2skin = 52;
                    break;
                case 3:
                    masterScript.P3skin = 52;
                    break;
                case 4:
                    masterScript.P4skin = 52;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s52"))//dfs 104 105 106 102 107 108 109 110 103
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 52;
                    break;
                case 2:
                    masterScript.P2skin = 52;
                    break;
                case 3:
                    masterScript.P3skin = 52;
                    break;
                case 4:
                    masterScript.P4skin = 52;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s53"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 104;
                    break;
                case 2:
                    masterScript.P2skin = 104;
                    break;
                case 3:
                    masterScript.P3skin = 104;
                    break;
                case 4:
                    masterScript.P4skin = 104;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s54"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 105;
                    break;
                case 2:
                    masterScript.P2skin = 105;
                    break;
                case 3:
                    masterScript.P3skin = 105;
                    break;
                case 4:
                    masterScript.P4skin = 105;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s55"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 106;
                    break;
                case 2:
                    masterScript.P2skin = 106;
                    break;
                case 3:
                    masterScript.P3skin = 106;
                    break;
                case 4:
                    masterScript.P4skin = 106;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s56"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 102;
                    break;
                case 2:
                    masterScript.P2skin = 102;
                    break;
                case 3:
                    masterScript.P3skin = 102;
                    break;
                case 4:
                    masterScript.P4skin = 102;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s57"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 107;
                    break;
                case 2:
                    masterScript.P2skin = 107;
                    break;
                case 3:
                    masterScript.P3skin = 107;
                    break;
                case 4:
                    masterScript.P4skin = 107;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s58"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 108;
                    break;
                case 2:
                    masterScript.P2skin = 108;
                    break;
                case 3:
                    masterScript.P3skin = 108;
                    break;
                case 4:
                    masterScript.P4skin = 108;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s59"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 109;
                    break;
                case 2:
                    masterScript.P2skin = 109;
                    break;
                case 3:
                    masterScript.P3skin = 109;
                    break;
                case 4:
                    masterScript.P4skin = 109;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s60"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 110;
                    break;
                case 2:
                    masterScript.P2skin = 110;
                    break;
                case 3:
                    masterScript.P3skin = 110;
                    break;
                case 4:
                    masterScript.P4skin = 110;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s61"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 103;
                    break;
                case 2:
                    masterScript.P2skin = 103;
                    break;
                case 3:
                    masterScript.P3skin = 103;
                    break;
                case 4:
                    masterScript.P4skin = 103;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s62"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 111;
                    break;
                case 2:
                    masterScript.P2skin = 111;
                    break;
                case 3:
                    masterScript.P3skin = 111;
                    break;
                case 4:
                    masterScript.P4skin = 111;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s63"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 112;
                    break;
                case 2:
                    masterScript.P2skin = 112;
                    break;
                case 3:
                    masterScript.P3skin = 112;
                    break;
                case 4:
                    masterScript.P4skin = 112;
                    break;
            }
        }

        if (col.transform.gameObject.name == ("s64"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 123;
                    break;
                case 2:
                    masterScript.P2skin = 123;
                    break;
                case 3:
                    masterScript.P3skin = 123;
                    break;
                case 4:
                    masterScript.P4skin = 123;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s65"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 122;
                    break;
                case 2:
                    masterScript.P2skin = 122;
                    break;
                case 3:
                    masterScript.P3skin = 122;
                    break;
                case 4:
                    masterScript.P4skin = 122;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s66"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 127;
                    break;
                case 2:
                    masterScript.P2skin = 127;
                    break;
                case 3:
                    masterScript.P3skin = 127;
                    break;
                case 4:
                    masterScript.P4skin = 127;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s67"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 124;
                    break;
                case 2:
                    masterScript.P2skin = 124;
                    break;
                case 3:
                    masterScript.P3skin = 124;
                    break;
                case 4:
                    masterScript.P4skin = 124;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s68"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 121;
                    break;
                case 2:
                    masterScript.P2skin = 121;
                    break;
                case 3:
                    masterScript.P3skin = 121;
                    break;
                case 4:
                    masterScript.P4skin = 121;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s69"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 128;
                    break;
                case 2:
                    masterScript.P2skin = 128;
                    break;
                case 3:
                    masterScript.P3skin = 128;
                    break;
                case 4:
                    masterScript.P4skin = 128;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s70"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 126;
                    break;
                case 2:
                    masterScript.P2skin = 126;
                    break;
                case 3:
                    masterScript.P3skin = 126;
                    break;
                case 4:
                    masterScript.P4skin = 126;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s71"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 129;
                    break;
                case 2:
                    masterScript.P2skin = 129;
                    break;
                case 3:
                    masterScript.P3skin = 129;
                    break;
                case 4:
                    masterScript.P4skin = 129;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s72"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 125;
                    break;
                case 2:
                    masterScript.P2skin = 125;
                    break;
                case 3:
                    masterScript.P3skin = 125;
                    break;
                case 4:
                    masterScript.P4skin = 125;
                    break;
            }
        }
        if (col.transform.gameObject.name == ("s73"))
        {
            switch (playerNumber)
            {
                case 1:
                    masterScript.P1skin = 130;
                    break;
                case 2:
                    masterScript.P2skin = 130;
                    break;
                case 3:
                    masterScript.P3skin = 130;
                    break;
                case 4:
                    masterScript.P4skin = 130;
                    break;
            }
        }
        //for control bosses transparent skins
        switch (col.transform.gameObject.name)
        {
            case "b10":
                masterScript.P2skin = -1;
                break;
            case "b11":
                masterScript.P2skin = -2;
                break;
            case "b12":
                masterScript.P2skin = -3;
                break;
            case "b13":
                masterScript.P2skin = -4;
                break;
            case "b14":
                masterScript.P2skin = -5;
                break;
            case "b15":
                masterScript.P2skin = -6;
                break;
            case "b16":
                masterScript.P2skin = -7;
                break;
        }
    }
    #endregion


    public void UnlockSkinsArcade()
    {
        if (jsonScript.so.isSkin2Available)
        {
            lock2.SetActive(false);
        }
    }

}
