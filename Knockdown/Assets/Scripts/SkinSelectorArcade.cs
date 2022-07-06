using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SkinSelectorArcade : MonoBehaviour
{
    public GameObject skin1, skin2, skin3, skin4, skin5, skin6, skin7, skin8, skin9, skin10, skin11, skin12, skin13, skin14, skin15, skin16,
        skin17, skin18, skin19, skin20, skin21, skin22, skin23, skin24, skin25, skin26, skin27, skin28, skin29, skin30, skin31, skin32,
        lock1, lock2, lock3, lock4, lock5, lock6, lock7, lock8, lock9, lock10, lock11, lock12, lock13, lock14, lock15, lock16,
        lock17, lock18, lock19, lock20, lock21, lock22, lock23, lock24, lock25, lock26, lock27, lock28, lock29, lock30, lock31, lock32,
        teleportInfo;
    public TextMeshProUGUI diamondsText;
    //  MenuControls menuControls;
    private MasterScript masterScript;
    private SaveTest jsonScript;
    private SoundsScript soundScript;
    private SkinsVariables skinScript;
    public bool lockEnter;
    int lastSkin;
    public bool skinPage;
    bool lockMoves;

    /*
    #region New Controls
    public void Awake()
    {
        menuControls = new MenuControls();
        menuControls.Menu.Pause.performed += ctx => ReturnToMap();
        menuControls.Menu.Return.performed += ctx => ReturnToTitleScreen();
        menuControls.Menu.ShowInfo.performed += ctx => ChangePage();
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
    // Start is called before the first frame update
    void Start()
    {
        diamondsText = GameObject.Find("Diamonds Count").GetComponent<TextMeshProUGUI>();
        masterScript = GameObject.Find("MASTER OBJECT").GetComponent<MasterScript>();
        jsonScript = GameObject.Find("MASTER OBJECT").GetComponent<SaveTest>();
        skinScript = GameObject.Find("Values Manager").GetComponent<SkinsVariables>();
        lastSkin = jsonScript.so.playerSkin;
        #region Set Start Position
        switch (jsonScript.so.playerSkin)
        {
            case 1:
                skinPage = false;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin1").transform.position;
                break;
            case 2:
                skinPage = false;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin2").transform.position;
                break;
            case 3:
                skinPage = false;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin3").transform.position;
                break;
            case 4:
                skinPage = false;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin4").transform.position;
                break;
            case 5:
                skinPage = false;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin5").transform.position;
                break;
            case 6:
                skinPage = false;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin6").transform.position;
                break;
            case 7:
                skinPage = false;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin7").transform.position;
                break;
            case 8:
                skinPage = false;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin8").transform.position;
                break;
            case 9:
                skinPage = false;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin9").transform.position;
                break;
            case 10:
                skinPage = false;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin10").transform.position;
                break;
            case 11:
                skinPage = false;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin11").transform.position;
                break;
            case 12:
                skinPage = false;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin12").transform.position;
                break;
            case 13:
                skinPage = false;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin13").transform.position;
                break;
            case 14:
                skinPage = false;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin14").transform.position;
                break;
            case 15:
                skinPage = false;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin15").transform.position;
                break;
            case 16:
                skinPage = false;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin16").transform.position;
                break;
            case 123:
                skinPage = true;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin17").transform.position;
                break;
            case 122:
                skinPage = true;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin18").transform.position;
                break;
            case 127:
                skinPage = true;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin19").transform.position;
                break;
            case 124:
                skinPage = true;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin20").transform.position;
                break;
            case 121:
                skinPage = true;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin21").transform.position;
                break;
            case 102:
                skinPage = true;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin22").transform.position;
                break;
            case 128:
                skinPage = true;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin23").transform.position;
                break;
            case 103:
                skinPage = true;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin24").transform.position;
                break;
            case 112:
                skinPage = true;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin25").transform.position;
                break;
            case 126:
                skinPage = true;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin26").transform.position;
                break;
            case 101:
                skinPage = true;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin27").transform.position;
                break;
            case 129:
                skinPage = true;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin28").transform.position;
                break;
            case 125:
                skinPage = true;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin29").transform.position;
                break;
            case 104:
                skinPage = true;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin30").transform.position;
                break;
            case 111:
                skinPage = true;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin31").transform.position;
                break;
            case 130:
                skinPage = true;
                UpdatePage();
                UnlockSkinsArcade();
                transform.position = GameObject.Find("skin32").transform.position;
                break;
        }
        #endregion
        soundScript = GameObject.Find("Sound").GetComponent<SoundsScript>();
    }

    public void GoUp()
    {
        if (((!skinPage && jsonScript.so.playerSkin != 1 && jsonScript.so.playerSkin != 2 && jsonScript.so.playerSkin != 3
            && jsonScript.so.playerSkin != 4) || (skinPage && jsonScript.so.playerSkin != 123 && jsonScript.so.playerSkin != 122
            && jsonScript.so.playerSkin != 127 && jsonScript.so.playerSkin != 124)) && !lockMoves)
        {
            soundScript.PlayChangeMode();
            transform.position = new Vector3(transform.position.x, transform.position.y + 21.5f, transform.position.z);
        }
    }
    public void GoDown()
    {
        if (((!skinPage && jsonScript.so.playerSkin != 13 && jsonScript.so.playerSkin != 14 && jsonScript.so.playerSkin != 15
            && jsonScript.so.playerSkin != 16) || (skinPage && jsonScript.so.playerSkin != 125 && jsonScript.so.playerSkin != 104
            && jsonScript.so.playerSkin != 111 && jsonScript.so.playerSkin != 130)) && !lockMoves)
        {
            soundScript.PlayChangeMode();
            transform.position = new Vector3(transform.position.x, transform.position.y - 21.5f, transform.position.z);
        }
    }
    public void GoLeft()
    {
        if (((!skinPage && jsonScript.so.playerSkin != 1 && jsonScript.so.playerSkin != 5 && jsonScript.so.playerSkin != 9
            && jsonScript.so.playerSkin != 13) || (skinPage && jsonScript.so.playerSkin != 123 && jsonScript.so.playerSkin != 121
            && jsonScript.so.playerSkin != 112 && jsonScript.so.playerSkin != 125)) && !lockMoves)
        {
            soundScript.PlayChangeMode();
            transform.position = new Vector3(transform.position.x - 21.5f, transform.position.y, transform.position.z);
        }
    }
    public void GoRight()
    {
        if (((!skinPage && jsonScript.so.playerSkin != 4 && jsonScript.so.playerSkin != 8 && jsonScript.so.playerSkin != 12
            && jsonScript.so.playerSkin != 16) || (skinPage && jsonScript.so.playerSkin != 124 && jsonScript.so.playerSkin != 103
            && jsonScript.so.playerSkin != 129 && jsonScript.so.playerSkin != 130)) && !lockMoves)
        {
            soundScript.PlayChangeMode();
            transform.position = new Vector3(transform.position.x + 21.5f, transform.position.y, transform.position.z);
        }
    }

    #region Red Skin On collision
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("SkinLock"))
        {
            lockEnter = true;
        }
        if (col.transform.gameObject.name == ("skin1"))
        {
            jsonScript.so.playerSkin = 1;
        }
        if (col.transform.gameObject.name == ("skin2"))
        {
            jsonScript.so.playerSkin = 2;
        }
        if (col.transform.gameObject.name == ("skin3"))
        {
            jsonScript.so.playerSkin = 3;
        }
        if (col.transform.gameObject.name == ("skin4"))
        {
            jsonScript.so.playerSkin = 4;
        }
        if (col.transform.gameObject.name == ("skin5"))
        {
            jsonScript.so.playerSkin = 5;
        }
        if (col.transform.gameObject.name == ("skin6"))
        {
            jsonScript.so.playerSkin = 6;
        }
        if (col.transform.gameObject.name == ("skin7"))
        {
            jsonScript.so.playerSkin = 7;
        }
        if (col.transform.gameObject.name == ("skin8"))
        {
            jsonScript.so.playerSkin = 8;
        }
        if (col.transform.gameObject.name == ("skin9"))
        {
            jsonScript.so.playerSkin = 9;
        }
        if (col.transform.gameObject.name == ("skin10"))
        {
            jsonScript.so.playerSkin = 10;
        }
        if (col.transform.gameObject.name == ("skin11"))
        {
            jsonScript.so.playerSkin = 11;
        }
        if (col.transform.gameObject.name == ("skin12"))
        {
            jsonScript.so.playerSkin = 12;
        }
        if (col.transform.gameObject.name == ("skin13"))
        {
            jsonScript.so.playerSkin = 13;
        }
        if (col.transform.gameObject.name == ("skin14"))
        {
            jsonScript.so.playerSkin = 14;
        }
        if (col.transform.gameObject.name == ("skin15"))
        {
            jsonScript.so.playerSkin = 15;
        }
        if (col.transform.gameObject.name == ("skin16"))
        {
            jsonScript.so.playerSkin = 16;
        }
        if (col.transform.gameObject.name == ("skin17"))
        {
            jsonScript.so.playerSkin = 123;
        }
        if (col.transform.gameObject.name == ("skin18"))
        {
            jsonScript.so.playerSkin = 122;
        }
        if (col.transform.gameObject.name == ("skin19"))
        {
            jsonScript.so.playerSkin = 127;
        }
        if (col.transform.gameObject.name == ("skin20"))
        {
            jsonScript.so.playerSkin = 124;
        }
        if (col.transform.gameObject.name == ("skin21"))
        {
            jsonScript.so.playerSkin = 121;
        }
        if (col.transform.gameObject.name == ("skin22"))
        {
            jsonScript.so.playerSkin = 102;
        }
        if (col.transform.gameObject.name == ("skin23"))
        {
            jsonScript.so.playerSkin = 128;
        }
        if (col.transform.gameObject.name == ("skin24"))
        {
            jsonScript.so.playerSkin = 103;
        }
        if (col.transform.gameObject.name == ("skin25"))
        {
            jsonScript.so.playerSkin = 112;
        }
        if (col.transform.gameObject.name == ("skin26"))
        {
            jsonScript.so.playerSkin = 126;
        }
        if (col.transform.gameObject.name == ("skin27"))
        {
            jsonScript.so.playerSkin = 101;
        }
        if (col.transform.gameObject.name == ("skin28"))
        {
            jsonScript.so.playerSkin = 129;
        }
        if (col.transform.gameObject.name == ("skin29"))
        {
            jsonScript.so.playerSkin = 125;
        }
        if (col.transform.gameObject.name == ("skin30"))
        {
            jsonScript.so.playerSkin = 104;
        }
        if (col.transform.gameObject.name == ("skin31"))
        {
            jsonScript.so.playerSkin = 111;
        }
        if (col.transform.gameObject.name == ("skin32"))
        {
            jsonScript.so.playerSkin = 130;
            teleportInfo.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider col2)
    {
        if (col2.gameObject.tag.Equals("SkinLock"))
        {
            lockEnter = false;
        }
        if (col2.transform.gameObject.name == ("skin32"))
        {
            teleportInfo.SetActive(false);
        }
    }
        #endregion

    public void ReturnToTitleScreen()
    {
        jsonScript.so.playerSkin = lastSkin;
        SceneManager.LoadScene("Title Screen");
    }

    public void ReturnToMap()
    {
        if (!lockEnter)
        {
            lockMoves = true;
            soundScript.PlayChangeCategory();
            StartCoroutine(Return());
        }
        else
        {
            if (jsonScript.so.playerSkin == 3 && !jsonScript.so.isSkin3Available && jsonScript.so.diamonds>skinScript.price)
            {
                soundScript.PlaySound("Unlock");
                jsonScript.so.diamonds-=skinScript.price;
                lock3.SetActive(false);
                jsonScript.so.isSkin3Available = true;
                lockEnter = false;
            }
            if (jsonScript.so.playerSkin == 4 && !jsonScript.so.isSkin4Available && jsonScript.so.diamonds > skinScript.price)
            {
                soundScript.PlaySound("Unlock");
                jsonScript.so.diamonds -= skinScript.price;
                lock4.SetActive(false);
                jsonScript.so.isSkin4Available = true;
                lockEnter = false;
            }
            if (jsonScript.so.playerSkin == 5 && !jsonScript.so.isSkin5Available && jsonScript.so.diamonds > skinScript.price)
            {
                soundScript.PlaySound("Unlock");
                jsonScript.so.diamonds -= skinScript.price;
                lock5.SetActive(false);
                jsonScript.so.isSkin5Available = true;
                lockEnter = false;
            }
            if (jsonScript.so.playerSkin == 6 && !jsonScript.so.isSkin6Available && jsonScript.so.diamonds > skinScript.price)
            {
                soundScript.PlaySound("Unlock");
                jsonScript.so.diamonds -= skinScript.price;
                lock6.SetActive(false);
                jsonScript.so.isSkin6Available = true;
                lockEnter = false;
            }
            if (jsonScript.so.playerSkin == 7 && !jsonScript.so.isSkin7Available && jsonScript.so.diamonds > skinScript.price)
            {
                soundScript.PlaySound("Unlock");
                jsonScript.so.diamonds -= skinScript.price;
                lock7.SetActive(false);
                jsonScript.so.isSkin7Available = true;
                lockEnter = false;
            }
            if (jsonScript.so.playerSkin == 8 && !jsonScript.so.isSkin8Available && jsonScript.so.diamonds > skinScript.price)
            {
                soundScript.PlaySound("Unlock");
                jsonScript.so.diamonds -= skinScript.price;
                lock8.SetActive(false);
                jsonScript.so.isSkin8Available = true;
                lockEnter = false;
            }
            if (jsonScript.so.playerSkin == 9 && !jsonScript.so.isSkin9Available && jsonScript.so.diamonds > skinScript.price)
            {
                soundScript.PlaySound("Unlock");
                jsonScript.so.diamonds -= skinScript.price;
                lock9.SetActive(false);
                jsonScript.so.isSkin9Available = true;
                lockEnter = false;
            }
            if (jsonScript.so.playerSkin == 123 && !jsonScript.so.isSkin123Available && jsonScript.so.diamonds > skinScript.price)
            {
                soundScript.PlaySound("Unlock");
                jsonScript.so.diamonds -= skinScript.price;
                lock17.SetActive(false);
                Debug.Log("pos1");
                jsonScript.so.isSkin123Available = true;
                lockEnter = false;
            }
            if (jsonScript.so.playerSkin == 122 && !jsonScript.so.isSkin122Available && jsonScript.so.diamonds > skinScript.price)
            {
                soundScript.PlaySound("Unlock");
                jsonScript.so.diamonds -= skinScript.price;
                lock18.SetActive(false);
                jsonScript.so.isSkin122Available = true;
                lockEnter = false;
            }
            if (jsonScript.so.playerSkin == 127 && !jsonScript.so.isSkin127Available && jsonScript.so.diamonds > skinScript.price)
            {
                soundScript.PlaySound("Unlock");
                jsonScript.so.diamonds -= skinScript.price;
                lock19.SetActive(false);
                jsonScript.so.isSkin127Available = true;
                lockEnter = false;
            }
            if (jsonScript.so.playerSkin == 124 && !jsonScript.so.isSkin124Available && jsonScript.so.diamonds > skinScript.price)
            {
                soundScript.PlaySound("Unlock");
                jsonScript.so.diamonds -= skinScript.price;
                lock20.SetActive(false);
                jsonScript.so.isSkin124Available = true;
                lockEnter = false;
            }
            if (jsonScript.so.playerSkin == 121 && !jsonScript.so.isSkin121Available && jsonScript.so.diamonds > skinScript.price)
            {
                soundScript.PlaySound("Unlock");
                jsonScript.so.diamonds -= skinScript.price;
                lock21.SetActive(false);
                jsonScript.so.isSkin121Available = true;
                lockEnter = false;
            }
            if (jsonScript.so.playerSkin == 102 && !jsonScript.so.isSkin102Available && jsonScript.so.diamonds > skinScript.price)
            {
                soundScript.PlaySound("Unlock");
                jsonScript.so.diamonds -= skinScript.price;
                lock22.SetActive(false);
                jsonScript.so.isSkin102Available = true;
                lockEnter = false;
            }
            if (jsonScript.so.playerSkin == 128 && !jsonScript.so.isSkin128Available && jsonScript.so.diamonds > skinScript.price)
            {
                soundScript.PlaySound("Unlock");
                jsonScript.so.diamonds -= skinScript.price;
                lock23.SetActive(false);
                jsonScript.so.isSkin128Available = true;
                lockEnter = false;
            }
            if (jsonScript.so.playerSkin == 103 && !jsonScript.so.isSkin103Available && jsonScript.so.diamonds > skinScript.price)
            {
                soundScript.PlaySound("Unlock");
                jsonScript.so.diamonds -= skinScript.price;
                lock24.SetActive(false);
                jsonScript.so.isSkin103Available = true;
                lockEnter = false;
            }
            if (jsonScript.so.playerSkin == 112 && !jsonScript.so.isSkin112Available && jsonScript.so.diamonds > skinScript.price)
            {
                soundScript.PlaySound("Unlock");
                jsonScript.so.diamonds -= skinScript.price;
                lock25.SetActive(false);
                jsonScript.so.isSkin112Available = true;
                lockEnter = false;
            }
            if (jsonScript.so.playerSkin == 126 && !jsonScript.so.isSkin126Available && jsonScript.so.diamonds > skinScript.price)
            {
                soundScript.PlaySound("Unlock");
                jsonScript.so.diamonds -= skinScript.price;
                lock26.SetActive(false);
                jsonScript.so.isSkin126Available = true;
                lockEnter = false;
            }
            if (jsonScript.so.playerSkin == 101 && !jsonScript.so.isSkin101Available && jsonScript.so.diamonds > skinScript.price)
            {
                soundScript.PlaySound("Unlock");
                jsonScript.so.diamonds -= skinScript.price;
                lock27.SetActive(false);
                jsonScript.so.isSkin101Available = true;
                lockEnter = false;
            }
            if (jsonScript.so.playerSkin == 129 && !jsonScript.so.isSkin129Available && jsonScript.so.diamonds > skinScript.price)
            {
                soundScript.PlaySound("Unlock");
                jsonScript.so.diamonds -= skinScript.price;
                lock28.SetActive(false);
                jsonScript.so.isSkin129Available = true;
                lockEnter = false;
            }
            if (jsonScript.so.playerSkin == 125 && !jsonScript.so.isSkin125Available && jsonScript.so.diamonds > skinScript.price)
            {
                soundScript.PlaySound("Unlock");
                jsonScript.so.diamonds -= skinScript.price;
                lock29.SetActive(false);
                jsonScript.so.isSkin125Available = true;
                lockEnter = false;
            }
            if (jsonScript.so.playerSkin == 104 && !jsonScript.so.isSkin104Available && jsonScript.so.diamonds > skinScript.price)
            {
                soundScript.PlaySound("Unlock");
                jsonScript.so.diamonds -= skinScript.price;
                lock30.SetActive(false);
                jsonScript.so.isSkin104Available = true;
                lockEnter = false;
            }
            if (jsonScript.so.playerSkin == 111 && !jsonScript.so.isSkin111Available && jsonScript.so.diamonds > skinScript.price)
            {
                soundScript.PlaySound("Unlock");
                jsonScript.so.diamonds -= skinScript.price;
                lock31.SetActive(false);
                jsonScript.so.isSkin111Available = true;
                lockEnter = false;
            }
            if (jsonScript.so.playerSkin == 130 && !jsonScript.so.isSkin130Available && jsonScript.so.diamonds > skinScript.price)
            {
                soundScript.PlaySound("Unlock");
                jsonScript.so.diamonds -= skinScript.price;
                lock32.SetActive(false);
                jsonScript.so.isSkin130Available = true;
                lockEnter = false;
            }
            jsonScript.Save();
            UpdatePage();
        }
    }

    IEnumerator Return()
    {
        yield return new WaitForSeconds(0.5f);
        jsonScript.so.dontRestartMusic = true;
        SceneManager.LoadScene("Map Menu");
    }

    public void ChangePage()
    {
        soundScript.PlayChangeMode();
        skinPage = !skinPage;
        UnlockSkinsArcade();
        UpdatePage();
    }

    #region Update Page Info
    public void UpdatePage()
    {
        if (!skinPage)
        {
            skin1.SetActive(true);
            skin2.SetActive(true);
            skin3.SetActive(true);
            skin4.SetActive(true);
            skin5.SetActive(true);
            skin6.SetActive(true);
            skin7.SetActive(true);
            skin8.SetActive(true);
            skin9.SetActive(true);
            skin10.SetActive(true);
            skin11.SetActive(true);
            skin12.SetActive(true);
            skin13.SetActive(true);
            skin14.SetActive(true);
            skin15.SetActive(true);
            skin16.SetActive(true);
            skin17.SetActive(false);
            skin18.SetActive(false);
            skin19.SetActive(false);
            skin20.SetActive(false);
            skin21.SetActive(false);
            skin22.SetActive(false);
            skin23.SetActive(false);
            skin24.SetActive(false);
            skin25.SetActive(false);
            skin26.SetActive(false);
            skin27.SetActive(false);
            skin28.SetActive(false);
            skin29.SetActive(false);
            skin30.SetActive(false);
            skin31.SetActive(false);
            skin32.SetActive(false);

            if (!jsonScript.so.isSkin2Available)
            {
                lock2.SetActive(true);
            }
            if (!jsonScript.so.isSkin3Available)
            {
                lock3.SetActive(true);
            }
            if (!jsonScript.so.isSkin4Available)
            {
                lock4.SetActive(true);
            }
            if (!jsonScript.so.isSkin5Available)
            {
                lock5.SetActive(true);
            }
            if (!jsonScript.so.isSkin6Available)
            {
                lock6.SetActive(true);
            }
            if (!jsonScript.so.isSkin7Available)
            {
                lock7.SetActive(true);
            }
            if (!jsonScript.so.isSkin8Available)
            {
                lock8.SetActive(true);
            }
            if (!jsonScript.so.isSkin9Available)
            {
                lock9.SetActive(true);
            }
            if (!jsonScript.so.isSkin10Available)
            {
                lock10.SetActive(true);
            }
            if (!jsonScript.so.isSkin11Available)
            {
                lock11.SetActive(true);
            }
            if (!jsonScript.so.isSkin12Available)
            {
                lock12.SetActive(true);
            }
            if (!jsonScript.so.isSkin13Available)
            {
                lock13.SetActive(true);
            }
            if (!jsonScript.so.isSkin14Available)
            {
                lock14.SetActive(true);
            }
            if (!jsonScript.so.isSkin15Available)
            {
                lock15.SetActive(true);
            }
            if (!jsonScript.so.isSkin16Available)
            {
                lock16.SetActive(true);
            }
            lock17.SetActive(false);
            Debug.Log("pos2");
            lock18.SetActive(false);
            lock19.SetActive(false);
            lock20.SetActive(false);
            lock21.SetActive(false);
            lock22.SetActive(false);
            lock23.SetActive(false);
            lock24.SetActive(false);
            lock25.SetActive(false);
            lock26.SetActive(false);
            lock27.SetActive(false);
            lock28.SetActive(false);
            lock29.SetActive(false);
            lock30.SetActive(false);
            lock31.SetActive(false);
            lock32.SetActive(false);
        }
        else if (skinPage)
        {
            skin1.SetActive(false);
            skin2.SetActive(false);
            skin3.SetActive(false);
            skin4.SetActive(false);
            skin5.SetActive(false);
            skin6.SetActive(false);
            skin7.SetActive(false);
            skin8.SetActive(false);
            skin9.SetActive(false);
            skin10.SetActive(false);
            skin11.SetActive(false);
            skin12.SetActive(false);
            skin13.SetActive(false);
            skin14.SetActive(false);
            skin15.SetActive(false);
            skin16.SetActive(false);
            skin17.SetActive(true);
            skin18.SetActive(true);
            skin19.SetActive(true);
            skin20.SetActive(true);
            skin21.SetActive(true);
            skin22.SetActive(true);
            skin23.SetActive(true);
            skin24.SetActive(true);
            skin25.SetActive(true);
            skin26.SetActive(true);
            skin27.SetActive(true);
            skin28.SetActive(true);
            skin29.SetActive(true);
            skin30.SetActive(true);
            skin31.SetActive(true);
            skin32.SetActive(true);

            lock1.SetActive(false);
            lock2.SetActive(false);
            lock3.SetActive(false);
            lock4.SetActive(false);
            lock5.SetActive(false);
            lock6.SetActive(false);
            lock7.SetActive(false);
            lock8.SetActive(false);
            lock9.SetActive(false);
            lock10.SetActive(false);
            lock11.SetActive(false);
            lock12.SetActive(false);
            lock13.SetActive(false);
            lock14.SetActive(false);
            lock15.SetActive(false);
            lock16.SetActive(false);

            if (!jsonScript.so.isSkin123Available)
            {
                lock17.SetActive(true);
                Debug.Log("pogdeg");
            }
            if (!jsonScript.so.isSkin122Available)
            {
                lock18.SetActive(true);
            }
            if (!jsonScript.so.isSkin127Available)
            {
                lock19.SetActive(true);
            }
            if (!jsonScript.so.isSkin124Available)
            {
                lock20.SetActive(true);
            }
            if (!jsonScript.so.isSkin121Available)
            {
                lock21.SetActive(true);
            }
            if (!jsonScript.so.isSkin102Available)
            {
                lock22.SetActive(true);
            }
            if (!jsonScript.so.isSkin128Available)
            {
                lock23.SetActive(true);
            }
            if (!jsonScript.so.isSkin103Available)
            {
                lock24.SetActive(true);
            }
            if (!jsonScript.so.isSkin112Available)
            {
                lock25.SetActive(true);
            }
            if (!jsonScript.so.isSkin126Available)
            {
                lock26.SetActive(true);
            }
            if (!jsonScript.so.isSkin101Available)
            {
                lock27.SetActive(true);
            }
            if (!jsonScript.so.isSkin129Available)
            {
                lock28.SetActive(true);
            }
            if (!jsonScript.so.isSkin125Available)
            {
                lock29.SetActive(true);
            }
            if (!jsonScript.so.isSkin104Available)
            {
                lock30.SetActive(true);
            }
            if (!jsonScript.so.isSkin111Available)
            {
                lock31.SetActive(true);
            }
            if (!jsonScript.so.isSkin130Available)
            {
                lock32.SetActive(true);
            }
        }
    }
    #endregion

    #region Unlock Skins Arcade
    public void UnlockSkinsArcade()
    {
            lock1.SetActive(false);
            if (jsonScript.so.isSkin2Available)
            {
                lock2.SetActive(false);
            }
            if (jsonScript.so.isSkin3Available)
            {
                lock3.SetActive(false);
            }
            if (jsonScript.so.isSkin4Available)
            {
                lock4.SetActive(false);
            }
            if (jsonScript.so.isSkin5Available)
            {
                lock5.SetActive(false);
            }
            if (jsonScript.so.isSkin6Available)
            {
                lock6.SetActive(false);
            }
            if (jsonScript.so.isSkin7Available)
            {
                lock7.SetActive(false);
            }
            if (jsonScript.so.isSkin8Available)
            {
                lock8.SetActive(false);
            }
            if (jsonScript.so.isSkin9Available)
            {
                lock9.SetActive(false);
            }
            if (jsonScript.so.isSkin10Available)
            {
                lock10.SetActive(false);
            }
            if (jsonScript.so.isSkin11Available)
            {
                lock11.SetActive(false);
            }
            if (jsonScript.so.isSkin12Available)
            {
                lock12.SetActive(false);
            }
            if (jsonScript.so.isSkin13Available)
            {
                lock13.SetActive(false);
            }
            if (jsonScript.so.isSkin14Available)
            {
                lock14.SetActive(false);
            }
            if (jsonScript.so.isSkin15Available)
            {
                lock15.SetActive(false);
            }
            if (jsonScript.so.isSkin16Available)
            {
                lock16.SetActive(false);
            }

            if (jsonScript.so.isSkin123Available)
            {
                lock17.SetActive(false);
            Debug.Log("pos3");
            }
            if (jsonScript.so.isSkin122Available)
            {
                lock18.SetActive(false);
            }
            if (jsonScript.so.isSkin127Available)
            {
                lock19.SetActive(false);
            }
            if (jsonScript.so.isSkin124Available)
            {
                lock20.SetActive(false);
            }
            if (jsonScript.so.isSkin121Available)
            {
                lock21.SetActive(false);
            }
            if (jsonScript.so.isSkin102Available)
            {
                lock22.SetActive(false);
            }
            if (jsonScript.so.isSkin128Available)
            {
                lock23.SetActive(false);
            }
            if (jsonScript.so.isSkin103Available)
            {
                lock24.SetActive(false);
            }
            if (jsonScript.so.isSkin112Available)
            {
                lock25.SetActive(false);
            }
            if (jsonScript.so.isSkin126Available)
            {
                lock26.SetActive(false);
            }
            if (jsonScript.so.isSkin101Available)
            {
                lock27.SetActive(false);
            }
            if (jsonScript.so.isSkin129Available)
            {
                lock28.SetActive(false);
            }
            if (jsonScript.so.isSkin125Available)
            {
                lock29.SetActive(false);
            }
            if (jsonScript.so.isSkin104Available)
            {
                lock30.SetActive(false);
            }
            if (jsonScript.so.isSkin111Available)
            {
                lock31.SetActive(false);
            }
            if (jsonScript.so.isSkin130Available)
            {
                lock32.SetActive(false);
            }
    }
    #endregion

    private void Update()
    {
        if (GameObject.Find("MASTER OBJECT") != null)
        {
            diamondsText.text = "" + jsonScript.so.diamonds;
        }
    }
}
