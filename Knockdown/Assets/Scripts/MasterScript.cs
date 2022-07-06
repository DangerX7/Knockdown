using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterScript : MonoBehaviour
{
    public int playersTotalReg;
    public byte player1Wins;
    public byte player2Wins;
    public byte player3Wins;
    public byte player4Wins;
    public int P1skin;
    public int P2skin;
    public int P3skin;
    public int P4skin;
    public byte multiplayerMode; // it stores the mod in memory / 1=arena, 2=versus, 3=dodgeball, 4=control
    public byte playerCount;
    public int codeState;
    private SaveTest jsonScript;
    private SoundsScript soundScript;
    bool temporarCheck;
    public int sceneNumber;

    public bool isDodgeballAvailable;
    public bool isSurvivalAvailable;
    public bool isControlAvailable;
    public bool isGauntletAvailable;
    public bool isArenaAvailable;

    // Start is called before the first frame update
    void Start()
    {
        jsonScript = GetComponent<SaveTest>();
        jsonScript.Load();
        //  diamonds = 50000;
        //   levelNumber = "5-5";
        //    SceneManager.LoadScene("ArLV5-5");
        ///////////////////////////////////////////
        ///TEMPORAR VALUES///////
        jsonScript.so.levelNumber = "title";//title
        jsonScript.so.playerSkin = 1;

   //     UnlockEverything();

        // put resolution and screen mode here after you learn control and save feature
        DontDestroyOnLoad(gameObject);
        StartCoroutine(AdvanceToTitle());

        ///Use 16/1 size textures.
        jsonScript.so.textureResolution = 0;
        QualitySettings.masterTextureLimit = jsonScript.so.textureResolution;
        if (jsonScript.so.BGMvol == 0 & jsonScript.so.SFXvol == 0)
        {
            jsonScript.so.BGMvol = 1;
            jsonScript.so.SFXvol = 1;
        }
    }

    private void FixedUpdate()
    {
        //Get scene number
        sceneNumber = (SceneManager.GetActiveScene().buildIndex);
    }

    public void Update()
    {
        switch (jsonScript.so.levelNumber)
        {
            case "L0":
                jsonScript.so.levelOnMap = "0";
                break;
            case "L1-1":
                jsonScript.so.levelOnMap = "1-1";
                break;
            case "L1-2":
                jsonScript.so.levelOnMap = "1-2";
                break;
            case "L1-3":
                jsonScript.so.levelOnMap = "1-3";
                break;
            case "L1-4":
                jsonScript.so.levelOnMap = "1-4";
                break;
            case "L1-5":
                jsonScript.so.levelOnMap = "1-5";
                break;
            case "L1-6":
                jsonScript.so.levelOnMap = "1-6";
                break;
            case "L2-1":
                jsonScript.so.levelOnMap = "2-1";
                break;
            case "L2-2":
                jsonScript.so.levelOnMap = "2-2";
                break;
            case "L2-3":
                jsonScript.so.levelOnMap = "2-3";
                break;
            case "L2-4":
                jsonScript.so.levelOnMap = "2-4";
                break;
            case "L2-5":
                jsonScript.so.levelOnMap = "2-5";
                break;
            case "L2-6":
                jsonScript.so.levelOnMap = "2-6";
                break;
            case "L2-7":
                jsonScript.so.levelOnMap = "2-7";
                break;
            case "L2-8":
                jsonScript.so.levelOnMap = "2-8";
                break;
            case "L2-9":
                jsonScript.so.levelOnMap = "2-9";
                break;
            case "L2-10":
                jsonScript.so.levelOnMap = "2-10";
                break;
            case "L2-11":
                jsonScript.so.levelOnMap = "2-11";
                break;
            case "L2-12":
                jsonScript.so.levelOnMap = "2-12";
                break;
            case "L3-1":
                jsonScript.so.levelOnMap = "3-1";
                break;
            case "L3-2":
                jsonScript.so.levelOnMap = "3-2";
                break;
            case "L3-3":
                jsonScript.so.levelOnMap = "3-3";
                break;
            case "L3-4":
                jsonScript.so.levelOnMap = "3-4";
                break;
            case "L3-5":
                jsonScript.so.levelOnMap = "3-5";
                break;
            case "L3-6":
                jsonScript.so.levelOnMap = "3-6";
                break;
            case "L3-7":
                jsonScript.so.levelOnMap = "3-7";
                break;
            case "L3-8":
                jsonScript.so.levelOnMap = "3-8";
                break;
            case "L3-9":
                jsonScript.so.levelOnMap = "3-9";
                break;
            case "L3-10":
                jsonScript.so.levelOnMap = "3-10";
                break;
            case "L3-11":
                jsonScript.so.levelOnMap = "3-11";
                break;
            case "L3-12":
                jsonScript.so.levelOnMap = "3-12";
                break;
            case "L3-13":
                jsonScript.so.levelOnMap = "3-13";
                break;
            case "L3-14":
                jsonScript.so.levelOnMap = "3-14";
                break;
            case "L3-15":
                jsonScript.so.levelOnMap = "3-15";
                break;
            case "L3-16":
                jsonScript.so.levelOnMap = "3-16";
                break;
            case "L4-1":
                jsonScript.so.levelOnMap = "4-1";
                break;
            case "L4-2":
                jsonScript.so.levelOnMap = "4-2";
                break;
            case "L4-3":
                jsonScript.so.levelOnMap = "4-3";
                break;
            case "L4-4":
                jsonScript.so.levelOnMap = "4-4";
                break;
            case "L4-5":
                jsonScript.so.levelOnMap = "4-5";
                break;
            case "L4-6":
                jsonScript.so.levelOnMap = "4-6";
                break;
            case "L4-7":
                jsonScript.so.levelOnMap = "4-7";
                break;
            case "L4-8":
                jsonScript.so.levelOnMap = "4-8";
                break;
            case "L4-9":
                jsonScript.so.levelOnMap = "4-9";
                break;
            case "L4-10":
                jsonScript.so.levelOnMap = "4-10";
                break;
            case "L4-11":
                jsonScript.so.levelOnMap = "4-11";
                break;
            case "L4-12":
                jsonScript.so.levelOnMap = "4-12";
                break;
            case "L4-13":
                jsonScript.so.levelOnMap = "4-13";
                break;
            case "L4-14":
                jsonScript.so.levelOnMap = "4-14";
                break;
            case "L5-1":
                jsonScript.so.levelOnMap = "5-1";
                break;
            case "L5-2":
                jsonScript.so.levelOnMap = "5-2";
                break;
            case "L5-3":
                jsonScript.so.levelOnMap = "5-3";
                break;
            case "L5-4":
                jsonScript.so.levelOnMap = "5-4";
                break;
            case "L5-5":
                jsonScript.so.levelOnMap = "5-5";
                break;
            case "L5-6":
                jsonScript.so.levelOnMap = "5-6";
                break;
            case "L5-7":
                jsonScript.so.levelOnMap = "5-7";
                break;
            case "L5-8":
                jsonScript.so.levelOnMap = "5-8";
                break;
            case "L5-9":
                jsonScript.so.levelOnMap = "5-9";
                break;
            case "L5-10":
                jsonScript.so.levelOnMap = "5-10";
                break;
        }

        //  if (jsonScript.so.levelNumber == "title" && !temporarCheck)
        {
       /////////     StartCoroutine(TemporarUnlockTimer());
        }

        #region Set Players in Total
        switch (multiplayerMode)
        {
            case 32:
                playersTotalReg = 0;
                break;
            case 0:
            case 33:
                playersTotalReg = 1;
                break;
            case 12:
            case 22:
            case 42:
            case 34:
            case 50:
                playersTotalReg = 2;
                break;
            case 13:
            case 23:
                playersTotalReg = 3;
                break;
            case 14:
            case 24:
                playersTotalReg = 4;
                break;
        }
        #endregion

        #region Special Unlock Everything Code
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (codeState == 0)
            {
                codeState = 1;
            }
            else
            {
                codeState = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (codeState == 1)
            {
                codeState = 2;
            }
            else
            {
                codeState = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (codeState == 2)
            {
                codeState = 3;
            }
            else
            {
                codeState = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (codeState == 3)
            {
                codeState = 4;
            }
            else
            {
                codeState = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (codeState == 4)
            {
                codeState = 5;
            }
            else
            {
                codeState = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (codeState == 5)
            {
                if (jsonScript.so.levelNumber == "title")
                {
                    UnlockEverything();
                }
                codeState = 0;
            }
            else
            {
                codeState = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.H) ||
            Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L) ||
            Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Q) ||
            Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.V) ||
            Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.Z))
        {
            codeState = 0;
        }
            #endregion
    }

    IEnumerator TemporarUnlockTimer()
    {
        yield return new WaitForSeconds(1);
        UnlockEverything(); /////////REMOVE UPON RELEASE
        temporarCheck = true;
    }

    #region Advance to Title Screen (other modes are for testing)
    IEnumerator AdvanceToTitle()
    {
        yield return new WaitForSeconds(0.02f);
        switch (jsonScript.so.levelNumber)
        {
            case "title":
                SceneManager.LoadScene("Title Screen");
                break;
        }
    }
    #endregion

    public void UnlockEverything()
    {
        soundScript = GameObject.Find("Sound").GetComponent<SoundsScript>();
        soundScript.PlaySound("Yeah");
        jsonScript.so.isSkin2Available = true;
        jsonScript.so.isSkin3Available = true;
        jsonScript.so.isSkin4Available = true;
        jsonScript.so.isSkin5Available = true;
        jsonScript.so.isSkin6Available = true;
        jsonScript.so.isSkin7Available = true;
        jsonScript.so.isSkin8Available = true;
        jsonScript.so.isSkin9Available = true;
        jsonScript.so.isSkin10Available = true;
        jsonScript.so.isSkin11Available = true;
        jsonScript.so.isSkin12Available = true;
        jsonScript.so.isSkin13Available = true;
        jsonScript.so.isSkin14Available = true;
        jsonScript.so.isSkin15Available = true;
        jsonScript.so.isSkin16Available = true;
        jsonScript.so.isSkin17Available = true;
        jsonScript.so.isSkin18Available = true;
        jsonScript.so.isSkin19Available = true;
        jsonScript.so.isSkin20Available = true;
        jsonScript.so.isSkin21Available = true;
        jsonScript.so.isSkin22Available = true;
        jsonScript.so.isSkin23Available = true;
        jsonScript.so.isSkin24Available = true;
        jsonScript.so.isSkin25Available = true;
        jsonScript.so.isSkin26Available = true;
        jsonScript.so.isSkin27Available = true;
        jsonScript.so.isSkin28Available = true;
        jsonScript.so.isSkin29Available = true;
        jsonScript.so.isSkin30Available = true;
        jsonScript.so.isSkin31Available = true;
        jsonScript.so.isSkin32Available = true;
        jsonScript.so.isSkin33Available = true;
        jsonScript.so.isSkin34Available = true;
        jsonScript.so.isSkin35Available = true;
        jsonScript.so.isSkin36Available = true;
        jsonScript.so.isSkin37Available = true;
        jsonScript.so.isSkin38Available = true;
        jsonScript.so.isSkin39Available = true;
        jsonScript.so.isSkin40Available = true;
        jsonScript.so.isSkin41Available = true;
        jsonScript.so.isSkin42Available = true;
        jsonScript.so.isSkin43Available = true;
        jsonScript.so.isSkin44Available = true;
        jsonScript.so.isSkin45Available = true;
        jsonScript.so.isSkin46Available = true;
        jsonScript.so.isSkin47Available = true;
        jsonScript.so.isSkin48Available = true;
        jsonScript.so.isSkin49Available = true;
        jsonScript.so.isSkin50Available = true;
        jsonScript.so.isSkin51Available = true;
        jsonScript.so.isSkin52Available = true;
        jsonScript.so.isSkin101Available = true;
        jsonScript.so.isSkin102Available = true;
        jsonScript.so.isSkin103Available = true;
        jsonScript.so.isSkin104Available = true;
        jsonScript.so.isSkin105Available = true;
        jsonScript.so.isSkin106Available = true;
        jsonScript.so.isSkin107Available = true;
        jsonScript.so.isSkin108Available = true;
        jsonScript.so.isSkin109Available = true;
        jsonScript.so.isSkin110Available = true;
        jsonScript.so.isSkin111Available = true;
        jsonScript.so.isSkin112Available = true;
        jsonScript.so.isSkin121Available = true;
        jsonScript.so.isSkin122Available = true;
        jsonScript.so.isSkin123Available = true;
        jsonScript.so.isSkin124Available = true;
        jsonScript.so.isSkin125Available = true;
        jsonScript.so.isSkin126Available = true;
        jsonScript.so.isSkin127Available = true;
        jsonScript.so.isSkin128Available = true;
        jsonScript.so.isSkin129Available = true;
        jsonScript.so.isSkin130Available = true;

        jsonScript.so.isLevel1x1Available = true;
        jsonScript.so.isLevel1x2Available = true;
        jsonScript.so.isLevel1x3Available = true;
        jsonScript.so.isLevel1x4Available = true;
        jsonScript.so.isLevel1x5Available = true;
        jsonScript.so.isLevel1x6Available = true;
        jsonScript.so.isLevel2x1Available = true;
        jsonScript.so.isLevel2x2Available = true;
        jsonScript.so.isLevel2x3Available = true;
        jsonScript.so.isLevel2x4Available = true;
        jsonScript.so.isLevel2x5Available = true;
        jsonScript.so.isLevel2x6Available = true;
        jsonScript.so.isLevel2x7Available = true;
        jsonScript.so.isLevel2x8Available = true;
        jsonScript.so.isLevel2x9Available = true;
        jsonScript.so.isLevel2x10Available = true;
        jsonScript.so.isLevel2x11Available = true;
        jsonScript.so.isLevel2x12Available = true;
        jsonScript.so.isLevel3x1Available = true;
        jsonScript.so.isLevel3x2Available = true;
        jsonScript.so.isLevel3x3Available = true;
        jsonScript.so.isLevel3x4Available = true;
        jsonScript.so.isLevel3x5Available = true;
        jsonScript.so.isLevel3x6Available = true;
        jsonScript.so.isLevel3x7Available = true;
        jsonScript.so.isLevel3x8Available = true;
        jsonScript.so.isLevel3x9Available = true;
        jsonScript.so.isLevel3x10Available = true;
        jsonScript.so.isLevel3x11Available = true;
        jsonScript.so.isLevel3x12Available = true;
        jsonScript.so.isLevel3x13Available = true;
        jsonScript.so.isLevel3x14Available = true;
        jsonScript.so.isLevel3x15Available = true;
        jsonScript.so.isLevel3x16Available = true;
        jsonScript.so.isLevel4x1Available = true;
        jsonScript.so.isLevel4x2Available = true;
        jsonScript.so.isLevel4x3Available = true;
        jsonScript.so.isLevel4x4Available = true;
        jsonScript.so.isLevel4x5Available = true;
        jsonScript.so.isLevel4x6Available = true;
        jsonScript.so.isLevel4x7Available = true;
        jsonScript.so.isLevel4x8Available = true;
        jsonScript.so.isLevel4x9Available = true;
        jsonScript.so.isLevel4x10Available = true;
        jsonScript.so.isLevel4x11Available = true;
        jsonScript.so.isLevel4x12Available = true;
        jsonScript.so.isLevel4x13Available = true;
        jsonScript.so.isLevel4x14Available = true;
        jsonScript.so.isLevel5x1Available = true;
        jsonScript.so.isLevel5x2Available = true;
        jsonScript.so.isLevel5x3Available = true;
        jsonScript.so.isLevel5x4Available = true;
        jsonScript.so.isLevel5x5Available = true;
        jsonScript.so.isLevel5x6Available = true;
        jsonScript.so.isLevel5x7Available = true;
        jsonScript.so.isLevel5x8Available = true;
        jsonScript.so.isLevel5x9Available = true;
        jsonScript.so.isLevel5x10Available = true;

        isDodgeballAvailable = true;
        isSurvivalAvailable = true;
        isControlAvailable = true;
        isGauntletAvailable = true;
        isArenaAvailable = true;
        Debug.Log("Unlocked All Skins & Levels");
    }
}
