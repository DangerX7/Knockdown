using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    #region Set Initial Variables
    //  MenuControls menuControls;
    private CharacterSwitcher characterSwitcherScript;
    private MasterScript masterScript;
    private SaveTest jsonScript;
    private SoundsScript soundScript;
    public Image img;
    public TextMeshProUGUI screenModeTxt, resolutionTxt;
 //   bool mainMenu = true;
    public int optionsMode;
    Vector3 initialSize; // to keep selector resolution
    Vector3 doubleSize;
    Vector3 doubleSizeX2;
    Vector3 QuatroSize;
    public bool pressEnter;
    public bool controlsMenu;
    public bool controlSwitch;
    bool warningLock;
    public Button P1Move, P1Jump, P1Dash, P1Teleport, P1ResetM, P1ResetJ, P1ResetD, P1ResetT, P2Move, P2Jump, P2Dash, P2Teleport, P2ResetM,
        P2ResetJ, P2ResetD, P2ResetT, P3Move, P3Jump, P3Dash, P3Teleport, P3ResetM, P3ResetJ, P3ResetD, P3ResetT, P4Move, P4Jump, P4Dash,
        P4Teleport, P4ResetM, P4ResetJ, P4ResetD, P4ResetT,  ResetAll, Save, Keyboard, Gamepad;
    public GameObject Title, Single, Multiplayer, Options, Survival, Arcade, Gauntlet, Colosseum, Arena, Versus, Dodgeball, Control, P1,
        P2cm, P2a, P3a, P4a, P2v, P3v, P4v, P2d, P3d, P4d, P2c, screen, resolutionX, texture, bgmVol, sfxVol, controls, exit, left, right, left2, right2,
        left3, right3, left4, right4, left5, right5, controlsParent, SingleMenu, MultyMenu, OptionsMenu, MainParent, ControlParent, ControlsExit,
        textureLevel1, textureLevel2, textureLevel3, textureLevel4, textureLevel5, textureLevel6, textureLevel7, textureLevel8,
        bgmLevel1, bgmLevel2, bgmLevel3, bgmLevel4, bgmLevel5, bgmLevel6, bgmLevel7, bgmLevel8,
        sfxLevel1, sfxLevel2, sfxLevel3, sfxLevel4, sfxLevel5, sfxLevel6, sfxLevel7, sfxLevel8,
        P1move, P1jump, P1dash, P1teleport, P1reset, P2move, P2jump, P2dash, P2teleport, P2reset, P3move, P3jump,
        P3dash, P3teleport, P3reset, P4move, P4jump, P4dash, P4reset, P4teleport, resetAll, save, keyboard, gamepad, morePlayers;
    #endregion

    /*
    #region New Controls
    public void Awake()
    {
        menuControls = new MenuControls();
        menuControls.Menu.Pause.performed += ctx => AdvanceMode(); 
        menuControls.Menu.Restart.performed += ctx => ReturnMode();
        menuControls.Menu.Return.performed += ctx => ReturnToOptions();
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
    #endregion */
    // Start is called before the first frame update
    void Start()
    {
        //   viewType = 1;
        img = gameObject.GetComponent<Image>();
        characterSwitcherScript = GameObject.Find("Player Manager").GetComponent<CharacterSwitcher>();
        if (GameObject.Find("MASTER OBJECT") != null)
        {
            masterScript = GameObject.Find("MASTER OBJECT").GetComponent<MasterScript>();
            jsonScript = GameObject.Find("MASTER OBJECT").GetComponent<SaveTest>();
        }
        soundScript = GameObject.Find("Sound").GetComponent<SoundsScript>();
        initialSize = transform.localScale;
        doubleSize = new Vector3(initialSize.x, initialSize.y * 2, initialSize.z);
        doubleSizeX2 = new Vector3(initialSize.x * 2, initialSize.y * 2, initialSize.z);
        QuatroSize = new Vector3(initialSize.x, initialSize.y * 4, initialSize.z);
    }

    private void Update()
    {
        //   Debug.Log( "MX " + optionsMode);
        if (controlsMenu && !controlSwitch)
        {
            controlSwitch = true;
        }
        ButtonsView();
    }

    #region GoUp Code
    public void GoUp()
    {
        if (!controlsMenu)
        {
            soundScript.PlayChangeMode();
            switch (optionsMode)
            {
                case 1:
                    
                    break;
                case 2:
                    transform.position = Single.transform.position;
                    break;
                case 7:
                    transform.position = Multiplayer.transform.position;
                    break;
                case 11:

                    break;
                case 12:
                    transform.position = Survival.transform.position;
                    break;
                case 13:
                    transform.position = Arcade.transform.position;
                    break;
                case 21:
                    transform.position = Colosseum.transform.position;
                    break;
                case 22:
                    transform.position = Arena.transform.position;
                    break;
                case 23:
                    transform.position = Versus.transform.position;
                    break;
                case 24:
                    transform.position = Dodgeball.transform.position;
                    break;
                case 31:

                    break;
                case 32:
                    transform.position = screen.transform.position; 
                    break;
                case 33:
                    transform.position = resolutionX.transform.position; 
                    break;
                case 34:
                    transform.position = texture.transform.position; 
                    break;
                case 35:
                    transform.position = bgmVol.transform.position; 
                    break;
                case 36:
                    transform.position = sfxVol.transform.position; 
                    break;
                case 42:

                    break;
                case 43:
                    transform.position = P2a.transform.position; 
                    break;
                case 44:
                    transform.position = P3a.transform.position; 
                    break; 
                case 52:

                    break;
                case 53:
                    transform.position = P2v.transform.position;
                    break;
                case 54:
                    transform.position = P3v.transform.position;
                    break;
                case 62:

                    break;
                case 63:
                    transform.position = P2d.transform.position;
                    break;
                case 64:
                    transform.position = P3d.transform.position;
                    break;
                case 72:

                    break;
            }
        }
        else if (controlsMenu)
        {
            if (optionsMode != 111 && optionsMode != 112 && optionsMode != 113 && optionsMode != 114 && optionsMode != 115)
            {
                Debug.Log("Up");
                img.enabled = false;
            }
            if (optionsMode == 121)
            {
                transform.position = P1move.transform.position;
            }
            if (optionsMode == 122)
            {
                transform.position = P1jump.transform.position;
            }
            if (optionsMode == 123)
            {
                transform.position = P1dash.transform.position;
            }
            if (optionsMode == 124)
            {
                transform.position = P1teleport.transform.position;
            }
            if (optionsMode == 125)
            {
                transform.position = P1reset.transform.position;
            }
            if (optionsMode == 130)
            {
                transform.position = P2jump.transform.position;
            }
            if (optionsMode == 140)
            {
                transform.position = Save.transform.position;
            }
        }
    }
    #endregion
    #region Go Down Code
    public void GoDown()
    {
        if (!controlsMenu)
        {
            soundScript.PlayChangeMode();
            switch (optionsMode)
            {
                case 1:
                    transform.position = Multiplayer.transform.position;
                    break;
                case 2:
                    transform.position = Options.transform.position;
                    break;
                case 7:

                    break;
                case 11:
                    transform.position = Arcade.transform.position;
                    break;
                case 12:
                    transform.position = Gauntlet.transform.position;
                    break;
                case 13:

                    break;
                case 20:
                    transform.position = Arena.transform.position;
                    break;
                case 21:
                    transform.position = Versus.transform.position;
                    break;
                case 22:
                    transform.position = Dodgeball.transform.position;
                    break;
                case 23:
                    transform.position = Control.transform.position;
                    break;
                case 24:

                    break;
                case 31:
                    transform.position = resolutionX.transform.position;
                    break;
                case 32:
                    transform.position = texture.transform.position;
                    break;
                case 33:
                    transform.position = bgmVol.transform.position;
                    break;
                case 34:
                    transform.position = sfxVol.transform.position;
                    break;
                case 35:
                    transform.position = controls.transform.position;
                    break;
                case 36:

                    break;
                case 42:
                    transform.position = P3a.transform.position;
                    break;
                case 43:
                    transform.position = P4a.transform.position;
                    break;
                case 44:

                    break;
                case 52:
                    transform.position = P3v.transform.position;
                    break;
                case 53:
                    transform.position = P4v.transform.position;
                    break;
                case 54:

                    break;
                case 62:
                    transform.position = P3d.transform.position;
                    break;
                case 63:
                    transform.position = P4d.transform.position;
                    break;
                case 64:

                    break;
                case 72:

                    break;
            }
        }
        else if (controlsMenu)
        {
            if (optionsMode != 140)
            {
                Debug.Log("Down");
                img.enabled = false;
            }
            if (optionsMode == 111)
            {
                transform.position = P2move.transform.position;
            }
            if (optionsMode == 112)
            {
                transform.position = P2jump.transform.position;
            }
            if (optionsMode == 113)
            {
                transform.position = P2dash.transform.position;
            }
            if (optionsMode == 114)
            {
                transform.position = P2teleport.transform.position;
            }
            if (optionsMode == 115)
            {
                transform.position = P2reset.transform.position;
            }
            if (optionsMode == 121)
            {
                transform.position = Save.transform.position;
            }
            if (optionsMode == 122)
            {
                transform.position = Save.transform.position;
            }
            if (optionsMode == 123)
            {
                transform.position = Save.transform.position;
            }
            if (optionsMode == 124)
            {
                transform.position = Save.transform.position;
            }
            if (optionsMode == 125)
            {
                transform.position = Save.transform.position;
            }
            if (optionsMode == 130)
            {
                transform.position = ResetAll.transform.position;
            }
        }
    }
    #endregion
    #region Go Left Code
    public void GoLeft()
    {
        if (!controlsMenu)
        {
            if ((optionsMode != 1) && (optionsMode != 2) && (optionsMode != 7) && (optionsMode != 31) && (optionsMode != 32) &&
                (optionsMode != 33) && (optionsMode != 34) && (optionsMode != 35))
            {
                soundScript.PlayChangeCategory();
                ReturnMode();
            }
            if (optionsMode == 31 && jsonScript.so.screenModeType == 1)
            {
                //Screen Mode
                soundScript.PlayChangeMode();
                Screen.fullScreen = !Screen.fullScreen;
                screenModeTxt.text = "Fullscreen";
                jsonScript.so.screenModeType = 0;
                ShowArrows();
            }
            if (optionsMode == 32)
            {
                //Resolution
                soundScript.PlayChangeMode();
                switch (jsonScript.so.resolutionType)
                {
                    case 0:
                        Screen.SetResolution(1536, 864, false);
                        resolutionTxt.text = "1536x864";
                        jsonScript.so.resolutionType = 1;
                        break;
                    case 1:
                        Screen.SetResolution(1280, 720, false);
                        resolutionTxt.text = "1280x720";
                        jsonScript.so.resolutionType = 2;
                        break;
                    case 2:
                        Screen.SetResolution(960, 540, false);
                        resolutionTxt.text = "960x540";
                        jsonScript.so.resolutionType = 3;
                        break;
                    case 3:
                        Screen.SetResolution(720, 405, false);
                        resolutionTxt.text = "720x405";
                        jsonScript.so.resolutionType = 4;
                        break;
                }
                ShowArrows();
            }
            if (optionsMode == 33)
            {
                //TEXTURE
                soundScript.PlayChangeMode();
                switch (jsonScript.so.textureResolution)
                {
                    case 0:
                        jsonScript.so.textureResolution = 1;
                        QualitySettings.masterTextureLimit = 1;
                        break;
                    case 1:
                        jsonScript.so.textureResolution = 2;
                        QualitySettings.masterTextureLimit = 2;
                        break;
                    case 2:
                        jsonScript.so.textureResolution = 3;
                        QualitySettings.masterTextureLimit = 3;
                        break;
                    case 3:
                        jsonScript.so.textureResolution = 4;
                        QualitySettings.masterTextureLimit = 4;
                        break;
                    case 4:
                        jsonScript.so.textureResolution = 5;
                        QualitySettings.masterTextureLimit = 5;
                        break;
                    case 5:
                        jsonScript.so.textureResolution = 6;
                        QualitySettings.masterTextureLimit = 6;
                        break;
                    case 6:
                        jsonScript.so.textureResolution = 7;
                        QualitySettings.masterTextureLimit = 7;
                        break;
                }
                ShowArrows();
                ChangeTextureLevels();
            }
            if (optionsMode == 34)
            {
                //BGM Volume
                soundScript.PlayChangeMode();
                switch (jsonScript.so.BGMvol)
                {
                    case 1:
                        jsonScript.so.BGMvol = 0.875f;
                        break;
                    case 0.875f:
                        jsonScript.so.BGMvol = 0.75f;
                        break;
                    case 0.75f:
                        jsonScript.so.BGMvol = 0.625f;
                        break;
                    case 0.625f:
                        jsonScript.so.BGMvol = 0.5f;
                        break;
                    case 0.5f:
                        jsonScript.so.BGMvol = 0.375f;
                        break;
                    case 0.375f:
                        jsonScript.so.BGMvol = 0.25f;
                        break;
                    case 0.25f:
                        jsonScript.so.BGMvol = 0.125f;
                        break;
                }
                ShowArrows();
                ChangeBgmLevels();
            }
            if (optionsMode == 35)
            {
                //SFX Volume
                soundScript.PlayChangeMode();
                switch (jsonScript.so.SFXvol)
                {
                    case 1:
                        jsonScript.so.SFXvol = 0.875f;
                        break;
                    case 0.875f:
                        jsonScript.so.SFXvol = 0.75f;
                        break;
                    case 0.75f:
                        jsonScript.so.SFXvol = 0.625f;
                        break;
                    case 0.625f:
                        jsonScript.so.SFXvol = 0.5f;
                        break;
                    case 0.5f:
                        jsonScript.so.SFXvol = 0.375f;
                        break;
                    case 0.375f:
                        jsonScript.so.SFXvol = 0.25f;
                        break;
                    case 0.25f:
                        jsonScript.so.SFXvol = 0.125f;
                        break;
                }
                ShowArrows();
                ChangeSfxLevels();
            }
        }
        else if (controlsMenu)
        {
            if (optionsMode != 111 && optionsMode != 121 && optionsMode != 130 && optionsMode != 140)
            {
                Debug.Log("Left");
                img.enabled = false;
            }
            if (optionsMode == 112)
            {
                transform.position = P1move.transform.position;
            }
            if (optionsMode == 113)
            {
                transform.position = P1jump.transform.position;
            }
            if (optionsMode == 114)
            {
                transform.position = P1dash.transform.position;
            }
            if (optionsMode == 115)
            {
                transform.position = P1teleport.transform.position;
            }
            if (optionsMode == 122)
            {
                transform.position = P2move.transform.position;
            }
            if (optionsMode == 123)
            {
                transform.position = P2jump.transform.position;
            }
            if (optionsMode == 124)
            {
                transform.position = P2dash.transform.position;
            }
            if (optionsMode == 125)
            {
                transform.position = P2teleport.transform.position;
            }
        }
    }
    #endregion
    #region Go Right Code
    public void GoRight()
    {
        if (!controlsMenu)
        {
            if ((optionsMode != 11) && (optionsMode != 12) && (optionsMode != 13) && (optionsMode != 31) &&
                (optionsMode != 32) && (optionsMode != 33) && (optionsMode != 34) && (optionsMode != 35) && (optionsMode != 40) && (optionsMode != 42) &&
                (optionsMode != 43) && (optionsMode != 44) && (optionsMode != 52) && (optionsMode != 53) && (optionsMode != 54) &&
                (optionsMode != 62) && (optionsMode != 63) && (optionsMode != 64) && (optionsMode != 72))
            {
                AdvanceMode();
            }
            if (optionsMode == 31 && jsonScript.so.screenModeType == 0)
            {
                //Screen Mode
                soundScript.PlayChangeMode();
                Screen.fullScreen = !Screen.fullScreen;
                screenModeTxt.text = "Windowed";
                jsonScript.so.screenModeType = 1;
                ShowArrows();
            }
            if (optionsMode == 32)
            {
                //Resolution
                soundScript.PlayChangeMode();
                switch (jsonScript.so.resolutionType)
                {
                    case 1:
                        Screen.SetResolution(1920, 1080, false);
                        resolutionTxt.text = "1920x1080";
                        jsonScript.so.resolutionType = 0;
                        break;
                    case 2:
                        Screen.SetResolution(1536, 864, false);
                        resolutionTxt.text = "1536x864";
                        jsonScript.so.resolutionType = 1;
                        break;
                    case 3:
                        Screen.SetResolution(1280, 720, false);
                        resolutionTxt.text = "1280x720";
                        jsonScript.so.resolutionType = 2;
                        break;
                    case 4:
                        Screen.SetResolution(960, 540, false);
                        resolutionTxt.text = "960x540";
                        jsonScript.so.resolutionType = 3;
                        break;
                }
                ShowArrows();
            }
            if (optionsMode == 33)
            {
                //TEXTURE
                soundScript.PlayChangeMode();
                switch (jsonScript.so.textureResolution)
                {
                    case 1:
                        jsonScript.so.textureResolution = 0;
                        QualitySettings.masterTextureLimit = 0;
                        break;
                    case 2:
                        jsonScript.so.textureResolution = 1;
                        QualitySettings.masterTextureLimit = 1;
                        break;
                    case 3:
                        jsonScript.so.textureResolution = 2;
                        QualitySettings.masterTextureLimit = 2;
                        break;
                    case 4:
                        jsonScript.so.textureResolution = 3;
                        QualitySettings.masterTextureLimit = 3;
                        break;
                    case 5:
                        jsonScript.so.textureResolution = 4;
                        QualitySettings.masterTextureLimit = 4;
                        break;
                    case 6:
                        jsonScript.so.textureResolution = 5;
                        QualitySettings.masterTextureLimit = 5;
                        break;
                    case 7:
                        jsonScript.so.textureResolution = 6;
                        QualitySettings.masterTextureLimit = 6;
                        break;
                }
                ShowArrows();
                ChangeTextureLevels();
            }
            if (optionsMode == 34)
            {
                //BGM Volume
                soundScript.PlayChangeMode();
                switch (jsonScript.so.BGMvol)
                {
                    case 0.125f:
                        jsonScript.so.BGMvol = 0.25f;
                        break;
                    case 0.25f:
                        jsonScript.so.BGMvol = 0.375f;
                        break;
                    case 0.375f:
                        jsonScript.so.BGMvol = 0.5f;
                        break;
                    case 0.5f:
                        jsonScript.so.BGMvol = 0.625f;
                        break;
                    case 0.625f:
                        jsonScript.so.BGMvol = 0.75f;
                        break;
                    case 0.75f:
                        jsonScript.so.BGMvol = 0.875f;
                        break;
                    case 0.875f:
                        jsonScript.so.BGMvol = 1;
                        break;
                }
                ShowArrows();
                ChangeBgmLevels();
            }
            if (optionsMode == 35)
            {
                //SFX Volume
                soundScript.PlayChangeMode();
                switch (jsonScript.so.SFXvol)
                {
                    case 0.125f:
                        jsonScript.so.SFXvol = 0.25f;
                        break;
                    case 0.25f:
                        jsonScript.so.SFXvol = 0.375f;
                        break;
                    case 0.375f:
                        jsonScript.so.SFXvol = 0.5f;
                        break;
                    case 0.5f:
                        jsonScript.so.SFXvol = 0.625f;
                        break;
                    case 0.625f:
                        jsonScript.so.SFXvol = 0.75f;
                        break;
                    case 0.75f:
                        jsonScript.so.SFXvol = 0.875f;
                        break;
                    case 0.875f:
                        jsonScript.so.SFXvol = 1;
                        break;
                }
                ShowArrows();
                ChangeSfxLevels();
            }
        }
        else if (controlsMenu)
        {
            if (optionsMode != 115 && optionsMode != 125 && optionsMode != 130 && optionsMode != 140)
            {
                Debug.Log("Right");
                img.enabled = false;
            }
            if (optionsMode == 111)
            {
                transform.position = P1jump.transform.position;
            }
            if (optionsMode == 112)
            {
                transform.position = P1dash.transform.position;
            }
            if (optionsMode == 113)
            {
                transform.position = P1teleport.transform.position;
            }
            if (optionsMode == 114)
            {
                transform.position = P1reset.transform.position;
            }
            if (optionsMode == 121)
            {
                transform.position = P2jump.transform.position;
            }
            if (optionsMode == 122)
            {
                transform.position = P2dash.transform.position;
            }
            if (optionsMode == 123)
            {
                transform.position = P2teleport.transform.position;
            }
            if (optionsMode == 124)
            {
                transform.position = P2reset.transform.position;
            }
        }
    }
    #endregion

    #region Read Mode On Collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Single)
        {
            optionsMode = 1;
            transform.localScale = initialSize;
        }
        if (other.gameObject == Multiplayer)
        {
            optionsMode = 2;
            transform.localScale = initialSize;
        }
        if (other.gameObject == Options)
        {
            jsonScript.Save();
            optionsMode = 7;
            transform.localScale = initialSize;
            ShowArrows();
            ChangeTextureLevels();
        }
        if (other.gameObject == Survival)
        {
            optionsMode = 11;
            transform.localScale = initialSize;
        }
        if (other.gameObject == Arcade)
        {
            optionsMode = 12;
            transform.localScale = initialSize;
        }
        if (other.gameObject == Gauntlet)
        {
            optionsMode = 13;
            transform.localScale = initialSize;
        }
        if (other.gameObject == Colosseum)
        {
            optionsMode = 20;
            transform.localScale = initialSize;
        }
        if (other.gameObject == Arena)
        {
            optionsMode = 21;
            transform.localScale = initialSize;
        }
        if (other.gameObject == Versus)
        {
            optionsMode = 22;
            transform.localScale = initialSize;
        }
        if (other.gameObject == Dodgeball)
        {
            optionsMode = 23;
            transform.localScale = initialSize;
        }
        if (other.gameObject == Control)
        {
            optionsMode = 24;
            transform.localScale = initialSize;
        }
        if (other.gameObject == screen)
        {
            optionsMode = 31;
            transform.localScale = doubleSize;
        }
        if (other.gameObject == resolutionX)
        {
            optionsMode = 32;
            transform.localScale = doubleSize;
        }
        if (other.gameObject == texture)
        {
            optionsMode = 33;
            transform.localScale = doubleSize;
        }
        if (other.gameObject == bgmVol)
        {
            optionsMode = 34;
            transform.localScale = doubleSize;
        }
        if (other.gameObject == sfxVol)
        {
            optionsMode = 35;
            transform.localScale = doubleSize;
        }
        if (other.gameObject == controls)
        {
            optionsMode = 36;
            transform.localScale = doubleSize;
        }
        if (other.gameObject == P2cm)
        {
            optionsMode = 40;
            transform.localScale = initialSize;
        }
        if (other.gameObject == P2a)
        {
            optionsMode = 42;
            transform.localScale = initialSize;
        }
        if (other.gameObject == P3a)
        {
            optionsMode = 43;
            transform.localScale = initialSize;
        }
        if (other.gameObject == P4a)
        {
            optionsMode = 44;
            transform.localScale = initialSize;
        }
        if (other.gameObject == P2v)
        {
            optionsMode = 52;
            transform.localScale = initialSize;
        }
        if (other.gameObject == P3v)
        {
            optionsMode = 53;
            transform.localScale = initialSize;
        }
        if (other.gameObject == P4v)
        {
            optionsMode = 54;
            transform.localScale = initialSize;
        }
        if (other.gameObject == P2d)
        {
            optionsMode = 62;
            transform.localScale = initialSize;
        }
        if (other.gameObject == P3d)
        {
            optionsMode = 63;
            transform.localScale = initialSize;
        }
        if (other.gameObject == P4d)
        {
            optionsMode = 64;
            transform.localScale = initialSize;
        }
        if (other.gameObject == P2c)
        {
            optionsMode = 72;
            transform.localScale = initialSize;
        }

        if (other.gameObject == P1move)
        {
            optionsMode = 111;
            transform.localScale = doubleSizeX2;
            img.enabled = true;
        }
        if (other.gameObject == P1jump)
        {
            optionsMode = 112;
            transform.localScale = doubleSize;
            img.enabled = true;
        }
        if (other.gameObject == P1dash)
        {
            optionsMode = 113;
            transform.localScale = doubleSize;
            img.enabled = true;
        }
        if (other.gameObject == P1teleport)
        {
            optionsMode = 114;
            transform.localScale = doubleSize;
            img.enabled = true;
        }
        if (other.gameObject == P1reset)
        {
            optionsMode = 115;
            transform.localScale = doubleSize;
            img.enabled = true;
        }
        if (other.gameObject == P2move)
        {
            optionsMode = 121;
            transform.localScale = doubleSizeX2;
            img.enabled = true;
        }
        if (other.gameObject == P2jump)
        {
            optionsMode = 122;
            transform.localScale = doubleSize;
            img.enabled = true;
        }
        if (other.gameObject == P2dash)
        {
            optionsMode = 123;
            transform.localScale = doubleSize;
            img.enabled = true;
        }
        if (other.gameObject == P2teleport)
        {
            optionsMode = 124;
            transform.localScale = doubleSize;
            img.enabled = true;
        }
        if (other.gameObject == P2reset)
        {
            optionsMode = 125;
            transform.localScale = doubleSize;
            img.enabled = true;
        }
        if (other.gameObject == save)
        {
            optionsMode = 130;
            transform.localScale = doubleSize;
            img.enabled = true;
        }
        if (other.gameObject == resetAll)
        {
            optionsMode = 140;
            transform.localScale = QuatroSize;
            img.enabled = true;
        }
        /*
        if (controlsMenu)
        {
            if (other.transform.gameObject.name == ("TriggerRebindButtonJ") || other.transform.gameObject.name == ("TriggerRebindButtonD") ||
                other.transform.gameObject.name == ("ResetToDefaultButton") ||
                other.transform.gameObject.name == ("Reset button") ||
                other.transform.gameObject.name == ("Keyboard Config") ||
                other.transform.gameObject.name == ("Gamepad Config") ||
                other.transform.gameObject.name == ("Exit"))
            {
                transform.localScale = doubleSize;
                Debug.Log("Enlarge");
            }
            if (other.transform.gameObject.name == ("TriggerRebindButtonM"))
            {
                transform.localScale = doubleSizeX2;
                Debug.Log("EnlargeX2");
            }
        }*/
    }
    #endregion

    #region Advance Mode
    public void AdvanceMode()
    {
        switch (optionsMode)
        {
            case 1:
                transform.position = Arcade.transform.position;
                soundScript.PlayChangeCategory();
                break;
            case 2:
                transform.position = Versus.transform.position;
                soundScript.PlayChangeCategory();
                break;
            case 7:
                transform.position = screen.transform.position;
                soundScript.PlayChangeCategory();
                break;
            case 11:
                jsonScript.so.levelNumber = "survival";
                SceneManager.LoadScene("Survival");
                soundScript.PlayModeSelect();
                break;
            case 12:
                SceneManager.LoadScene("Map Menu");
                soundScript.PlayModeSelect();
                break;
            case 13:
                jsonScript.so.levelNumber = "gauntlet";
                SceneManager.LoadScene("Gauntlet");
                soundScript.PlayModeSelect();
                break;
            case 20:
                transform.position = P2cm.transform.position;
                soundScript.PlayChangeCategory();
                break;
            case 21:
                transform.position = P2a.transform.position;
                soundScript.PlayChangeCategory();
                break;
            case 22:
                transform.position = P2v.transform.position;
                soundScript.PlayChangeCategory();
                break;
            case 23:
                transform.position = P2d.transform.position;
                soundScript.PlayChangeCategory();
                break;
            case 24:
                transform.position = P2c.transform.position;
                soundScript.PlayChangeCategory();
                break;
            case 36:
                //LOAD SCENE CONTROLS
                transform.position = P1move.transform.position;
                MainParent.SetActive(false);
                ControlParent.SetActive(true);
                controlsMenu = true;
                controlSwitch = false;
                soundScript.PlayModeSelect();
                break;
            case 40:
                //LOAD SCENE Colosseum 2P
                if (characterSwitcherScript.index >= 3)
                {
                    masterScript.multiplayerMode = 50;
                    SceneManager.LoadScene("Skin Select Multiplayer Menu");
                    soundScript.PlayModeSelect();
                }
                else
                {
                    soundScript.PlaySound("Drunk");
                    if (!warningLock)
                    {
                        StartCoroutine(PlayersWarning());
                    }
                }
                break;
            case 42:
                //LOAD SCENE ARENA 2P
                if (characterSwitcherScript.index >= 3)
                {
                    masterScript.multiplayerMode = 12;
                    SceneManager.LoadScene("Skin Select Multiplayer Menu");
                    soundScript.PlayModeSelect();
                }
                else
                {
                    soundScript.PlaySound("Drunk");
                    if (!warningLock)
                    {
                        StartCoroutine(PlayersWarning());
                    }
                }
                break;
            case 43:
                //LOAD SCENE ARENA 3P
                if (characterSwitcherScript.index >= 4)
                {
                    masterScript.multiplayerMode = 13;
                    SceneManager.LoadScene("Skin Select Multiplayer Menu");
                    soundScript.PlayModeSelect();
                }
                else
                {
                    soundScript.PlaySound("Drunk");
                    if (!warningLock)
                    {
                        StartCoroutine(PlayersWarning());
                    }
                }
                break;
            case 44:
                //LOAD SCENE ARENA 4P
                if (characterSwitcherScript.index >= 5)
                {
                    masterScript.multiplayerMode = 14;
                    SceneManager.LoadScene("Skin Select Multiplayer Menu");
                    soundScript.PlayModeSelect();
                }
                else
                {
                    soundScript.PlaySound("Drunk");
                    if (!warningLock)
                    {
                        StartCoroutine(PlayersWarning());
                    }
                }
                break;
            case 52:
                //LOAD SCENE VERSUS 2P
                if (characterSwitcherScript.index >= 3)
                {
                    masterScript.multiplayerMode = 22;
                    SceneManager.LoadScene("Skin Select Multiplayer Menu");
                    soundScript.PlayModeSelect();
                }
                else
                {
                    soundScript.PlaySound("Drunk");
                    if (!warningLock)
                    {
                        StartCoroutine(PlayersWarning());
                    }
                }
                break;
            case 53:
                //LOAD SCENE VERSUS 3P
                if (characterSwitcherScript.index >= 4)
                {
                    masterScript.multiplayerMode = 23;
                    SceneManager.LoadScene("Skin Select Multiplayer Menu");
                    soundScript.PlayModeSelect();
                }
                else
                {
                    soundScript.PlaySound("Drunk");
                    if (!warningLock)
                    {
                        StartCoroutine(PlayersWarning());
                    }
                }
                break;
            case 54:
                //LOAD SCENE VERSUS 4P
                if (characterSwitcherScript.index >= 5)
                {
                    masterScript.multiplayerMode = 24;
                    SceneManager.LoadScene("Skin Select Multiplayer Menu");
                    soundScript.PlayModeSelect();
                }
                else
                {
                    soundScript.PlaySound("Drunk");
                    if (!warningLock)
                    {
                        StartCoroutine(PlayersWarning());
                    }
                }
                break;
            case 62:
                //LOAD SCENE DODGEBALL 2P
                if (characterSwitcherScript.index >= 3)
                {
                    masterScript.multiplayerMode = 32;
                    SceneManager.LoadScene("Skin Select Multiplayer Menu");
                    soundScript.PlayModeSelect();
                }
                else
                {
                    soundScript.PlaySound("Drunk");
                    if (!warningLock)
                    {
                        StartCoroutine(PlayersWarning());
                    }
                }
                break;
            case 63:
                //LOAD SCENE DODGEBALL 3P
                if (characterSwitcherScript.index >= 4)
                {
                    masterScript.multiplayerMode = 33;
                    SceneManager.LoadScene("Skin Select Multiplayer Menu");
                    soundScript.PlayModeSelect();
                }
                else
                {
                    soundScript.PlaySound("Drunk");
                    if (!warningLock)
                    {
                        StartCoroutine(PlayersWarning());
                    }
                }
                break;
            case 64:
                //LOAD SCENE DODGEBALL 4P
                if (characterSwitcherScript.index >= 5)
                {
                    masterScript.multiplayerMode = 34;
                    SceneManager.LoadScene("Skin Select Multiplayer Menu");
                    soundScript.PlayModeSelect();
                }
                else
                {
                    soundScript.PlaySound("Drunk");
                    if (!warningLock)
                    {
                        StartCoroutine(PlayersWarning());
                    }
                }
                break;
            case 72:
                //LOAD SCENE CONTROL 2P
                if (characterSwitcherScript.index >= 3)
                {
                    masterScript.multiplayerMode = 42;
                    SceneManager.LoadScene("Skin Select Multiplayer Menu");
                    soundScript.PlayModeSelect();
                }
                else
                {
                    soundScript.PlaySound("Drunk");
                    if (!warningLock)
                    {
                        StartCoroutine(PlayersWarning());
                    }
                }
                break;
            case 111:
                P1Move.onClick.Invoke();
                break;
            case 112:
                P1Jump.onClick.Invoke();
                break;
            case 113:
                P1Dash.onClick.Invoke();
                break;
            case 114:
                P1Teleport.onClick.Invoke();
                break;
            case 115:
                P1ResetM.onClick.Invoke();
                P1ResetJ.onClick.Invoke();
                P1ResetD.onClick.Invoke();
                P1ResetT.onClick.Invoke();
                break;
            case 121:
                P2Move.onClick.Invoke();
                break;
            case 122:
                P2Jump.onClick.Invoke();
                break;
            case 123:
                P2Dash.onClick.Invoke();
                break;
            case 124:
                P2Teleport.onClick.Invoke();
                break;
            case 125:
                P2ResetM.onClick.Invoke();
                P2ResetJ.onClick.Invoke();
                P2ResetD.onClick.Invoke();
                P2ResetT.onClick.Invoke();
                break;
            case 130:
                Save.onClick.Invoke();
                break;
            case 140:
                ResetAll.onClick.Invoke();
                break;
        }
    }
    #endregion

    IEnumerator PlayersWarning()
    {
        warningLock = true;
        morePlayers.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        morePlayers.gameObject.SetActive(false);
        warningLock = false;
    }

    #region Return Mode
    public void ReturnMode()
    {
        switch (optionsMode)
        {
            case 11:
            case 12:
            case 13:
                transform.position = Single.transform.position;
                break;
            case 20:
            case 21:
            case 22:
            case 23:
            case 24:
                transform.position = Multiplayer.transform.position;
                break;
            case 31:
            case 32:
            case 33:
            case 34:
            case 35:
            case 36:
                transform.position = Options.transform.position;
                break;
            case 40:
                transform.position = Colosseum.transform.position;
                break;
            case 42:
            case 43:
            case 44:
                transform.position = Arena.transform.position;
                break;
            case 52:
            case 53:
            case 54:
                transform.position = Versus.transform.position;
                break;
            case 62:
            case 63:
            case 64:
                transform.position = Dodgeball.transform.position;
                break;
            case 72:
                transform.position = Control.transform.position;
                break;
        }
    }
    #endregion

    public void ReturnToOptions()
    {
        if (controlsMenu)
        {
            ResetAll.onClick.Invoke();
            StartCoroutine(ReturnC());
        }
    }

    IEnumerator ReturnC()
    {
        yield return new WaitForSeconds(0.1f);
        ReturnToMainMenu();
    }

    #region Decide which Buttons to show
    public void ButtonsView()
    {
        switch (optionsMode)
        {
            case 1:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 188);

                Arcade.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Survival.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Gauntlet.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                SingleMenu.SetActive(true);
                MultyMenu.SetActive(false);
                OptionsMenu.SetActive(false);
                P2cm.SetActive(false);
                P2a.SetActive(false);
                P3a.SetActive(false);
                P4a.SetActive(false);
                P2v.SetActive(false);
                P3v.SetActive(false);
                P4v.SetActive(false);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(false);
                break;
            case 2:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 188);

                Colosseum.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Arena.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Versus.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Dodgeball.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Control.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                SingleMenu.SetActive(false);
                MultyMenu.SetActive(true);
                OptionsMenu.SetActive(false);
                P2cm.SetActive(false);
                P2a.SetActive(false);
                P3a.SetActive(false);
                P4a.SetActive(false);
                P2v.SetActive(false);
                P3v.SetActive(false);
                P4v.SetActive(false);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(false);
                break;
            case 7:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

                screen.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                resolutionX.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                texture.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                bgmVol.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                sfxVol.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                controls.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                SingleMenu.SetActive(false);
                MultyMenu.SetActive(false);
                OptionsMenu.SetActive(true);
                P2cm.SetActive(false);
                P2a.SetActive(false);
                P3a.SetActive(false);
                P4a.SetActive(false);
                P2v.SetActive(false);
                P3v.SetActive(false);
                P4v.SetActive(false);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(false);
                break;
            case 11:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 99);

                Survival.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                Arcade.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Gauntlet.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                SingleMenu.SetActive(true);
                MultyMenu.SetActive(false);
                OptionsMenu.SetActive(false);
                P2cm.SetActive(false);
                P2a.SetActive(false);
                P3a.SetActive(false);
                P4a.SetActive(false);
                P2v.SetActive(false);
                P3v.SetActive(false);
                P4v.SetActive(false);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(false);
                break;
            case 12:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 99);

                Survival.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Arcade.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                Gauntlet.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                SingleMenu.SetActive(true);
                MultyMenu.SetActive(false);
                OptionsMenu.SetActive(false);
                P2cm.SetActive(false);
                P2a.SetActive(false);
                P3a.SetActive(false);
                P4a.SetActive(false);
                P2v.SetActive(false);
                P3v.SetActive(false);
                P4v.SetActive(false);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(false);
                break;
            case 13:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 99);

                Survival.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Arcade.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Gauntlet.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                SingleMenu.SetActive(true);
                MultyMenu.SetActive(false);
                OptionsMenu.SetActive(false);
                P2cm.SetActive(false);
                P2a.SetActive(false);
                P3a.SetActive(false);
                P4a.SetActive(false);
                P2v.SetActive(false);
                P3v.SetActive(false);
                P4v.SetActive(false);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(false);
                break;
            case 20:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 99);

                Colosseum.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                Arena.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Versus.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Dodgeball.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Control.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                SingleMenu.SetActive(false);
                MultyMenu.SetActive(true);
                OptionsMenu.SetActive(false);
                P2cm.SetActive(true);
                P2a.SetActive(false);
                P3a.SetActive(false);
                P4a.SetActive(false);
                P2v.SetActive(false);
                P3v.SetActive(false);
                P4v.SetActive(false);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(false);

                P2cm.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                break;
            case 21:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 99);

                Colosseum.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Arena.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                Versus.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Dodgeball.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Control.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                SingleMenu.SetActive(false);
                MultyMenu.SetActive(true);
                OptionsMenu.SetActive(false);
                P2cm.SetActive(false);
                P2a.SetActive(true);
                P3a.SetActive(true);
                P4a.SetActive(true);
                P2v.SetActive(false);
                P3v.SetActive(false);
                P4v.SetActive(false);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(false);

                P2a.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                P3a.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                P4a.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                break;
            case 22:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 99);

                Colosseum.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Arena.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Versus.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                Dodgeball.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Control.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                SingleMenu.SetActive(false);
                MultyMenu.SetActive(true);
                OptionsMenu.SetActive(false);
                P2cm.SetActive(false);
                P2a.SetActive(false);
                P3a.SetActive(false);
                P4a.SetActive(false);
                P2v.SetActive(true);
                P3v.SetActive(true);
                P4v.SetActive(true);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(false);

                P2v.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                P3v.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                P4v.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                break;
            case 23:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 99);

                Colosseum.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Arena.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Versus.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Dodgeball.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                Control.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                SingleMenu.SetActive(false);
                MultyMenu.SetActive(true);
                OptionsMenu.SetActive(false);
                P2cm.SetActive(false);
                P2a.SetActive(false);
                P3a.SetActive(false);
                P4a.SetActive(false);
                P2v.SetActive(false);
                P3v.SetActive(false);
                P4v.SetActive(false);
                P2d.SetActive(true);
                P3d.SetActive(true);
                P4d.SetActive(true);
                P2c.SetActive(false);

                P2d.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                P3d.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                P4d.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                break;
            case 24:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 99);

                Colosseum.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Arena.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Versus.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Dodgeball.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Control.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                SingleMenu.SetActive(false);
                MultyMenu.SetActive(true);
                OptionsMenu.SetActive(false);
                P2cm.SetActive(false);
                P2a.SetActive(false);
                P3a.SetActive(false);
                P4a.SetActive(false);
                P2v.SetActive(false);
                P3v.SetActive(false);
                P4v.SetActive(false);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(true);

                P2c.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                break;
            case 31:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 188);

                screen.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                resolutionX.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                texture.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                bgmVol.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                sfxVol.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                controls.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                SingleMenu.SetActive(false);
                MultyMenu.SetActive(false);
                OptionsMenu.SetActive(true);
                P2cm.SetActive(false);
                P2a.SetActive(false);
                P3a.SetActive(false);
                P4a.SetActive(false);
                P2v.SetActive(false);
                P3v.SetActive(false);
                P4v.SetActive(false);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(false);
                break;
            case 32:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 188);

                screen.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                resolutionX.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                texture.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                bgmVol.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                sfxVol.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                controls.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                SingleMenu.SetActive(false);
                MultyMenu.SetActive(false);
                OptionsMenu.SetActive(true);
                P2cm.SetActive(false);
                P2a.SetActive(false);
                P3a.SetActive(false);
                P4a.SetActive(false);
                P2v.SetActive(false);
                P3v.SetActive(false);
                P4v.SetActive(false);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(false);
                break;
            case 33:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 188);

                screen.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                resolutionX.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                texture.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                bgmVol.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                sfxVol.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                controls.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                SingleMenu.SetActive(false);
                MultyMenu.SetActive(false);
                OptionsMenu.SetActive(true);
                P2cm.SetActive(false);
                P2a.SetActive(false);
                P3a.SetActive(false);
                P4a.SetActive(false);
                P2v.SetActive(false);
                P3v.SetActive(false);
                P4v.SetActive(false);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(false);
                break;
            case 34:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 188);

                screen.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                resolutionX.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                texture.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                bgmVol.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                sfxVol.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                controls.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                SingleMenu.SetActive(false);
                MultyMenu.SetActive(false);
                OptionsMenu.SetActive(true);
                P2cm.SetActive(false);
                P2a.SetActive(false);
                P3a.SetActive(false);
                P4a.SetActive(false);
                P2v.SetActive(false);
                P3v.SetActive(false);
                P4v.SetActive(false);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(false);
                break;
            case 35:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 188);

                screen.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                resolutionX.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                texture.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                bgmVol.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                sfxVol.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                controls.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                SingleMenu.SetActive(false);
                MultyMenu.SetActive(false);
                OptionsMenu.SetActive(true);
                P2cm.SetActive(false);
                P2a.SetActive(false);
                P3a.SetActive(false);
                P4a.SetActive(false);
                P2v.SetActive(false);
                P3v.SetActive(false);
                P4v.SetActive(false);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(false);
                break;
            case 36:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 188);

                screen.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                resolutionX.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                texture.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                bgmVol.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                sfxVol.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                controls.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                SingleMenu.SetActive(false);
                MultyMenu.SetActive(false);
                OptionsMenu.SetActive(true);
                P2cm.SetActive(false);
                P2a.SetActive(false);
                P3a.SetActive(false);
                P4a.SetActive(false);
                P2v.SetActive(false);
                P3v.SetActive(false);
                P4v.SetActive(false);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(false);
                break;
            case 40:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 99);

                Colosseum.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Arena.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Versus.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Dodgeball.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Control.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                SingleMenu.SetActive(false);
                MultyMenu.SetActive(true);
                OptionsMenu.SetActive(false);
                P2cm.SetActive(true);
                P2a.SetActive(false);
                P3a.SetActive(false);
                P4a.SetActive(false);
                P2v.SetActive(false);
                P3v.SetActive(false);
                P4v.SetActive(false);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(false);

                P2cm.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                break;
            case 42:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 99);

                Colosseum.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Arena.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Versus.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Dodgeball.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Control.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                SingleMenu.SetActive(false);
                MultyMenu.SetActive(true);
                OptionsMenu.SetActive(false);
                P2cm.SetActive(false);
                P2a.SetActive(true);
                P3a.SetActive(true);
                P4a.SetActive(true);
                P2v.SetActive(false);
                P3v.SetActive(false);
                P4v.SetActive(false);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(false);

                P2a.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                P3a.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                P4a.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                break;
            case 43:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 99);

                Colosseum.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Arena.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Versus.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Dodgeball.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Control.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                SingleMenu.SetActive(false);
                MultyMenu.SetActive(true);
                OptionsMenu.SetActive(false);
                P2cm.SetActive(false);
                P2a.SetActive(true);
                P3a.SetActive(true);
                P4a.SetActive(true);
                P2v.SetActive(false);
                P3v.SetActive(false);
                P4v.SetActive(false);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(false);

                P2a.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                P3a.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                P4a.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                break;
            case 44:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 99);

                Colosseum.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Arena.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Versus.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Dodgeball.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Control.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                SingleMenu.SetActive(false);
                MultyMenu.SetActive(true);
                OptionsMenu.SetActive(false);
                P2cm.SetActive(false);
                P2a.SetActive(true);
                P3a.SetActive(true);
                P4a.SetActive(true);
                P2v.SetActive(false);
                P3v.SetActive(false);
                P4v.SetActive(false);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(false);

                P2a.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                P3a.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                P4a.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                break;
            case 52:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 99);

                Colosseum.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Arena.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Versus.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Dodgeball.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Control.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                SingleMenu.SetActive(false);
                MultyMenu.SetActive(true);
                OptionsMenu.SetActive(false);
                P2cm.SetActive(false);
                P2a.SetActive(false);
                P3a.SetActive(false);
                P4a.SetActive(false);
                P2v.SetActive(true);
                P3v.SetActive(true);
                P4v.SetActive(true);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(false);

                P2v.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                P3v.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                P4v.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                break;
            case 53:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 99);

                Colosseum.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Arena.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Versus.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Dodgeball.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Control.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                SingleMenu.SetActive(false);
                MultyMenu.SetActive(true);
                OptionsMenu.SetActive(false);
                P2cm.SetActive(false);
                P2a.SetActive(false);
                P3a.SetActive(false);
                P4a.SetActive(false);
                P2v.SetActive(true);
                P3v.SetActive(true);
                P4v.SetActive(true);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(false);

                P2v.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                P3v.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                P4v.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                break;
            case 54:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 99);

                Colosseum.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Arena.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Versus.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Dodgeball.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Control.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                SingleMenu.SetActive(false);
                MultyMenu.SetActive(true);
                OptionsMenu.SetActive(false);
                P2cm.SetActive(false);
                P2a.SetActive(false);
                P3a.SetActive(false);
                P4a.SetActive(false);
                P2v.SetActive(true);
                P3v.SetActive(true);
                P4v.SetActive(true);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(false);

                P2v.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                P3v.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                P4v.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                break;
            case 62:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 99);

                Colosseum.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Arena.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Versus.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Dodgeball.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Control.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                SingleMenu.SetActive(false);
                MultyMenu.SetActive(true);
                OptionsMenu.SetActive(false);
                P2cm.SetActive(false);
                P2a.SetActive(false);
                P3a.SetActive(false);
                P4a.SetActive(false);
                P2v.SetActive(false);
                P3v.SetActive(false);
                P4v.SetActive(false);
                P2d.SetActive(true);
                P3d.SetActive(true);
                P4d.SetActive(true);
                P2c.SetActive(false);

                P2d.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                P3d.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                P4d.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                break;
            case 72:
                Single.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Multiplayer.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                Options.GetComponent<Image>().color = new Color32(255, 255, 255, 99);

                Colosseum.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Arena.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Versus.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Dodgeball.GetComponent<Image>().color = new Color32(255, 255, 255, 99);
                Control.GetComponent<Image>().color = new Color32(255, 255, 255, 188);
                SingleMenu.SetActive(false);
                MultyMenu.SetActive(true);
                OptionsMenu.SetActive(false);
                P2cm.SetActive(false);
                P2a.SetActive(false);
                P3a.SetActive(false);
                P4a.SetActive(false);
                P2v.SetActive(false);
                P3v.SetActive(false);
                P4v.SetActive(false);
                P2d.SetActive(false);
                P3d.SetActive(false);
                P4d.SetActive(false);
                P2c.SetActive(true);

                P2c.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                break;
        }
    }
    #endregion

    public void ReturnToMainMenu()
    {
        MainParent.SetActive(true);
        ControlParent.SetActive(false);
        controlsMenu = false;
        transform.position = controls.transform.position;
    }

    #region Show Options Levels
    public void ChangeTextureLevels()
    {
        switch (jsonScript.so.textureResolution)
        {
            case 0:
                textureLevel1.SetActive(true);
                textureLevel2.SetActive(true);
                textureLevel3.SetActive(true);
                textureLevel4.SetActive(true);
                textureLevel5.SetActive(true);
                textureLevel6.SetActive(true);
                textureLevel7.SetActive(true);
                textureLevel8.SetActive(true);
                break;
            case 1:
                textureLevel1.SetActive(true);
                textureLevel2.SetActive(true);
                textureLevel3.SetActive(true);
                textureLevel4.SetActive(true);
                textureLevel5.SetActive(true);
                textureLevel6.SetActive(true);
                textureLevel7.SetActive(true);
                textureLevel8.SetActive(false);
                break;
            case 2:
                textureLevel1.SetActive(true);
                textureLevel2.SetActive(true);
                textureLevel3.SetActive(true);
                textureLevel4.SetActive(true);
                textureLevel5.SetActive(true);
                textureLevel6.SetActive(true);
                textureLevel7.SetActive(false);
                textureLevel8.SetActive(false);
                break;
            case 3:
                textureLevel1.SetActive(true);
                textureLevel2.SetActive(true);
                textureLevel3.SetActive(true);
                textureLevel4.SetActive(true);
                textureLevel5.SetActive(true);
                textureLevel6.SetActive(false);
                textureLevel7.SetActive(false);
                textureLevel8.SetActive(false);
                break;
            case 4:
                textureLevel1.SetActive(true);
                textureLevel2.SetActive(true);
                textureLevel3.SetActive(true);
                textureLevel4.SetActive(true);
                textureLevel5.SetActive(false);
                textureLevel6.SetActive(false);
                textureLevel7.SetActive(false);
                textureLevel8.SetActive(false);
                break;
            case 5:
                textureLevel1.SetActive(true);
                textureLevel2.SetActive(true);
                textureLevel3.SetActive(true);
                textureLevel4.SetActive(false);
                textureLevel5.SetActive(false);
                textureLevel6.SetActive(false);
                textureLevel7.SetActive(false);
                textureLevel8.SetActive(false);
                break;
            case 6:
                textureLevel1.SetActive(true);
                textureLevel2.SetActive(true);
                textureLevel3.SetActive(false);
                textureLevel4.SetActive(false);
                textureLevel5.SetActive(false);
                textureLevel6.SetActive(false);
                textureLevel7.SetActive(false);
                textureLevel8.SetActive(false);
                break;
            case 7:
                textureLevel1.SetActive(true);
                textureLevel2.SetActive(false);
                textureLevel3.SetActive(false);
                textureLevel4.SetActive(false);
                textureLevel5.SetActive(false);
                textureLevel6.SetActive(false);
                textureLevel7.SetActive(false);
                textureLevel8.SetActive(false);
                break;
        }
    }
    public void ChangeBgmLevels()
    {
        switch (jsonScript.so.BGMvol)
        {
            case 1:
                bgmLevel1.SetActive(true);
                bgmLevel2.SetActive(true);
                bgmLevel3.SetActive(true);
                bgmLevel4.SetActive(true);
                bgmLevel5.SetActive(true);
                bgmLevel6.SetActive(true);
                bgmLevel7.SetActive(true);
                bgmLevel8.SetActive(true);
                break;
            case 0.875f:
                bgmLevel1.SetActive(true);
                bgmLevel2.SetActive(true);
                bgmLevel3.SetActive(true);
                bgmLevel4.SetActive(true);
                bgmLevel5.SetActive(true);
                bgmLevel6.SetActive(true);
                bgmLevel7.SetActive(true);
                bgmLevel8.SetActive(false);
                break;
            case 0.75f:
                bgmLevel1.SetActive(true);
                bgmLevel2.SetActive(true);
                bgmLevel3.SetActive(true);
                bgmLevel4.SetActive(true);
                bgmLevel5.SetActive(true);
                bgmLevel6.SetActive(true);
                bgmLevel7.SetActive(false);
                bgmLevel8.SetActive(false);
                break;
            case 0.625f:
                bgmLevel1.SetActive(true);
                bgmLevel2.SetActive(true);
                bgmLevel3.SetActive(true);
                bgmLevel4.SetActive(true);
                bgmLevel5.SetActive(true);
                bgmLevel6.SetActive(false);
                bgmLevel7.SetActive(false);
                bgmLevel8.SetActive(false);
                break;
            case 0.5f:
                bgmLevel1.SetActive(true);
                bgmLevel2.SetActive(true);
                bgmLevel3.SetActive(true);
                bgmLevel4.SetActive(true);
                bgmLevel5.SetActive(false);
                bgmLevel6.SetActive(false);
                bgmLevel7.SetActive(false);
                bgmLevel8.SetActive(false);
                break;
            case 0.375f:
                bgmLevel1.SetActive(true);
                bgmLevel2.SetActive(true);
                bgmLevel3.SetActive(true);
                bgmLevel4.SetActive(false);
                bgmLevel5.SetActive(false);
                bgmLevel6.SetActive(false);
                bgmLevel7.SetActive(false);
                bgmLevel8.SetActive(false);
                break;
            case 0.25f:
                bgmLevel1.SetActive(true);
                bgmLevel2.SetActive(true);
                bgmLevel3.SetActive(false);
                bgmLevel4.SetActive(false);
                bgmLevel5.SetActive(false);
                bgmLevel6.SetActive(false);
                bgmLevel7.SetActive(false);
                bgmLevel8.SetActive(false);
                break;
            case 0.125f:
                bgmLevel1.SetActive(true);
                bgmLevel2.SetActive(false);
                bgmLevel3.SetActive(false);
                bgmLevel4.SetActive(false);
                bgmLevel5.SetActive(false);
                bgmLevel6.SetActive(false);
                bgmLevel7.SetActive(false);
                bgmLevel8.SetActive(false);
                break;
        }
    }
    public void ChangeSfxLevels()
    {
        switch (jsonScript.so.SFXvol)
        {
            case 1:
                sfxLevel1.SetActive(true);
                sfxLevel2.SetActive(true);
                sfxLevel3.SetActive(true);
                sfxLevel4.SetActive(true);
                sfxLevel5.SetActive(true);
                sfxLevel6.SetActive(true);
                sfxLevel7.SetActive(true);
                sfxLevel8.SetActive(true);
                break;
            case 0.875f:
                sfxLevel1.SetActive(true);
                sfxLevel2.SetActive(true);
                sfxLevel3.SetActive(true);
                sfxLevel4.SetActive(true);
                sfxLevel5.SetActive(true);
                sfxLevel6.SetActive(true);
                sfxLevel7.SetActive(true);
                sfxLevel8.SetActive(false);
                break;
            case 0.75f:
                sfxLevel1.SetActive(true);
                sfxLevel2.SetActive(true);
                sfxLevel3.SetActive(true);
                sfxLevel4.SetActive(true);
                sfxLevel5.SetActive(true);
                sfxLevel6.SetActive(true);
                sfxLevel7.SetActive(false);
                sfxLevel8.SetActive(false);
                break;
            case 0.625f:
                sfxLevel1.SetActive(true);
                sfxLevel2.SetActive(true);
                sfxLevel3.SetActive(true);
                sfxLevel4.SetActive(true);
                sfxLevel5.SetActive(true);
                sfxLevel6.SetActive(false);
                sfxLevel7.SetActive(false);
                sfxLevel8.SetActive(false);
                break;
            case 0.5f:
                sfxLevel1.SetActive(true);
                sfxLevel2.SetActive(true);
                sfxLevel3.SetActive(true);
                sfxLevel4.SetActive(true);
                sfxLevel5.SetActive(false);
                sfxLevel6.SetActive(false);
                sfxLevel7.SetActive(false);
                sfxLevel8.SetActive(false);
                break;
            case 0.375f:
                sfxLevel1.SetActive(true);
                sfxLevel2.SetActive(true);
                sfxLevel3.SetActive(true);
                sfxLevel4.SetActive(false);
                sfxLevel5.SetActive(false);
                sfxLevel6.SetActive(false);
                sfxLevel7.SetActive(false);
                sfxLevel8.SetActive(false);
                break;
            case 0.25f:
                sfxLevel1.SetActive(true);
                sfxLevel2.SetActive(true);
                sfxLevel3.SetActive(false);
                sfxLevel4.SetActive(false);
                sfxLevel5.SetActive(false);
                sfxLevel6.SetActive(false);
                sfxLevel7.SetActive(false);
                sfxLevel8.SetActive(false);
                break;
            case 0.125f:
                sfxLevel1.SetActive(true);
                sfxLevel2.SetActive(false);
                sfxLevel3.SetActive(false);
                sfxLevel4.SetActive(false);
                sfxLevel5.SetActive(false);
                sfxLevel6.SetActive(false);
                sfxLevel7.SetActive(false);
                sfxLevel8.SetActive(false);
                break;
        }
    }
    #endregion

    public void ShowArrows()
    {
        switch (jsonScript.so.screenModeType)
        {
            case 0:
                left.SetActive(false);
                right.SetActive(true);
                break;
            case 1:
                left.SetActive(true);
                right.SetActive(false);
                break;
        }

        if (jsonScript.so.resolutionType > 0)
        {
            right2.SetActive(true);
        }
        if (jsonScript.so.resolutionType < 4)
        {
            left2.SetActive(true);
        }
        if (jsonScript.so.resolutionType == 0)
        {
            right2.SetActive(false);
        }
        if (jsonScript.so.resolutionType == 4)
        {
            left2.SetActive(false);
        }

        if (jsonScript.so.textureResolution < 7)
        {
            left3.SetActive(true);
        }
        if (jsonScript.so.textureResolution == 7)
        {
            left3.SetActive(false);
        }
        if (jsonScript.so.textureResolution > 0)
        {
            right3.SetActive(true);
        }
        if (jsonScript.so.textureResolution == 0)
        {
            right3.SetActive(false);
        }

        if (jsonScript.so.BGMvol > 0.125f)
        {
            left4.SetActive(true);
        }
        if (jsonScript.so.BGMvol == 0.125f)
        {
            left4.SetActive(false);
        }
        if (jsonScript.so.BGMvol < 1)
        {
            right4.SetActive(true);
        }
        if (jsonScript.so.BGMvol == 1)
        {
            right4.SetActive(false);
        }

        if (jsonScript.so.SFXvol > 0.125f)
        {
            left5.SetActive(true);
        }
        if (jsonScript.so.SFXvol == 0.125f)
        {
            left5.SetActive(false);
        }
        if (jsonScript.so.SFXvol < 1)
        {
            right5.SetActive(true);
        }
        if (jsonScript.so.SFXvol == 1)
        {
            right5.SetActive(false);
        }
    }
}

