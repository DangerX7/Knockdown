using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMenuScript : MonoBehaviour
{
    #region Set Variables
    //  MenuControls menuControls;
    private MasterScript masterScript;
    private SaveTest jsonScript;
    private SoundsScript soundScript;
    public GameObject L0, L1x1, L1x2, L1x3, L1x4, L1x5, L1x6, L2x1, L2x2, L2x3, L2x4, L2x5, L2x6, L2x7, L2x8, L2x9, L2x10, L2x11, L2x12,
        L3x1, L3x2, L3x3, L3x4, L3x5, L3x6, L3x7, L3x8, L3x9, L3x10, L3x11, L3x12, L3x13, L3x14, L3x15, L3x16, L4x1, L4x2, L4x3, L4x4,
        L4x5, L4x6, L4x7, L4x8, L4x9, L4x10, L4x11, L4x12, L4x13, L4x14, L5x1, L5x2, L5x3, L5x4, L5x5, L5x6, L5x7, L5x8, L5x9, L5x10,
        Levels;
    ///   public Animator animator;
    public Vector3 lookDirrection;
    public int rotationDir;
    public Rigidbody rb;
    public int advanceDistance;
    public bool moveSwitch;
    public int speed;
    public float dragDistance;
    public bool inputLock;
 //   public uint balaur;

    public int inputSwitch;
    public int inputCoroutineTimer;
    Coroutine routine;
    #endregion

    /*
    #region New Controls
    public void Awake()
    {
        menuControls = new MenuControls();
        menuControls.Menu.Pause.performed += ctx => StartLevel();
        menuControls.Menu.Return.performed += ctx => ReturnToTitleScreen();
        menuControls.Menu.Restart.performed += ctx => ChangeSkin();
        menuControls.Menu.GoUp.performed += ctx => GoUp();
        menuControls.Menu.GoDown.performed += ctx => GoDown();
        menuControls.Menu.GoLeft.performed += ctx => GoLeft();
        menuControls.Menu.GoRight.performed += ctx => GoRight();
    }
    private void OnEnable()
    {
        menuControls.Menu.Enable();
    }
    private void OnDisable()
    {
        menuControls.Menu.Disable();
    }
    #endregion
    */

    private void Start()
    {
        if (GameObject.Find("MASTER OBJECT") != null)
        {
            masterScript = GameObject.Find("MASTER OBJECT").GetComponent<MasterScript>();
            jsonScript = GameObject.Find("MASTER OBJECT").GetComponent<SaveTest>();
        }
        soundScript = GameObject.Find("Sound").GetComponent<SoundsScript>();
        advanceDistance = 10;//200
        speed = 10000;//100000
        dragDistance = 55.5f;
        masterScript.multiplayerMode = 0;
        lookDirrection = new Vector3(0, 0.1f, 0);
        ContinueFromLastLevel();

        switch (jsonScript.so.playerSkin)
        {
            case 1:
                transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 2:
                transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 3:
                transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 4:
                transform.GetChild(3).gameObject.SetActive(true);
                break;
            case 5:
                transform.GetChild(4).gameObject.SetActive(true);
                break;
            case 6:
                transform.GetChild(5).gameObject.SetActive(true);
                break;
            case 7:
                transform.GetChild(6).gameObject.SetActive(true);
                break;
            case 8:
                transform.GetChild(7).gameObject.SetActive(true);
                break;
            case 9:
                transform.GetChild(8).gameObject.SetActive(true);
                break;
            case 10:
                transform.GetChild(9).gameObject.SetActive(true);
                break;
            case 11:
                transform.GetChild(10).gameObject.SetActive(true);
                break;
            case 12:
                transform.GetChild(11).gameObject.SetActive(true);
                break;
            case 13:
                transform.GetChild(12).gameObject.SetActive(true);
                break;
            case 14:
                transform.GetChild(13).gameObject.SetActive(true);
                break;
            case 15:
                transform.GetChild(14).gameObject.SetActive(true);
                break;
            case 16:
                transform.GetChild(15).gameObject.SetActive(true);
                break;
            case 123:
                transform.GetChild(16).gameObject.SetActive(true);
                break;
            case 122:
                transform.GetChild(17).gameObject.SetActive(true);
                break;
            case 127:
                transform.GetChild(18).gameObject.SetActive(true);
                break;
            case 124:
                transform.GetChild(19).gameObject.SetActive(true);
                break;
            case 121:
                transform.GetChild(20).gameObject.SetActive(true);
                break;
            case 102:
                transform.GetChild(21).gameObject.SetActive(true);
                break;
            case 128:
                transform.GetChild(22).gameObject.SetActive(true);
                break;
            case 103:
                transform.GetChild(23).gameObject.SetActive(true);
                break;
            case 112:
                transform.GetChild(24).gameObject.SetActive(true);
                break;
            case 126:
                transform.GetChild(25).gameObject.SetActive(true);
                break;
            case 101:
                transform.GetChild(26).gameObject.SetActive(true);
                break;
            case 129:
                transform.GetChild(27).gameObject.SetActive(true);
                break;
            case 125:
                transform.GetChild(28).gameObject.SetActive(true);
                break;
            case 104:
                transform.GetChild(29).gameObject.SetActive(true);
                break;
            case 111:
                transform.GetChild(30).gameObject.SetActive(true);
                break;
            case 130:
                transform.GetChild(31).gameObject.SetActive(true);
                break;
        }
    }
    private void Update()
    {
        if (jsonScript.so.levelNumber != "Title Screen")
        {
            jsonScript.so.levelOnMap = jsonScript.so.levelNumber;
        }
        ////    animator.SetBool("move", moveSwitch);
        if (moveSwitch)
        {
         //   Debug.Log("go");
            rb.AddForce(lookDirrection * speed * Time.deltaTime);
            switch (rotationDir)
            {
                case 1:
                    rb.AddTorque(new Vector3(10000, 0, 0) * Time.deltaTime);//up
                    break;
                case 2:
                    rb.AddTorque(new Vector3(-10000, 0, 0) * Time.deltaTime);//down
                    break;
                case 3:
                    rb.AddTorque(new Vector3(0, 10000, 0) * Time.deltaTime);//left
                    break;
                case 4:
                    rb.AddTorque(new Vector3(0, -10000, 0) * Time.deltaTime);//right
                    break;
            }
        }
        else
        {
        //    Debug.Log("stop");
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        if (inputLock && inputSwitch == 0)
        {
            StartCoroutine(InputTimerRoutine());
            inputSwitch = 1;
        }

        UnlockLevels();
    }
    #region GoUp Code
    public void GoUp()
    {
        if (!inputLock)
        {
            inputSwitch = 0;
            rotationDir = 1;
            switch (jsonScript.so.levelOnMap)
            {
                case "L0":
                    if (jsonScript.so.isLevel1x1Available)
                    {

                        lookDirrection = (L1x1.transform.position - transform.position).normalized;

                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                        //    transform.position = L1x1.transform.position;
                    }
                    break;
                case "L1-1":
                    if (jsonScript.so.isLevel1x2Available)
                    {
                        
                        lookDirrection = (L1x2.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L1-2":
                    if (jsonScript.so.isLevel1x3Available)
                    {
                        
                        lookDirrection = (L1x3.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L1-3":
                    if (jsonScript.so.isLevel1x5Available)
                    {
                        
                        lookDirrection = (L1x5.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L1-4":
                    if (jsonScript.so.isLevel1x5Available)
                    {
                        
                        lookDirrection = (L1x5.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L1-5":
                    if (jsonScript.so.isLevel1x6Available)
                    {
                        
                        lookDirrection = (L1x6.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L1-6":
                    if (jsonScript.so.isLevel2x1Available)
                    {
                        
                        lookDirrection = (L2x1.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-1":
                    if (jsonScript.so.isLevel2x3Available)
                    {
                        
                        lookDirrection = (L2x3.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-2":
                    if (jsonScript.so.isLevel2x4Available)
                    {
                        
                        lookDirrection = (L2x4.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-3":
                    if (jsonScript.so.isLevel2x4Available)
                    {
                        
                        lookDirrection = (L2x4.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-4":
                    if (jsonScript.so.isLevel2x6Available)
                    {
                        
                        lookDirrection = (L2x6.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-5":
                    if (jsonScript.so.isLevel2x9Available)
                    {
                        
                        lookDirrection = (L2x9.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-6":
                    if (jsonScript.so.isLevel2x9Available)
                    {
                        
                        lookDirrection = (L2x9.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-7":
                    if (jsonScript.so.isLevel2x9Available)
                    {
                        
                        lookDirrection = (L2x9.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-8":
                    if (jsonScript.so.isLevel2x9Available)
                    {
                        
                        lookDirrection = (L2x9.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-9":
                    if (jsonScript.so.isLevel2x10Available)
                    {
                        
                        lookDirrection = (L2x10.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-10":
                    if (jsonScript.so.isLevel2x12Available)
                    {
                        
                        lookDirrection = (L2x12.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-11":
                    if (jsonScript.so.isLevel2x12Available)
                    {
                        
                        lookDirrection = (L2x12.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-12":
                    if (jsonScript.so.isLevel3x1Available)
                    {
                        
                        lookDirrection = (L3x1.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-1":
                    if (jsonScript.so.isLevel3x2Available)
                    {
                        
                        lookDirrection = (L3x2.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-2":
                    if (jsonScript.so.isLevel3x3Available)
                    {
                        
                        lookDirrection = (L3x3.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-3":
                    if (jsonScript.so.isLevel3x4Available)
                    {
                        
                        lookDirrection = (L3x4.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-4":
                    if (jsonScript.so.isLevel3x7Available)
                    {
                        
                        lookDirrection = (L3x7.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-5":
                    if (jsonScript.so.isLevel3x7Available)
                    {
                        
                        lookDirrection = (L3x7.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-6":
                    if (jsonScript.so.isLevel3x9Available)
                    {
                        
                        lookDirrection = (L3x9.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-7":
                    if (jsonScript.so.isLevel3x9Available)
                    {
                        
                        lookDirrection = (L3x9.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-8":
                    if (jsonScript.so.isLevel3x9Available)
                    {
                        
                        lookDirrection = (L3x9.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-9":
                    if (jsonScript.so.isLevel3x12Available)
                    {
                        
                        lookDirrection = (L3x12.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-10":
                    if (jsonScript.so.isLevel3x14Available)
                    {
                        
                        lookDirrection = (L3x14.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-11":
                    if (jsonScript.so.isLevel3x14Available)
                    {
                        
                        lookDirrection = (L3x14.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-12":
                    if (jsonScript.so.isLevel3x15Available)
                    {
                        
                        lookDirrection = (L3x15.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-13":
                    if (jsonScript.so.isLevel3x15Available)
                    {
                        
                        lookDirrection = (L3x15.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-14":
                    if (jsonScript.so.isLevel3x16Available)
                    {
                        
                        lookDirrection = (L3x16.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-15":
                    if (jsonScript.so.isLevel3x16Available)
                    {
                        
                        lookDirrection = (L3x16.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-16":
                    if (jsonScript.so.isLevel4x1Available)
                    {
                        
                        lookDirrection = (L4x1.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-1":
                    if (jsonScript.so.isLevel4x2Available)
                    {
                        
                        lookDirrection = (L4x2.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-2":
                    if (jsonScript.so.isLevel4x3Available)
                    {
                        
                        lookDirrection = (L4x3.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-3":
                    if (jsonScript.so.isLevel4x4Available)
                    {
                        
                        lookDirrection = (L4x4.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-4":
                    if (jsonScript.so.isLevel4x6Available)
                    {
                        
                        lookDirrection = (L4x6.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-5":
                    if (jsonScript.so.isLevel4x7Available)
                    {
                        
                        lookDirrection = (L4x7.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-6":
                    if (jsonScript.so.isLevel4x8Available)
                    {
                        
                        lookDirrection = (L4x8.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-7":
                    if (jsonScript.so.isLevel4x8Available)
                    {
                        
                        lookDirrection = (L4x8.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-8":
                    if (jsonScript.so.isLevel4x9Available)
                    {
                        
                        lookDirrection = (L4x9.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-9":
                    if (jsonScript.so.isLevel4x10Available)
                    {
                        
                        lookDirrection = (L4x10.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-10":
                    if (jsonScript.so.isLevel4x12Available)
                    {
                        
                        lookDirrection = (L4x12.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-11":
                    if (jsonScript.so.isLevel4x14Available)
                    {
                        
                        lookDirrection = (L4x14.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-12":
                    if (jsonScript.so.isLevel4x14Available)
                    {
                        
                        lookDirrection = (L4x14.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-13":
                    if (jsonScript.so.isLevel4x14Available)
                    {
                        
                        lookDirrection = (L4x14.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-14":
                    if (jsonScript.so.isLevel5x1Available)
                    {
                        
                        lookDirrection = (L5x1.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L5-1":
                    if (jsonScript.so.isLevel5x3Available)
                    {
                        
                        lookDirrection = (L5x3.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L5-2":
                    if (jsonScript.so.isLevel5x4Available)
                    {
                        
                        lookDirrection = (L5x4.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L5-3":
                    if (jsonScript.so.isLevel5x4Available)
                    {
                        
                        lookDirrection = (L5x4.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L5-4":
                    if (jsonScript.so.isLevel5x5Available)
                    {
                        
                        lookDirrection = (L5x5.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L5-5":
                    if (jsonScript.so.isLevel5x7Available)
                    {
                        
                        lookDirrection = (L5x7.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L5-6":
                    if (jsonScript.so.isLevel5x7Available)
                    {
                        
                        lookDirrection = (L5x7.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L5-7":
                    if (jsonScript.so.isLevel5x8Available)
                    {
                        
                        lookDirrection = (L5x8.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L5-8":
                    if (jsonScript.so.isLevel5x9Available)
                    {
                        
                        lookDirrection = (L5x9.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L5-9":
                    if (jsonScript.so.isLevel5x10Available)
                    {
                        
                        lookDirrection = (L5x10.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
            }
        }
    }
    #endregion
    #region Go Down Code
    public void GoDown()
    {
        if (!inputLock)
        {
            inputSwitch = 0;
            rotationDir = 2;
            switch (jsonScript.so.levelNumber)
            {
                case "L1-1":
                    
                    lookDirrection = (L0.transform.position - transform.position).normalized;
                    moveSwitch = true;
                    inputLock = true;
                    soundScript.PlayDash();
                    break;
                case "L1-2":
                    if (jsonScript.so.isLevel1x1Available)
                    {
                        
                        lookDirrection = (L1x1.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L1-3":
                    if (jsonScript.so.isLevel1x2Available)
                    {
                        
                        lookDirrection = (L1x2.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L1-4":
                    if (jsonScript.so.isLevel1x2Available)
                    {
                        
                        lookDirrection = (L1x2.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L1-5":
                    if (jsonScript.so.isLevel1x4Available)
                    {
                        
                        lookDirrection = (L1x4.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L1-6":
                    if (jsonScript.so.isLevel1x5Available)
                    {
                        
                        lookDirrection = (L1x5.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-1":
                    if (jsonScript.so.isLevel1x6Available)
                    {
                        
                        lookDirrection = (L1x6.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-2":
                    if (jsonScript.so.isLevel2x1Available)
                    {
                        
                        lookDirrection = (L2x1.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-3":
                    if (jsonScript.so.isLevel2x1Available)
                    {
                        
                        lookDirrection = (L2x1.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-4":
                    if (jsonScript.so.isLevel2x3Available)
                    {
                        
                        lookDirrection = (L2x3.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-5":
                    if (jsonScript.so.isLevel2x4Available)
                    {
                        
                        lookDirrection = (L2x4.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-6":
                    if (jsonScript.so.isLevel2x4Available)
                    {
                        
                        lookDirrection = (L2x4.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-7":
                    if (jsonScript.so.isLevel2x4Available)
                    {
                        
                        lookDirrection = (L2x4.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-8":
                    if (jsonScript.so.isLevel2x4Available)
                    {
                        
                        lookDirrection = (L2x4.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-9":
                    if (jsonScript.so.isLevel2x7Available)
                    {
                        
                        lookDirrection = (L2x7.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-10":
                    if (jsonScript.so.isLevel2x9Available)
                    {
                        
                        lookDirrection = (L2x9.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-11":
                    if (jsonScript.so.isLevel2x9Available)
                    {
                        
                        lookDirrection = (L2x9.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-12":
                    if (jsonScript.so.isLevel2x11Available)
                    {
                        
                        lookDirrection = (L2x11.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-1":
                    if (jsonScript.so.isLevel2x12Available)
                    {
                        
                        lookDirrection = (L2x12.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-2":
                    if (jsonScript.so.isLevel3x1Available)
                    {
                        
                        lookDirrection = (L3x1.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-3":
                    if (jsonScript.so.isLevel3x2Available)
                    {
                        
                        lookDirrection = (L3x2.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-4":
                    if (jsonScript.so.isLevel3x3Available)
                    {
                        
                        lookDirrection = (L3x3.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-5":
                    if (jsonScript.so.isLevel3x3Available)
                    {
                        
                        lookDirrection = (L3x3.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-6":
                    if (jsonScript.so.isLevel3x4Available)
                    {
                        
                        lookDirrection = (L3x4.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-7":
                    if (jsonScript.so.isLevel3x4Available)
                    {
                        
                        lookDirrection = (L3x4.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-8":
                    if (jsonScript.so.isLevel3x5Available)
                    {
                        
                        lookDirrection = (L3x5.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-9":
                    if (jsonScript.so.isLevel3x7Available)
                    {
                        
                        lookDirrection = (L3x7.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-10":
                    if (jsonScript.so.isLevel3x9Available)
                    {
                        
                        lookDirrection = (L3x9.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-11":
                    if (jsonScript.so.isLevel3x9Available)
                    {
                        
                        lookDirrection = (L3x9.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-12":
                    if (jsonScript.so.isLevel3x9Available)
                    {
                        
                        lookDirrection = (L3x9.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-13":
                    if (jsonScript.so.isLevel3x9Available)
                    {
                        
                        lookDirrection = (L3x9.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-14":
                    if (jsonScript.so.isLevel3x11Available)
                    {
                        
                        lookDirrection = (L3x11.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-15":
                    if (jsonScript.so.isLevel3x12Available)
                    {
                        
                        lookDirrection = (L3x12.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-16":
                    if (jsonScript.so.isLevel3x14Available)
                    {
                        
                        lookDirrection = (L3x14.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-1":
                    if (jsonScript.so.isLevel3x16Available)
                    {
                        
                        lookDirrection = (L3x16.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-2":
                    if (jsonScript.so.isLevel4x1Available)
                    {
                        
                        lookDirrection = (L4x1.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-3":
                    if (jsonScript.so.isLevel4x2Available)
                    {
                        
                        lookDirrection = (L4x2.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-4":
                    if (jsonScript.so.isLevel4x3Available)
                    {
                        
                        lookDirrection = (L4x3.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-5":
                    if (jsonScript.so.isLevel4x3Available)
                    {
                        
                        lookDirrection = (L4x3.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-6":
                    if (jsonScript.so.isLevel4x4Available)
                    {
                        
                        lookDirrection = (L4x4.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-7":
                    if (jsonScript.so.isLevel4x5Available)
                    {
                        
                        lookDirrection = (L4x5.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-8":
                    if (jsonScript.so.isLevel4x7Available)
                    {
                        
                        lookDirrection = (L4x7.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-9":
                    if (jsonScript.so.isLevel4x8Available)
                    {
                        
                        lookDirrection = (L4x8.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-10":
                    if (jsonScript.so.isLevel4x9Available)
                    {
                        
                        lookDirrection = (L4x9.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-11":
                    if (jsonScript.so.isLevel4x10Available)
                    {
                        
                        lookDirrection = (L4x10.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-12":
                    if (jsonScript.so.isLevel4x10Available)
                    {
                        
                        lookDirrection = (L4x10.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-13":
                    if (jsonScript.so.isLevel4x10Available)
                    {
                        
                        lookDirrection = (L4x10.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-14":
                    if (jsonScript.so.isLevel4x12Available)
                    {
                        
                        lookDirrection = (L4x12.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L5-1":
                    if (jsonScript.so.isLevel4x14Available)
                    {
                        
                        lookDirrection = (L4x14.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L5-2":
                    if (jsonScript.so.isLevel5x1Available)
                    {
                        
                        lookDirrection = (L5x1.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L5-3":
                    if (jsonScript.so.isLevel5x1Available)
                    {
                        
                        lookDirrection = (L5x1.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L5-4":
                    if (jsonScript.so.isLevel5x3Available)
                    {
                        
                        lookDirrection = (L5x3.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L5-5":
                    if (jsonScript.so.isLevel5x4Available)
                    {
                        
                        lookDirrection = (L5x4.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L5-6":
                    if (jsonScript.so.isLevel5x4Available)
                    {
                        
                        lookDirrection = (L5x4.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L5-7":
                    if (jsonScript.so.isLevel5x5Available)
                    {
                        
                        lookDirrection = (L5x5.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L5-8":
                    if (jsonScript.so.isLevel5x7Available)
                    {
                        
                        lookDirrection = (L5x7.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L5-9":
                    if (jsonScript.so.isLevel5x8Available)
                    {
                        
                        lookDirrection = (L5x8.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L5-10":
                    if (jsonScript.so.isLevel5x9Available)
                    {
                        
                        lookDirrection = (L5x9.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
            }
        }
    }
    #endregion
    #region Go Left Code
    public void GoLeft()
    {
        if (!inputLock)
        {
            inputSwitch = 0;
            rotationDir = 3;
            switch (jsonScript.so.levelNumber)
            {
                case "L1-4":
                    if (jsonScript.so.isLevel1x3Available)
                    {
                        lookDirrection = (L1x3.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-3":
                    if (jsonScript.so.isLevel2x2Available)
                    {
                        lookDirrection = (L2x2.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-6":
                    if (jsonScript.so.isLevel2x5Available)
                    {
                        lookDirrection = (L2x5.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-7":
                    if (jsonScript.so.isLevel2x6Available)
                    {
                        lookDirrection = (L2x6.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-8":
                    if (jsonScript.so.isLevel2x7Available)
                    {
                        lookDirrection = (L2x7.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-11":
                    if (jsonScript.so.isLevel2x10Available)
                    {
                        lookDirrection = (L2x10.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-5":
                    if (jsonScript.so.isLevel3x4Available)
                    {
                        lookDirrection = (L3x4.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-7":
                    if (jsonScript.so.isLevel3x6Available)
                    {
                        lookDirrection = (L3x6.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-8":
                    if (jsonScript.so.isLevel3x7Available)
                    {
                        lookDirrection = (L3x7.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-11":
                    if (jsonScript.so.isLevel3x10Available)
                    {
                        lookDirrection = (L3x10.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-12":
                    if (jsonScript.so.isLevel3x11Available)
                    {
                        lookDirrection = (L3x11.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-13":
                    if (jsonScript.so.isLevel3x12Available)
                    {
                        lookDirrection = (L3x12.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-15":
                    if (jsonScript.so.isLevel3x14Available)
                    {
                        lookDirrection = (L3x14.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-5":
                    if (jsonScript.so.isLevel4x4Available)
                    {
                        lookDirrection = (L4x4.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-7":
                    if (jsonScript.so.isLevel4x6Available)
                    {
                        lookDirrection = (L4x6.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-12":
                    if (jsonScript.so.isLevel4x11Available)
                    {
                        lookDirrection = (L4x11.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-13":
                    if (jsonScript.so.isLevel4x12Available)
                    {
                        lookDirrection = (L4x12.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L5-3":
                    if (jsonScript.so.isLevel5x2Available)
                    {
                        lookDirrection = (L5x2.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L5-6":
                    if (jsonScript.so.isLevel5x5Available)
                    {
                        lookDirrection = (L5x5.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
            }
        }
    }
    #endregion
    #region Go Right Code
    public void GoRight()
    {
        if (!inputLock)
        {
            inputSwitch = 0;
            rotationDir = 4;
            switch (jsonScript.so.levelNumber)
            {
                case "L1-3":
                    if (jsonScript.so.isLevel1x4Available)
                    {
                        lookDirrection = (L1x4.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-2":
                    if (jsonScript.so.isLevel2x3Available)
                    {
                        lookDirrection = (L2x3.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-5":
                    if (jsonScript.so.isLevel2x6Available)
                    {
                        lookDirrection = (L2x6.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-6":
                    if (jsonScript.so.isLevel2x7Available)
                    {
                        lookDirrection = (L2x7.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-7":
                    if (jsonScript.so.isLevel2x8Available)
                    {
                        lookDirrection = (L2x8.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L2-10":
                    if (jsonScript.so.isLevel2x11Available)
                    {
                        lookDirrection = (L2x11.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-4":
                    if (jsonScript.so.isLevel3x5Available)
                    {
                        lookDirrection = (L3x5.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-6":
                    if (jsonScript.so.isLevel3x7Available)
                    {
                        lookDirrection = (L3x7.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-7":
                    if (jsonScript.so.isLevel3x8Available)
                    {
                        lookDirrection = (L3x8.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-10":
                    if (jsonScript.so.isLevel3x11Available)
                    {
                        lookDirrection = (L3x11.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-11":
                    if (jsonScript.so.isLevel3x12Available)
                    {
                        lookDirrection = (L3x12.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-12":
                    if (jsonScript.so.isLevel3x13Available)
                    {
                        lookDirrection = (L3x13.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L3-14":
                    if (jsonScript.so.isLevel3x15Available)
                    {
                        lookDirrection = (L3x15.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-4":
                    if (jsonScript.so.isLevel4x5Available)
                    {
                        lookDirrection = (L4x5.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-6":
                    if (jsonScript.so.isLevel4x7Available)
                    {
                        lookDirrection = (L4x7.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-11":
                    if (jsonScript.so.isLevel4x12Available)
                    {
                        lookDirrection = (L4x12.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L4-12":
                    if (jsonScript.so.isLevel4x13Available)
                    {
                        lookDirrection = (L4x13.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L5-2":
                    if (jsonScript.so.isLevel5x3Available)
                    {
                        lookDirrection = (L5x3.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
                case "L5-5":
                    if (jsonScript.so.isLevel5x6Available)
                    {
                        lookDirrection = (L5x6.transform.position - transform.position).normalized;
                        moveSwitch = true;
                        inputLock = true;
                        soundScript.PlayDash();
                    }
                    break;
            }
        }
    }
    #endregion

    IEnumerator MoveCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        inputLock = false;
    }
    #region Read Level Number
    private void OnTriggerEnter(Collider other)
    {
        inputSwitch = 2;
        StopAllCoroutines();
        inputCoroutineTimer = 0;
        moveSwitch = false;
        StartCoroutine(MoveCoroutine());
        if (other.gameObject == L0)
        {
            jsonScript.so.levelNumber = "L0";
        }
        if (other.gameObject == L1x1)
        {
            jsonScript.so.levelNumber = "L1-1";
            if (jsonScript.so.mapMenuScreenLocation == 1)
            {
                DragScreenDown();
                jsonScript.so.mapMenuScreenLocation = 0;
            }
        }
        if (other.gameObject == L1x2)
        {
            jsonScript.so.levelNumber = "L1-2";
            if (jsonScript.so.mapMenuScreenLocation == 0)
            {
                DragScreenUp();
                jsonScript.so.mapMenuScreenLocation = 1;
            }
        }
        if (other.gameObject == L1x3)
        {
            jsonScript.so.levelNumber = "L1-3";
        }
        if (other.gameObject == L1x4)
        {
            jsonScript.so.levelNumber = "L1-4";
        }
        if (other.gameObject == L1x5)
        {
            jsonScript.so.levelNumber = "L1-5";
            if (jsonScript.so.mapMenuScreenLocation == 2)
            {
                DragScreenDown();
                jsonScript.so.mapMenuScreenLocation = 1;
            }
        }
        if (other.gameObject == L1x6)
        {
            jsonScript.so.levelNumber = "L1-6";
            if (jsonScript.so.mapMenuScreenLocation == 1)
            {
                DragScreenUp();
                jsonScript.so.mapMenuScreenLocation = 2;
            }
        }
        if (other.gameObject == L2x1)
        {
            jsonScript.so.levelNumber = "L2-1";
        }
        if (other.gameObject == L2x2)
        {
            jsonScript.so.levelNumber = "L2-2";
            if (jsonScript.so.mapMenuScreenLocation == 3)
            {
                DragScreenDown();
                jsonScript.so.mapMenuScreenLocation = 2;
            }
        }
        if (other.gameObject == L2x3)
        {
            jsonScript.so.levelNumber = "L2-3";
            if (jsonScript.so.mapMenuScreenLocation == 3)
            {
                DragScreenDown();
                jsonScript.so.mapMenuScreenLocation = 2;
            }
        }
        if (other.gameObject == L2x4)
        {
            jsonScript.so.levelNumber = "L2-4";
            if (jsonScript.so.mapMenuScreenLocation == 2)
            {
                DragScreenUp();
                jsonScript.so.mapMenuScreenLocation = 3;
            }
        }
        if (other.gameObject == L2x5)
        {
            jsonScript.so.levelNumber = "L2-5";
        }
        if (other.gameObject == L2x6)
        {
            jsonScript.so.levelNumber = "L2-6";
            if (jsonScript.so.mapMenuScreenLocation == 4)
            {
                DragScreenDown();
                jsonScript.so.mapMenuScreenLocation = 3;
            }
        }
        if (other.gameObject == L2x7)
        {
            jsonScript.so.levelNumber = "L2-7";
            if (jsonScript.so.mapMenuScreenLocation == 4)
            {
                DragScreenDown();
                jsonScript.so.mapMenuScreenLocation = 3;
            }
        }
        if (other.gameObject == L2x8)
        {
            jsonScript.so.levelNumber = "L2-8";
        }
        if (other.gameObject == L2x9)
        {
            jsonScript.so.levelNumber = "L2-9";
            if (jsonScript.so.mapMenuScreenLocation == 3)
            {
                DragScreenUp();
                jsonScript.so.mapMenuScreenLocation = 4;
            }
        }
        if (other.gameObject == L2x10)
        {
            jsonScript.so.levelNumber = "L2-10";
            if (jsonScript.so.mapMenuScreenLocation == 5)
            {
                DragScreenDown();
                jsonScript.so.mapMenuScreenLocation = 4;
            }
        }
        if (other.gameObject == L2x11)
        {
            jsonScript.so.levelNumber = "L2-11";
            if (jsonScript.so.mapMenuScreenLocation == 5)
            {
                DragScreenDown();
                jsonScript.so.mapMenuScreenLocation = 4;
            }
        }
        if (other.gameObject == L2x12)
        {
            jsonScript.so.levelNumber = "L2-12";
            if (jsonScript.so.mapMenuScreenLocation == 4)
            {
                DragScreenUp();
                jsonScript.so.mapMenuScreenLocation = 5;
            }
        }
        if (other.gameObject == L3x1)
        {
            jsonScript.so.levelNumber = "L3-1";
        }
        if (other.gameObject == L3x2)
        {
            jsonScript.so.levelNumber = "L3-2";
            if (jsonScript.so.mapMenuScreenLocation == 6)
            {
                DragScreenDown();
                jsonScript.so.mapMenuScreenLocation = 5;
            }
        }
        if (other.gameObject == L3x3)
        {
            jsonScript.so.levelNumber = "L3-3";
            if (jsonScript.so.mapMenuScreenLocation == 5)
            {
                DragScreenUp();
                jsonScript.so.mapMenuScreenLocation = 6;
            }
        }
        if (other.gameObject == L3x4)
        {
            jsonScript.so.levelNumber = "L3-4";
        }
        if (other.gameObject == L3x5)
        {
            jsonScript.so.levelNumber = "L3-5";
        }
        if (other.gameObject == L3x6)
        {
            jsonScript.so.levelNumber = "L3-6";
        }
        if (other.gameObject == L3x7)
        {
            jsonScript.so.levelNumber = "L3-7";
            if (jsonScript.so.mapMenuScreenLocation == 7)
            {
                DragScreenDown();
                jsonScript.so.mapMenuScreenLocation = 6;
            }
        }
        if (other.gameObject == L3x8)
        {
            jsonScript.so.levelNumber = "L3-8";
        }
        if (other.gameObject == L3x9)
        {
            jsonScript.so.levelNumber = "L3-9";
            if (jsonScript.so.mapMenuScreenLocation == 6)
            {
                DragScreenUp();
                jsonScript.so.mapMenuScreenLocation = 7;
            }
        }
        if (other.gameObject == L3x10)
        {
            jsonScript.so.levelNumber = "L3-10";
        }
        if (other.gameObject == L3x11)
        {
            jsonScript.so.levelNumber = "L3-11";
            if (jsonScript.so.mapMenuScreenLocation == 8)
            {
                DragScreenDown();
                jsonScript.so.mapMenuScreenLocation = 7;
            }
        }
        if (other.gameObject == L3x12)
        {
            jsonScript.so.levelNumber = "L3-12";
            if (jsonScript.so.mapMenuScreenLocation == 8)
            {
                DragScreenDown();
                jsonScript.so.mapMenuScreenLocation = 7;
            }
        }
        if (other.gameObject == L3x13)
        {
            jsonScript.so.levelNumber = "L3-13";
        }
        if (other.gameObject == L3x14)
        {
            jsonScript.so.levelNumber = "L3-14";
            if (jsonScript.so.mapMenuScreenLocation == 7)
            {
                DragScreenUp();
                jsonScript.so.mapMenuScreenLocation = 8;
            }
        }
        if (other.gameObject == L3x15)
        {
            jsonScript.so.levelNumber = "L3-15";
            if (jsonScript.so.mapMenuScreenLocation == 7)
            {
                DragScreenUp();
                jsonScript.so.mapMenuScreenLocation = 8;
            }
        }
        if (other.gameObject == L3x16)
        {
            jsonScript.so.levelNumber = "L3-16";
            if (jsonScript.so.mapMenuScreenLocation == 9)
            {
                DragScreenDown();
                jsonScript.so.mapMenuScreenLocation = 8;
            }
        }
        if (other.gameObject == L4x1)
        {
            jsonScript.so.levelNumber = "L4-1";
            if (jsonScript.so.mapMenuScreenLocation == 8)
            {
                DragScreenUp();
                jsonScript.so.mapMenuScreenLocation = 9;
            }
        }
        if (other.gameObject == L4x2)
        {
            jsonScript.so.levelNumber = "L4-2";
            if (jsonScript.so.mapMenuScreenLocation == 10)
            {
                DragScreenDown();
                jsonScript.so.mapMenuScreenLocation = 9;
            }
        }
        if (other.gameObject == L4x3)
        {
            jsonScript.so.levelNumber = "L4-3";
            if (jsonScript.so.mapMenuScreenLocation == 9)
            {
                DragScreenUp();
                jsonScript.so.mapMenuScreenLocation = 10;
            }
        }
        if (other.gameObject == L4x4)
        {
            jsonScript.so.levelNumber = "L4-4";
        }
        if (other.gameObject == L4x5)
        {
            jsonScript.so.levelNumber = "L4-5";
        }
        if (other.gameObject == L4x6)
        {
            jsonScript.so.levelNumber = "L4-6";
            if (jsonScript.so.mapMenuScreenLocation == 11)
            {
                DragScreenDown();
                jsonScript.so.mapMenuScreenLocation = 10;
            }
        }
        if (other.gameObject == L4x7)
        {
            jsonScript.so.levelNumber = "L4-7";
            if (jsonScript.so.mapMenuScreenLocation == 11)
            {
                DragScreenDown();
                jsonScript.so.mapMenuScreenLocation = 10;
            }
        }
        if (other.gameObject == L4x8)
        {
            jsonScript.so.levelNumber = "L4-8";
            if (jsonScript.so.mapMenuScreenLocation == 10)
            {
                DragScreenUp();
                jsonScript.so.mapMenuScreenLocation = 11;
            }
        }
        if (other.gameObject == L4x9)
        {
            jsonScript.so.levelNumber = "L4-9";
        }
        if (other.gameObject == L4x10)
        {
            jsonScript.so.levelNumber = "L4-10";
            if (jsonScript.so.mapMenuScreenLocation == 12)
            {
                DragScreenDown();
                jsonScript.so.mapMenuScreenLocation = 11;
            }
        }
        if (other.gameObject == L4x11)
        {
            jsonScript.so.levelNumber = "L4-11";
        }
        if (other.gameObject == L4x12)
        {
            jsonScript.so.levelNumber = "L4-12";
            if (jsonScript.so.mapMenuScreenLocation == 11)
            {
                DragScreenUp();
                jsonScript.so.mapMenuScreenLocation = 12;
            }
        }
        if (other.gameObject == L4x13)
        {
            jsonScript.so.levelNumber = "L4-13";
        }
        if (other.gameObject == L4x14)
        {
            jsonScript.so.levelNumber = "L4-14";
            if (jsonScript.so.mapMenuScreenLocation == 13)
            {
                DragScreenDown();
                jsonScript.so.mapMenuScreenLocation = 12;
            }
        }
        if (other.gameObject == L5x1)
        {
            jsonScript.so.levelNumber = "L5-1";
            if (jsonScript.so.mapMenuScreenLocation == 12)
            {
                DragScreenUp();
                jsonScript.so.mapMenuScreenLocation = 13;
            }
        }
        if (other.gameObject == L5x2)
        {
            jsonScript.so.levelNumber = "L5-2";
        }
        if (other.gameObject == L5x3)
        {
            jsonScript.so.levelNumber = "L5-3";
        }
        if (other.gameObject == L5x4)
        {
            jsonScript.so.levelNumber = "L5-4";
            if (jsonScript.so.mapMenuScreenLocation == 14)
            {
                DragScreenDown();
                jsonScript.so.mapMenuScreenLocation = 13;
            }
        }
        if (other.gameObject == L5x5)
        {
            jsonScript.so.levelNumber = "L5-5";
            if (jsonScript.so.mapMenuScreenLocation == 13)
            {
                DragScreenUp();
                jsonScript.so.mapMenuScreenLocation = 14;
            }
        }
        if (other.gameObject == L5x6)
        {
            jsonScript.so.levelNumber = "L5-6";
            if (jsonScript.so.mapMenuScreenLocation == 13)
            {
                DragScreenUp();
                jsonScript.so.mapMenuScreenLocation = 14;
            }
        }
        if (other.gameObject == L5x7)
        {
            jsonScript.so.levelNumber = "L5-7";
            if (jsonScript.so.mapMenuScreenLocation == 15)
            {
                DragScreenDown();
                jsonScript.so.mapMenuScreenLocation = 14;
            }
        }
        if (other.gameObject == L5x8)
        {
            jsonScript.so.levelNumber = "L5-8";
            if (jsonScript.so.mapMenuScreenLocation == 14)
            {
                DragScreenUp();
                jsonScript.so.mapMenuScreenLocation = 15;
            }
        }
        if (other.gameObject == L5x9)
        {
            jsonScript.so.levelNumber = "L5-9";
        }
        if (other.gameObject == L5x10)
        {
            jsonScript.so.levelNumber = "L5-10";
        }
    }
    #endregion

    private void OnTriggerExit2D(Collider2D other)
    {
        //   levelNumber = "";
        //  jsonScript.so.levelNumber = "";
    }
    #region Load Level
    public void StartLevel()
    {
        if (!moveSwitch)
        {
            soundScript.PlayModeSelect();
            StartCoroutine(LoadLevel());
        }
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(0.5f);
        jsonScript.so.dontRestartMusic = false;
        switch (jsonScript.so.levelNumber)
        {
            case "L0":
                SceneManager.LoadScene("ArLV0");
                break;
            case "L1-1":
                SceneManager.LoadScene("ArLV1-1");
                break;
            case "L1-2":
                SceneManager.LoadScene("ArLV1-2");
                break;
            case "L1-3":
                SceneManager.LoadScene("ArLV1-3");
                break;
            case "L1-4":
                SceneManager.LoadScene("ArLV1-4");
                break;
            case "L1-5":
                SceneManager.LoadScene("ArLV1-5");
                break;
            case "L1-6":
                SceneManager.LoadScene("ArLV1-6");
                break;
            case "L2-1":
                SceneManager.LoadScene("ArLV2-1");
                break;
            case "L2-2":
                SceneManager.LoadScene("ArLV2-2");
                break;
            case "L2-3":
                SceneManager.LoadScene("ArLV2-3");
                break;
            case "L2-4":
                SceneManager.LoadScene("ArLV2-4");
                break;
            case "L2-5":
                SceneManager.LoadScene("ArLV2-5");
                break;
            case "L2-6":
                SceneManager.LoadScene("ArLV2-6");
                break;
            case "L2-7":
                SceneManager.LoadScene("ArLV2-7");
                break;
            case "L2-8":
                SceneManager.LoadScene("ArLV2-8");
                break;
            case "L2-9":
                SceneManager.LoadScene("ArLV2-9");
                break;
            case "L2-10":
                SceneManager.LoadScene("ArLV2-10");
                break;
            case "L2-11":
                SceneManager.LoadScene("ArLV2-11");
                break;
            case "L2-12":
                SceneManager.LoadScene("ArLV2-12");
                break;
            case "L3-1":
                SceneManager.LoadScene("ArLV3-1");
                break;
            case "L3-2":
                SceneManager.LoadScene("ArLV3-2");
                break;
            case "L3-3":
                SceneManager.LoadScene("ArLV3-3");
                break;
            case "L3-4":
                SceneManager.LoadScene("ArLV3-4");
                break;
            case "L3-5":
                SceneManager.LoadScene("ArLV3-5");
                break;
            case "L3-6":
                SceneManager.LoadScene("ArLV3-6");
                break;
            case "L3-7":
                SceneManager.LoadScene("ArLV3-7");
                break;
            case "L3-8":
                SceneManager.LoadScene("ArLV3-8");
                break;
            case "L3-9":
                SceneManager.LoadScene("ArLV3-9");
                break;
            case "L3-10":
                SceneManager.LoadScene("ArLV3-10");
                break;
            case "L3-11":
                SceneManager.LoadScene("ArLV3-11");
                break;
            case "L3-12":
                SceneManager.LoadScene("ArLV3-12");
                break;
            case "L3-13":
                SceneManager.LoadScene("ArLV3-13");
                break;
            case "L3-14":
                SceneManager.LoadScene("ArLV3-14");
                break;
            case "L3-15":
                SceneManager.LoadScene("ArLV3-15");
                break;
            case "L3-16":
                SceneManager.LoadScene("ArLV3-16");
                break;
            case "L4-1":
                SceneManager.LoadScene("ArLV4-1");
                break;
            case "L4-2":
                SceneManager.LoadScene("ArLV4-2");
                break;
            case "L4-3":
                SceneManager.LoadScene("ArLV4-3");
                break;
            case "L4-4":
                SceneManager.LoadScene("ArLV4-4");
                break;
            case "L4-5":
                SceneManager.LoadScene("ArLV4-5");
                break;
            case "L4-6":
                SceneManager.LoadScene("ArLV4-6");
                break;
            case "L4-7":
                SceneManager.LoadScene("ArLV4-7");
                break;
            case "L4-8":
                SceneManager.LoadScene("ArLV4-8");
                break;
            case "L4-9":
                SceneManager.LoadScene("ArLV4-9");
                break;
            case "L4-10":
                SceneManager.LoadScene("ArLV4-10");
                break;
            case "L4-11":
                SceneManager.LoadScene("ArLV4-11");
                break;
            case "L4-12":
                SceneManager.LoadScene("ArLV4-12");
                break;
            case "L4-13":
                SceneManager.LoadScene("ArLV4-13");
                break;
            case "L4-14":
                SceneManager.LoadScene("ArLV4-14");
                break;
            case "L5-1":
                SceneManager.LoadScene("ArLV5-1");
                break;
            case "L5-2":
                SceneManager.LoadScene("ArLV5-2");
                break;
            case "L5-3":
                SceneManager.LoadScene("ArLV5-3");
                break;
            case "L5-4":
                SceneManager.LoadScene("ArLV5-4");
                break;
            case "L5-5":
                SceneManager.LoadScene("ArLV5-5");
                break;
            case "L5-6":
                SceneManager.LoadScene("ArLV5-6");
                break;
            case "L5-7":
                SceneManager.LoadScene("ArLV5-7");
                break;
            case "L5-8":
                SceneManager.LoadScene("ArLV5-8");
                break;
            case "L5-9":
                SceneManager.LoadScene("ArLV5-9");
                break;
            case "L5-10":
                SceneManager.LoadScene("ArLV5-10");
                break;
        }
    }
    #endregion

    public void DragScreenUp()
    {
        Levels.transform.position = new Vector3(Levels.transform.position.x, Levels.transform.position.y - dragDistance, Levels.transform.position.z);
        transform.position = new Vector3(transform.position.x, transform.position.y - dragDistance, transform.position.z);
    }
    public void DragScreenDown()
    {
        Levels.transform.position = new Vector3(Levels.transform.position.x, Levels.transform.position.y + dragDistance, Levels.transform.position.z);
        transform.position = new Vector3(transform.position.x, transform.position.y + dragDistance, transform.position.z);
    }

    public void ReturnToTitleScreen()
    {
        jsonScript.so.dontRestartMusic = false;
        SceneManager.LoadScene("Title Screen");
    }

    public void ChangeSkin()
    {
        soundScript.PlayChangeCategory();
        StartCoroutine(LoadSkin());
    }

    IEnumerator LoadSkin()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Skin Select Menu");
    }
    #region Resume Level
    public void ContinueFromLastLevel()
    {
        switch (jsonScript.so.mapMenuScreenLocation)
        {
            case 0:
                Levels.transform.position = new Vector3(0, -100 + 89.307f, 100);
                break;
            case 1:
                Levels.transform.position = new Vector3(0, (-100 - 55.5f * 1) + 89.307f, 100);
                break;
            case 2:
                Levels.transform.position = new Vector3(0, (-100 - 55.5f * 2) + 89.307f, 100);
                break;
            case 3:
                Levels.transform.position = new Vector3(0, (-100 - 55.5f * 3) + 89.307f, 100);
                break;
            case 4:
                Levels.transform.position = new Vector3(0, (-100 - 55.5f * 4) + 89.307f, 100);
                break;
            case 5:
                Levels.transform.position = new Vector3(0, (-100 - 55.5f * 5) + 89.307f, 100);
                break;
            case 6:
                Levels.transform.position = new Vector3(0, (-100 - 55.5f * 6) + 89.307f, 100);
                break;
            case 7:
                Levels.transform.position = new Vector3(0, (-100 - 55.5f * 7) + 89.307f, 100);
                break;
            case 8:
                Levels.transform.position = new Vector3(0, (-100 - 55.5f * 8) + 89.307f, 100);
                break;
            case 9:
                Levels.transform.position = new Vector3(0, (-100 - 55.5f * 9) + 89.307f, 100);
                break;
            case 10:
                Levels.transform.position = new Vector3(0, (-100 - 55.5f * 10) + 89.307f, 100);
                break;
            case 11:
                Levels.transform.position = new Vector3(0, (-100 - 55.5f * 11) + 89.307f, 100);
                break;
            case 12:
                Levels.transform.position = new Vector3(0, (-100 - 55.5f * 12) + 89.307f, 100);
                break;
            case 13:
                Levels.transform.position = new Vector3(0, (-100 - 55.5f * 13) + 89.307f, 100);
                break;
            case 14:
                Levels.transform.position = new Vector3(0, (-100 - 55.5f * 14) + 89.307f, 100);
                break;
            case 15:
                Levels.transform.position = new Vector3(0, (-100 - 55.5f * 15) + 89.307f, 100);
                break;
        }
        TeleportToLevel();
    }
    #endregion

    public void TeleportToLevel()
    {
        switch (jsonScript.so.levelOnMap)
        {
            case "0":
                transform.position = L0.transform.position;
                break;
            case "L1-1":
                transform.position = L1x1.transform.position;
                break;
            case "L1-2":
                transform.position = L1x2.transform.position;
                break;
            case "L1-3":
                transform.position = L1x3.transform.position;
                break;
            case "L1-4":
                transform.position = L1x4.transform.position;
                break;
            case "L1-5":
                transform.position = L1x5.transform.position;
                break;
            case "L1-6":
                transform.position = L1x6.transform.position;
                break;
            case "L2-1":
                transform.position = L2x1.transform.position;
                break;
            case "L2-2":
                transform.position = L2x2.transform.position;
                break;
            case "L2-3":
                transform.position = L2x3.transform.position;
                break;
            case "L2-4":
                transform.position = L2x4.transform.position;
                break;
            case "L2-5":
                transform.position = L2x5.transform.position;
                break;
            case "L2-6":
                transform.position = L2x6.transform.position;
                break;
            case "L2-7":
                transform.position = L2x7.transform.position;
                break;
            case "L2-8":
                transform.position = L2x8.transform.position;
                break;
            case "L2-9":
                transform.position = L2x9.transform.position;
                break;
            case "L2-10":
                transform.position = L2x10.transform.position;
                break;
            case "L2-11":
                transform.position = L2x11.transform.position;
                break;
            case "L2-12":
                transform.position = L2x12.transform.position;
                break;
            case "L3-1":
                transform.position = L3x1.transform.position;
                break;
            case "L3-2":
                transform.position = L3x2.transform.position;
                break;
            case "L3-3":
                transform.position = L3x3.transform.position;
                break;
            case "L3-4":
                transform.position = L3x4.transform.position;
                break;
            case "L3-5":
                transform.position = L3x5.transform.position;
                break;
            case "L3-6":
                transform.position = L3x6.transform.position;
                break;
            case "L3-7":
                transform.position = L3x7.transform.position;
                break;
            case "L3-8":
                transform.position = L3x8.transform.position;
                break;
            case "L3-9":
                transform.position = L3x9.transform.position;
                break;
            case "L3-10":
                transform.position = L3x10.transform.position;
                break;
            case "L3-11":
                transform.position = L3x11.transform.position;
                break;
            case "L3-12":
                transform.position = L3x12.transform.position;
                break;
            case "L3-13":
                transform.position = L3x13.transform.position;
                break;
            case "L3-14":
                transform.position = L3x14.transform.position;
                break;
            case "L3-15":
                transform.position = L3x15.transform.position;
                break;
            case "L3-16":
                transform.position = L3x16.transform.position;
                break;
            case "L4-1":
                transform.position = L4x1.transform.position;
                break;
            case "L4-2":
                transform.position = L4x2.transform.position;
                break;
            case "L4-3":
                transform.position = L4x3.transform.position;
                break;
            case "L4-4":
                transform.position = L4x4.transform.position;
                break;
            case "L4-5":
                transform.position = L4x5.transform.position;
                break;
            case "L4-6":
                transform.position = L4x6.transform.position;
                break;
            case "L4-7":
                transform.position = L4x7.transform.position;
                break;
            case "L4-8":
                transform.position = L4x8.transform.position;
                break;
            case "L4-9":
                transform.position = L4x9.transform.position;
                break;
            case "L4-10":
                transform.position = L4x10.transform.position;
                break;
            case "L4-11":
                transform.position = L4x11.transform.position;
                break;
            case "L4-12":
                transform.position = L4x12.transform.position;
                break;
            case "L4-13":
                transform.position = L4x13.transform.position;
                break;
            case "L4-14":
                transform.position = L4x14.transform.position;
                break;
            case "L5-1":
                transform.position = L5x1.transform.position;
                break;
            case "L5-2":
                transform.position = L5x2.transform.position;
                break;
            case "L5-3":
                transform.position = L5x3.transform.position;
                break;
            case "L5-4":
                transform.position = L5x4.transform.position;
                break;
            case "L5-5":
                transform.position = L5x5.transform.position;
                break;
            case "L5-6":
                transform.position = L5x6.transform.position;
                break;
            case "L5-7":
                transform.position = L5x7.transform.position;
                break;
            case "L5-8":
                transform.position = L5x8.transform.position;
                break;
            case "L5-9":
                transform.position = L5x9.transform.position;
                break;
            case "L5-10":
                transform.position = L5x10.transform.position;
                break;
        }
    }

    public IEnumerator InputTimerRoutine()
    {
        inputCoroutineTimer = 0;
        while (inputCoroutineTimer < 80)
        {
            yield return new WaitForSeconds(0.01f);
            inputCoroutineTimer++;
        }
        TeleportToLevel();
        moveSwitch = false;
        inputSwitch = 0;
    }

    #region Enable Levels
    public void UnlockLevels()
    {
        if (jsonScript.so.isLevel1x1Available)
        {
            L1x1.SetActive(true);
        }
        if (jsonScript.so.isLevel1x2Available)
        {
            L1x2.SetActive(true);
        }
        if (jsonScript.so.isLevel1x3Available)
        {
            L1x3.SetActive(true);
        }
        if (jsonScript.so.isLevel1x4Available)
        {
            L1x4.SetActive(true);
        }
        if (jsonScript.so.isLevel1x5Available)
        {
            L1x5.SetActive(true);
        }
        if (jsonScript.so.isLevel1x6Available)
        {
            L1x6.SetActive(true);
        }
        if (jsonScript.so.isLevel2x1Available)
        {
            L2x1.SetActive(true);
        }
        if (jsonScript.so.isLevel2x2Available)
        {
            L2x2.SetActive(true);
        }
        if (jsonScript.so.isLevel2x3Available)
        {
            L2x3.SetActive(true);
        }
        if (jsonScript.so.isLevel2x4Available)
        {
            L2x4.SetActive(true);
        }
        if (jsonScript.so.isLevel2x5Available)
        {
            L2x5.SetActive(true);
        }
        if (jsonScript.so.isLevel2x6Available)
        {
            L2x6.SetActive(true);
        }
        if (jsonScript.so.isLevel2x7Available)
        {
            L2x7.SetActive(true);
        }
        if (jsonScript.so.isLevel2x8Available)
        {
            L2x8.SetActive(true);
        }
        if (jsonScript.so.isLevel2x9Available)
        {
            L2x9.SetActive(true);
        }
        if (jsonScript.so.isLevel2x10Available)
        {
            L2x10.SetActive(true);
        }
        if (jsonScript.so.isLevel2x11Available)
        {
            L2x11.SetActive(true);
        }
        if (jsonScript.so.isLevel2x12Available)
        {
            L2x12.SetActive(true);
        }
        if (jsonScript.so.isLevel3x1Available)
        {
            L3x1.SetActive(true);
        }
        if (jsonScript.so.isLevel3x2Available)
        {
            L3x2.SetActive(true);
        }
        if (jsonScript.so.isLevel3x3Available)
        {
            L3x3.SetActive(true);
        }
        if (jsonScript.so.isLevel3x4Available)
        {
            L3x4.SetActive(true);
        }
        if (jsonScript.so.isLevel3x5Available)
        {
            L3x5.SetActive(true);
        }
        if (jsonScript.so.isLevel3x6Available)
        {
            L3x6.SetActive(true);
        }
        if (jsonScript.so.isLevel3x7Available)
        {
            L3x7.SetActive(true);
        }
        if (jsonScript.so.isLevel3x8Available)
        {
            L3x8.SetActive(true);
        }
        if (jsonScript.so.isLevel3x9Available)
        {
            L3x9.SetActive(true);
        }
        if (jsonScript.so.isLevel3x10Available)
        {
            L3x10.SetActive(true);
        }
        if (jsonScript.so.isLevel3x11Available)
        {
            L3x11.SetActive(true);
        }
        if (jsonScript.so.isLevel3x12Available)
        {
            L3x12.SetActive(true);
        }
        if (jsonScript.so.isLevel3x13Available)
        {
            L3x13.SetActive(true);
        }
        if (jsonScript.so.isLevel3x14Available)
        {
            L3x14.SetActive(true);
        }
        if (jsonScript.so.isLevel3x15Available)
        {
            L3x15.SetActive(true);
        }
        if (jsonScript.so.isLevel3x16Available)
        {
            L3x16.SetActive(true);
        }
        if (jsonScript.so.isLevel4x1Available)
        {
            L4x1.SetActive(true);
        }
        if (jsonScript.so.isLevel4x2Available)
        {
            L4x2.SetActive(true);
        }
        if (jsonScript.so.isLevel4x3Available)
        {
            L4x3.SetActive(true);
        }
        if (jsonScript.so.isLevel4x4Available)
        {
            L4x4.SetActive(true);
        }
        if (jsonScript.so.isLevel4x5Available)
        {
            L4x5.SetActive(true);
        }
        if (jsonScript.so.isLevel4x6Available)
        {
            L4x6.SetActive(true);
        }
        if (jsonScript.so.isLevel4x7Available)
        {
            L4x7.SetActive(true);
        }
        if (jsonScript.so.isLevel4x8Available)
        {
            L4x8.SetActive(true);
        }
        if (jsonScript.so.isLevel4x9Available)
        {
            L4x9.SetActive(true);
        }
        if (jsonScript.so.isLevel4x10Available)
        {
            L4x10.SetActive(true);
        }
        if (jsonScript.so.isLevel4x11Available)
        {
            L4x11.SetActive(true);
        }
        if (jsonScript.so.isLevel4x12Available)
        {
            L4x12.SetActive(true);
        }
        if (jsonScript.so.isLevel4x13Available)
        {
            L4x13.SetActive(true);
        }
        if (jsonScript.so.isLevel4x14Available)
        {
            L4x14.SetActive(true);
        }
        if (jsonScript.so.isLevel5x1Available)
        {
            L5x1.SetActive(true);
        }
        if (jsonScript.so.isLevel5x2Available)
        {
            L5x2.SetActive(true);
        }
        if (jsonScript.so.isLevel5x3Available)
        {
            L5x3.SetActive(true);
        }
        if (jsonScript.so.isLevel5x4Available)
        {
            L5x4.SetActive(true);
        }
        if (jsonScript.so.isLevel5x5Available)
        {
            L5x5.SetActive(true);
        }
        if (jsonScript.so.isLevel5x6Available)
        {
            L5x6.SetActive(true);
        }
        if (jsonScript.so.isLevel5x7Available)
        {
            L5x7.SetActive(true);
        }
        if (jsonScript.so.isLevel5x8Available)
        {
            L5x8.SetActive(true);
        }
        if (jsonScript.so.isLevel5x9Available)
        {
            L5x9.SetActive(true);
        }
        if (jsonScript.so.isLevel5x10Available)
        {
            L5x10.SetActive(true);
        }
    }
    #endregion
}
