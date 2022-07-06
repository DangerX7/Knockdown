using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentScript : MonoBehaviour
{
    #region Game Objects and Scripts Read
    private GameObject Player, DizzyP;
    private SpawnManagerScript spawnManagerScript;
    private PlayerScript childScriptBase;
    private PlayerController childScriptControls;
    private EnergyScript energyScript;
    private DizzyParent dizzyScript;
    private SoundsScript soundScript;
    #endregion

    #region Clone Variable
    IEnumerator JumpClone;
    public int ballonSwitch;
    public int ballonCoroutineTimer;
    IEnumerator DrunkClone1;
    public int drunkSwitch1;
    public int drunkCoroutineTimer1;
    IEnumerator DrunkClone2;
    public int drunkSwitch2;
    public int drunkCoroutineTimer2;
    IEnumerator DrunkClone3;
    public int drunkSwitch3;
    public int drunkCoroutineTimer3;
    IEnumerator DrunkClone4;
    public int drunkSwitch4;
    public int drunkCoroutineTimer4;
    IEnumerator DrunkCloneAI;
    public int drunkSwitchAI;
    public int drunkCoroutineTimerAI;
    bool wasDrunkOnce;
    IEnumerator GauntletClone;
    public int gauntletSwitch;
    public int gauntletCoroutineTimer;
    IEnumerator DizzyClone;
    public int dizzySwitch;
    public int dizzyCoroutineTimer;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        #region Variables Set
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
        childScriptControls = transform.GetChild(0).gameObject.GetComponent<PlayerController>();
        childScriptBase = transform.GetChild(0).gameObject.GetComponent<PlayerScript>();
        energyScript = GameObject.Find("EnergyManager").GetComponent<EnergyScript>();
        soundScript = GameObject.Find("Sound").GetComponent<SoundsScript>();
        Player = transform.GetChild(0).gameObject;
        DizzyP = Player.transform.GetChild(0).gameObject;
        dizzyScript = DizzyP.GetComponent<DizzyParent>();
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
    //    Debug.Log(drunkCoroutineTimerAI + " " + drunkSwitchAI + " " +  spawnManagerScript.pauseCheck1);
        #region Clone Coroutines Settings
        if (ballonSwitch == 1)
        {
            JumpClone = JumpingTimerRoutine();
            ballonCoroutineTimer = 0;
            StartCoroutine(JumpClone);
            ballonSwitch = 2;
        }
        if (spawnManagerScript.pauseCheck1 == 1 && ballonSwitch == 2)
        {
            StopCoroutine(JumpClone);
        }
        if (spawnManagerScript.pauseCheck1 == 2 && ballonSwitch == 2)
        {
            StartCoroutine(JumpClone);
           spawnManagerScript.pauseCheck1 = 0;
        }


        if (drunkSwitch1 != 0)
        {
            DrunkClone1 = RegainControl1();
        }
        if (drunkSwitch1 == 1)
        {
            Debug.Log("Start1");
            if (drunkCoroutineTimer1 > 0)
            {
                drunkCoroutineTimer1 = 0;
            }
            else if (drunkCoroutineTimer1 == 0)
            {
                Debug.Log("StartCoroutine");
                StartCoroutine(DrunkClone1);
            }
            drunkSwitch1 = 2;
        }

        if (drunkSwitch2 != 0)
        {
            DrunkClone2 = RegainControl2();
        }
        if (drunkSwitch2 == 1)
        {
            Debug.Log("Start2");
            if (drunkCoroutineTimer2 > 0)
            {
                drunkCoroutineTimer2 = 0;
            }
            else if (drunkCoroutineTimer2 == 0)
            {
                Debug.Log("StartCoroutine");
                StartCoroutine(DrunkClone2);
            }
            drunkSwitch2 = 2;
        }

        if (drunkSwitch3 != 0)
        {
            DrunkClone3 = RegainControl3();
        }
        if (drunkSwitch3 == 1)
        {
            Debug.Log("Start3");
            if (drunkCoroutineTimer3 > 0)
            {
                drunkCoroutineTimer3 = 0;
            }
            else if (drunkCoroutineTimer3 == 0)
            {
                Debug.Log("StartCoroutine");
                StartCoroutine(DrunkClone3);
            }
            drunkSwitch3 = 2;
        }

        if (drunkSwitch4 != 0)
        {
            DrunkClone4 = RegainControl4();
        }
        if (drunkSwitch4 == 1)
        {
            Debug.Log("Start4");
            if (drunkCoroutineTimer4 > 0)
            {
                drunkCoroutineTimer4 = 0;
            }
            else if (drunkCoroutineTimer4 == 0)
            {
                Debug.Log("StartCoroutine");
                StartCoroutine(DrunkClone4);
            }
            drunkSwitch4 = 2;
        }

        if (drunkSwitchAI != 0)
        {
            DrunkCloneAI = RegainControlAI();
        }
        if (drunkSwitchAI == 1)
        {
            Debug.Log("Start1");
            if (drunkCoroutineTimerAI > 0)
            {
                drunkCoroutineTimerAI = 0;
            }
            else if (drunkCoroutineTimerAI == 0)
            {
                Debug.Log("StartCoroutine");
                StartCoroutine(DrunkCloneAI);
            }
            drunkSwitchAI = 2;
        }


        if (gauntletSwitch == 1)
        {
            GauntletClone = GauntletPower();
            gauntletCoroutineTimer = 0;
            StartCoroutine(GauntletClone);
            gauntletSwitch = 2;
        }
        if (spawnManagerScript.pauseCheck1 == 1 && gauntletSwitch == 2)
        {
            StopCoroutine(GauntletClone);
        }
        if (spawnManagerScript.pauseCheck1 == 2 && gauntletSwitch == 2)
        {
            StartCoroutine(GauntletClone);
          spawnManagerScript.pauseCheck1 = 0;
        }

        if (dizzySwitch == 1)
        {
            soundScript.PlayDizzy();
            DizzyClone = Recover();
            dizzyCoroutineTimer = 0;
            StartCoroutine(DizzyClone);
            dizzySwitch = 2;
        }
        if (spawnManagerScript.pauseCheck1 == 1 && dizzySwitch == 2)
        {
            soundScript.SoundStop();
            StopCoroutine(DizzyClone);
        }
        if (spawnManagerScript.pauseCheck1 == 2 && dizzySwitch == 2)
        {
            soundScript.SoundResume();
            Debug.Log("Resume1");
            StartCoroutine(DizzyClone);
            spawnManagerScript.pauseCheck1 = 0;
        }

        //lock strength
        if (gauntletSwitch == 2)
        {
            childScriptBase.strength = 800;
        }
        #endregion
    }


    #region Player Coroutines
    // Regain Control
    public IEnumerator InputRountine()
    {
        yield return new WaitForSeconds(0.5f);
        if (!childScriptControls.readStrength)
        {
         //   childScriptControls.inputLock = false;///////////////////////////////////////////////////////////C#
        }
    }

    // Deactivate jump
    public IEnumerator JumpingTimerRoutine()
    {
        while(ballonCoroutineTimer < 800)
        {
            yield return new WaitForSeconds(0.01f);
            ballonCoroutineTimer++;
        }
        childScriptControls.isJumpingAvailable = false;
        childScriptBase.jumpPowerupIndicator.gameObject.SetActive(false);
        ballonSwitch = 0;
    }

    // Recover from drunkness
    public IEnumerator RegainControl1()
    {
        while (drunkCoroutineTimer1 < 1000 && drunkSwitch1 != 0 && spawnManagerScript.pauseCheck1 != 1)
        {
            yield return new WaitForSeconds(0.01f);
            drunkCoroutineTimer1++;
            while (spawnManagerScript.pauseCheck1 == 1)
            {
                yield return new WaitForSeconds(0.01f);
            }
        }
        childScriptControls.drunk = false;
        drunkCoroutineTimer1 = 0;
        drunkSwitch1 = 0;
    }

    public IEnumerator RegainControl2()
    {
        while (drunkCoroutineTimer2 < 1000 && drunkSwitch2 != 0 && spawnManagerScript.pauseCheck2 != 1)
        {
            yield return new WaitForSeconds(0.01f);
            drunkCoroutineTimer2++;
            while (spawnManagerScript.pauseCheck2 == 1)
            {
                yield return new WaitForSeconds(0.01f);
            }
        }
        childScriptControls.drunk = false;
        drunkCoroutineTimer2 = 0;
        drunkSwitch2 = 0;
    }

    public IEnumerator RegainControl3()
    {
        while (drunkCoroutineTimer3 < 1000 && drunkSwitch3 != 0 && spawnManagerScript.pauseCheck3 != 1)
        {
            yield return new WaitForSeconds(0.01f);
            drunkCoroutineTimer3++;
            while (spawnManagerScript.pauseCheck3 == 1)
            {
                yield return new WaitForSeconds(0.01f);
            }
        }
        childScriptControls.drunk = false;
        drunkCoroutineTimer3 = 0;
        drunkSwitch3 = 0;
    }

    public IEnumerator RegainControl4()
    {
        while (drunkCoroutineTimer4 < 1000 && drunkSwitch4 != 0 && spawnManagerScript.pauseCheck4 != 1)
        {
            yield return new WaitForSeconds(0.01f);
            drunkCoroutineTimer4++;
            while (spawnManagerScript.pauseCheck4 == 1)
            {
                yield return new WaitForSeconds(0.01f);
            }
        }
        childScriptControls.drunk = false;
        drunkCoroutineTimer4 = 0;
        drunkSwitch4 = 0;
    }

    public IEnumerator RegainControlAI()
    {
        while (drunkCoroutineTimerAI < 500 && drunkSwitchAI != 0 && spawnManagerScript.pauseCheck1 != 1)
        {
            yield return new WaitForSeconds(0.01f);
            drunkCoroutineTimerAI++;
            while (spawnManagerScript.pauseCheck1 == 1)
            {
                yield return new WaitForSeconds(0.01f);
            }
        }
        childScriptBase.RecoverEnemyDrunk();
        drunkCoroutineTimerAI = 0;
        drunkSwitchAI = 0;
    }

    // Gauntlet code
    public IEnumerator GauntletPower()
    {
        childScriptBase.strength = 800;
        childScriptControls.speed *= 1.5f;
        childScriptBase.playerRenderer.material.SetColor("_Color", childScriptBase.angryColor);

        float time = 0.04f;
        if (GameObject.Find("Boss") != null)
        {
            time = 0.01f;
        }
        while (gauntletCoroutineTimer < 200)
        {

            yield return new WaitForSeconds(time);
            gauntletCoroutineTimer++;
        }
        childScriptBase.playerRenderer.material.color = Color.Lerp(childScriptBase.angryColor, childScriptBase.originalColor, Time.deltaTime * 20);
        while (gauntletCoroutineTimer < 250)
        {
            yield return new WaitForSeconds(0.05f);
            gauntletCoroutineTimer++;
        }
        spawnManagerScript.powerUpsOnScreen--;
        childScriptBase.strength = 1;
        childScriptControls.speed /= 1.5f;
        childScriptBase.playerRenderer.material.SetColor("_Color", childScriptBase.originalColor);
        gauntletSwitch = 0;
    }

    // Recover from dizziness
    public IEnumerator Recover()
    {
        while (dizzyCoroutineTimer < 120)
        {
            yield return new WaitForSeconds(0.01f);
            dizzyCoroutineTimer++;
        }
        switch (childScriptBase.playerNumber)
        {
            case 1:
                dizzyScript.MakeBallsDissapear1();
                energyScript.dizzy1 = false;
                break;
            case 2:

                dizzyScript.MakeBallsDissapear2();
                energyScript.dizzy2 = false;
                break;
            case 3:

                dizzyScript.MakeBallsDissapear3();
                energyScript.dizzy3 = false;
                break;
            case 4:

                dizzyScript.MakeBallsDissapear4();
                energyScript.dizzy4 = false;
                break;
        }
        dizzySwitch = 0;
    }
    #endregion

    public void ResetDrunkAI()
    {
    }
}

