using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class multiplayerMenuControls : MonoBehaviour
{
    //   MenuControls menuControls;
    public GameObject confirmTextRef1, confirmTextRef2, confirmTextRef3, confirmTextRef4, confirmTextRef2X;
    private MasterScript masterScript;
    private SaveTest jsonScript;
    private SoundsScript soundScript;
    public bool lockEnter;
    public bool lockEnter1;
    public bool lockEnter2;
    public bool lockEnter3;
    public bool lockEnter4;
    public bool isP1Ready;
    public bool isP2Ready;
    public bool isP3Ready;
    public bool isP4Ready;
    public bool inputCheck;
    /*
    public void Awake()
    {
        menuControls = new MenuControls();
        menuControls.Menu.Pause.performed += ctx => AdvanceMode();
        menuControls.Menu.Return.performed += ctx => ReturnToTitleScreen();
    }
    private void OnEnable()
    {
        menuControls.Menu.Enable();
    }
    private void OnDisable()
    {
        menuControls.Menu.Disable();
    }
    */
    #region Set Level Number and Advance to Selected Mode
    public void AdvanceMode()
    {
        soundScript.PlayModeSelect();
        if (!lockEnter)
        {
            StartCoroutine(GoToGame());
        }
    }

    IEnumerator GoToGame()
    {
        yield return new WaitForSeconds(0.5f);
        switch (masterScript.multiplayerMode)
        {
            case 12:
            case 13:
            case 14:
                jsonScript.so.levelNumber = "arena";
                SceneManager.LoadScene("Arena");
                break;
            case 22:
            case 23:
            case 24:
                jsonScript.so.levelNumber = "versus";
                SceneManager.LoadScene("Versus");
                break;
            case 32:
                SceneManager.LoadScene("Dodgeball 2P");
                break;
            case 33:
                SceneManager.LoadScene("Dodgeball 3P");
                break;
            case 34:
                SceneManager.LoadScene("Dodgeball 4P");
                break;
            case 42:
                jsonScript.so.levelNumber = "control";
                SceneManager.LoadScene("Control");
                break;
            case 50:
                jsonScript.so.levelNumber = "colosseum";
                SceneManager.LoadScene("Colosseum");
                break;
        }
    }
    #endregion

    public void ReturnToTitleScreen()
    {
        SceneManager.LoadScene("Title Screen");
    }
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("MASTER OBJECT") != null)
        {
            masterScript = GameObject.Find("MASTER OBJECT").GetComponent<MasterScript>();
            jsonScript = GameObject.Find("MASTER OBJECT").GetComponent<SaveTest>();
        }
        soundScript = GameObject.Find("Sound").GetComponent<SoundsScript>();
        inputCheck = true;
    }

    // Update is called once per frame
    void Update()
    {
        #region Read Every Lock
        switch (masterScript.multiplayerMode)
        {
            case 12:
            case 22:
            case 32:
            case 42:
                if (!lockEnter1 && !lockEnter2)
                {
                    lockEnter = false;
                }
                else if (lockEnter1 || lockEnter2)
                {
                    lockEnter = true;
                }
                break;
            case 13:
            case 23:
            case 33:
                if (!lockEnter1 && !lockEnter2 && !lockEnter3)
                {
                    lockEnter = false;
                }
                else if (lockEnter1 || lockEnter2 || lockEnter3)
                {
                    lockEnter = true;
                }
                break;
            case 14:
            case 24:
            case 34:
                if (!lockEnter1 && !lockEnter2 && !lockEnter3 && !lockEnter4)
                {
                    lockEnter = false;
                }
                else if (lockEnter1 || lockEnter2 || lockEnter3 || lockEnter4)
                {
                    lockEnter = true;
                }
                break;
        }
        #endregion
    }
}
