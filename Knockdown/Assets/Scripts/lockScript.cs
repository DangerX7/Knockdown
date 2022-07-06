using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lockScript : MonoBehaviour
{
    public Image img;
    private MasterScript masterScript;
    private SaveTest jsonScript;
    private multiplayerMenuControls menuCommands;
    public bool centerLock;
    public int playerNumber;
    // Start is called before the first frame update
    void Start()
    {
        masterScript = GameObject.Find("MASTER OBJECT").GetComponent<MasterScript>();
        jsonScript = GameObject.Find("MASTER OBJECT").GetComponent<SaveTest>();
        menuCommands = GameObject.Find("Manager").GetComponent<multiplayerMenuControls>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        #region Lock Enter
        if (centerLock)
        {
            switch (other.transform.gameObject.name)
            {
                case "s1":
                    UnlockEnter();

                    break;
                case "s2":
                    if (jsonScript.so.isSkin2Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s3":
                    if (jsonScript.so.isSkin3Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s4":
                    if (jsonScript.so.isSkin4Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s5":
                    if (jsonScript.so.isSkin5Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s6":
                    if (jsonScript.so.isSkin6Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s7":
                    if (jsonScript.so.isSkin7Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s8":
                    if (jsonScript.so.isSkin8Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s9":
                    if (jsonScript.so.isSkin9Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s10":
                    if (jsonScript.so.isSkin10Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s11":
                    if (jsonScript.so.isSkin11Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s12":
                    if (jsonScript.so.isSkin12Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s13":
                    if (jsonScript.so.isSkin13Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s14":
                    if (jsonScript.so.isSkin14Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s15":
                    if (jsonScript.so.isSkin15Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s16":
                    if (jsonScript.so.isSkin16Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s17":
                    if (jsonScript.so.isSkin101Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s18":
                    if (jsonScript.so.isSkin18Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s19":
                    if (jsonScript.so.isSkin19Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s20":
                    if (jsonScript.so.isSkin20Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s21":
                    if (jsonScript.so.isSkin21Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s22":
                    if (jsonScript.so.isSkin22Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s23":
                    if (jsonScript.so.isSkin23Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s24":
                    if (jsonScript.so.isSkin24Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s25":
                    if (jsonScript.so.isSkin25Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s26":
                    if (jsonScript.so.isSkin26Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s27":
                    if (jsonScript.so.isSkin27Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s28":
                    if (jsonScript.so.isSkin28Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s29":
                    if (jsonScript.so.isSkin29Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s30":
                    if (jsonScript.so.isSkin30Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s31":
                    if (jsonScript.so.isSkin31Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s32":
                    if (jsonScript.so.isSkin32Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s33":
                    if (jsonScript.so.isSkin33Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s34":
                    if (jsonScript.so.isSkin34Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s35":
                    if (jsonScript.so.isSkin35Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s36":
                    if (jsonScript.so.isSkin36Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s37":
                    if (jsonScript.so.isSkin37Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s38":
                    if (jsonScript.so.isSkin38Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s39":
                    if (jsonScript.so.isSkin39Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s40":
                    if (jsonScript.so.isSkin40Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s41":
                    if (jsonScript.so.isSkin41Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s42":
                    if (jsonScript.so.isSkin42Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s43":
                    if (jsonScript.so.isSkin43Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s44":
                    if (jsonScript.so.isSkin44Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s45":
                    if (jsonScript.so.isSkin45Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s46":
                    if (jsonScript.so.isSkin46Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s47":
                    if (jsonScript.so.isSkin47Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s48":
                    if (jsonScript.so.isSkin48Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s49":
                    if (jsonScript.so.isSkin49Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s50":
                    if (jsonScript.so.isSkin50Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s51":
                    if (jsonScript.so.isSkin51Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s52":
                    if (jsonScript.so.isSkin52Available)
                    {
                        UnlockEnter();
                        
                    }
                    else
                    {
                        LockEnter();
                        
                    }
                    break;
                case "s53":
                    if (jsonScript.so.isSkin104Available)
                    {
                        UnlockEnter();

                    }
                    else
                    {
                        LockEnter();

                    }
                    break;
                case "s54":
                    if (jsonScript.so.isSkin105Available)
                    {
                        UnlockEnter();

                    }
                    else
                    {
                        LockEnter();

                    }
                    break;
                case "s55":
                    if (jsonScript.so.isSkin106Available)
                    {
                        UnlockEnter();

                    }
                    else
                    {
                        LockEnter();

                    }
                    break;
                case "s56":
                    if (jsonScript.so.isSkin102Available)
                    {
                        UnlockEnter();

                    }
                    else
                    {
                        LockEnter();

                    }
                    break;
                case "s57":
                    if (jsonScript.so.isSkin107Available)
                    {
                        UnlockEnter();

                    }
                    else
                    {
                        LockEnter();

                    }
                    break;
                case "s58":
                    if (jsonScript.so.isSkin108Available)
                    {
                        UnlockEnter();

                    }
                    else
                    {
                        LockEnter();

                    }
                    break;
                case "s59":
                    if (jsonScript.so.isSkin109Available)
                    {
                        UnlockEnter();

                    }
                    else
                    {
                        LockEnter();

                    }
                    break;
                case "s60":
                    if (jsonScript.so.isSkin110Available)
                    {
                        UnlockEnter();

                    }
                    else
                    {
                        LockEnter();

                    }
                    break;
                case "s61":
                    if (jsonScript.so.isSkin103Available)
                    {
                        UnlockEnter();

                    }
                    else
                    {
                        LockEnter();

                    }
                    break;
            }
        }
        #endregion

        #region Enable/Dissable Image
        switch (other.transform.gameObject.name)
        {
            case "s1":
                
                img.enabled = false;
                break;
            case "s2":
                if (jsonScript.so.isSkin2Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s3":
                if (jsonScript.so.isSkin3Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s4":
                if (jsonScript.so.isSkin4Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s5":
                if (jsonScript.so.isSkin5Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s6":
                if (jsonScript.so.isSkin6Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s7":
                if (jsonScript.so.isSkin7Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s8":
                if (jsonScript.so.isSkin8Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s9":
                if (jsonScript.so.isSkin9Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s10":
                if (jsonScript.so.isSkin10Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s11":
                if (jsonScript.so.isSkin11Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s12":
                if (jsonScript.so.isSkin12Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s13":
                if (jsonScript.so.isSkin13Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s14":
                if (jsonScript.so.isSkin14Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s15":
                if (jsonScript.so.isSkin15Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s16":
                if (jsonScript.so.isSkin16Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s17":
                if (jsonScript.so.isSkin101Available)
                {

                    img.enabled = false;
                }
                else
                {

                    img.enabled = true;
                }
                break;
            case "s18":
                if (jsonScript.so.isSkin18Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s19":
                if (jsonScript.so.isSkin19Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s20":
                if (jsonScript.so.isSkin20Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s21":
                if (jsonScript.so.isSkin21Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s22":
                if (jsonScript.so.isSkin22Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s23":
                if (jsonScript.so.isSkin23Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s24":
                if (jsonScript.so.isSkin24Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s25":
                if (jsonScript.so.isSkin25Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s26":
                if (jsonScript.so.isSkin26Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s27":
                if (jsonScript.so.isSkin27Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s28":
                if (jsonScript.so.isSkin28Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s29":
                if (jsonScript.so.isSkin29Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s30":
                if (jsonScript.so.isSkin30Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s31":
                if (jsonScript.so.isSkin31Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s32":
                if (jsonScript.so.isSkin32Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s33":
                if (jsonScript.so.isSkin33Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s34":
                if (jsonScript.so.isSkin34Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s35":
                if (jsonScript.so.isSkin35Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s36":
                if (jsonScript.so.isSkin36Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s37":
                if (jsonScript.so.isSkin37Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s38":
                if (jsonScript.so.isSkin38Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s39":
                if (jsonScript.so.isSkin39Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s40":
                if (jsonScript.so.isSkin40Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s41":
                if (jsonScript.so.isSkin41Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s42":
                if (jsonScript.so.isSkin42Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s43":
                if (jsonScript.so.isSkin43Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s44":
                if (jsonScript.so.isSkin44Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s45":
                if (jsonScript.so.isSkin45Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s46":
                if (jsonScript.so.isSkin46Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s47":
                if (jsonScript.so.isSkin47Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s48":
                if (jsonScript.so.isSkin48Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s49":
                if (jsonScript.so.isSkin49Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s50":
                if (jsonScript.so.isSkin50Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s51":
                if (jsonScript.so.isSkin51Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s52":
                if (jsonScript.so.isSkin52Available)
                {
                    
                    img.enabled = false;
                }
                else
                {
                    
                    img.enabled = true;
                }
                break;
            case "s53":
                if (jsonScript.so.isSkin104Available)
                {

                    img.enabled = false;
                }
                else
                {

                    img.enabled = true;
                }
                break;
            case "s54":
                if (jsonScript.so.isSkin105Available)
                {

                    img.enabled = false;
                }
                else
                {

                    img.enabled = true;
                }
                break;
            case "s55":
                if (jsonScript.so.isSkin106Available)
                {

                    img.enabled = false;
                }
                else
                {

                    img.enabled = true;
                }
                break;
            case "s56":
                if (jsonScript.so.isSkin102Available)
                {

                    img.enabled = false;
                }
                else
                {

                    img.enabled = true;
                }
                break;
            case "s57":
                if (jsonScript.so.isSkin107Available)
                {

                    img.enabled = false;
                }
                else
                {

                    img.enabled = true;
                }
                break;
            case "s58":
                if (jsonScript.so.isSkin108Available)
                {

                    img.enabled = false;
                }
                else
                {

                    img.enabled = true;
                }
                break;
            case "s59":
                if (jsonScript.so.isSkin109Available)
                {

                    img.enabled = false;
                }
                else
                {

                    img.enabled = true;
                }
                break;
            case "s60":
                if (jsonScript.so.isSkin110Available)
                {

                    img.enabled = false;
                }
                else
                {

                    img.enabled = true;
                }
                break;
            case "s61":
                if (jsonScript.so.isSkin103Available)
                {

                    img.enabled = false;
                }
                else
                {

                    img.enabled = true;
                }
                break;
        }
        #endregion
    }

    public void LockEnter()
    {
        switch (playerNumber)
        {
            case 1:
                menuCommands.lockEnter1 = true;
                break;
            case 2:
                menuCommands.lockEnter2 = true;
                break;
            case 3:
                menuCommands.lockEnter3 = true;
                break;
            case 4:
                menuCommands.lockEnter4 = true;
                break;
        }
    }
    public void UnlockEnter()
    {
        switch (playerNumber)
        {
            case 1:
                menuCommands.lockEnter1 = false;
                break;
            case 2:
                menuCommands.lockEnter2 = false;
                break;
            case 3:
                menuCommands.lockEnter3 = false;
                break;
            case 4:
                menuCommands.lockEnter4 = false;
                break;
        }
    }
}
