using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDash : MonoBehaviour
{
    public GameObject dust, trail, boss;
    private SpawnManagerScript spawnManagerScript;
    public EnemyScript enemyScript;
    IEnumerator DashClone, DashClone2;
    public int dashCoroutineTimer, dashCoroutineTimer2;
    public int dashSwitch;
    public byte chargeSoundState;
    public Rigidbody rb;
    public byte dashDirrection = 0;
    private SoundsScript soundScript;
    bool didRushSoundPlayed;
    bool firstRush;
    bool lockIncrease;
    // Start is called before the first frame update
    void Start()
    {
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
        soundScript = GameObject.Find("Sound").GetComponent<SoundsScript>();
        dashSwitch = -1;
    }

    private void FixedUpdate()
    {
        if (dashSwitch == 3)
        {
            dust.gameObject.SetActive(true);
            dust.transform.position = new Vector3(boss.transform.position.x, boss.transform.position.y - 0.5f, boss.transform.position.z);
        }
        else
        {
            dust.gameObject.SetActive(false);
        }

        if (dashSwitch == 4)
        {
            trail.gameObject.SetActive(true);
            trail.transform.position = transform.position;
        }
        else
        {
            trail.gameObject.SetActive(false);
        }

     //   Debug.Log(dashCoroutineTimer2 + " " + dashCoroutineTimer);
        //Start spinning enter timer
        if (dashSwitch == -1)
        {
            Debug.Log("1x");
            DashClone2 = SpinStart();
            dashCoroutineTimer2 = 0;
            if (!firstRush)
            {
                dashCoroutineTimer2 = 440;
                firstRush = true;
            }
            StartCoroutine(DashClone2);
            dashSwitch = 1;
        }
        if (spawnManagerScript.pauseCheck1 == 1)
        {
            lockIncrease = true;
        //    StopCoroutine(DashClone2);
        }
        if (spawnManagerScript.pauseCheck1 == 2 && dashSwitch == 1)
        {
            lockIncrease = false;
         //   StartCoroutine(DashClone2);
            spawnManagerScript.pauseCheck1 = 0;
        }

        //Start dashing enter timer
        if (dashSwitch == 2)
        {
            DashClone = DashStart();
            dashCoroutineTimer = 0;
            StartCoroutine(DashClone);
            dashSwitch = 3;
        }
        if (spawnManagerScript.pauseCheck1 == 1)
        {
            lockIncrease = true;
        //    StopCoroutine(DashClone);
        }
        if (spawnManagerScript.pauseCheck1 == 2 && dashSwitch == 3)
        {
            lockIncrease = false;
        //    StartCoroutine(DashClone);
            spawnManagerScript.pauseCheck1 = 0;
        }

        //Spinning
        if (dashSwitch == 3)
        {
            if (chargeSoundState == 0 || chargeSoundState == 1)
            {
                StartCoroutine(ChargeOSoundCoroutine());
            }
            if (chargeSoundState == 2)
            {
                StartCoroutine(ChargeLSoundCoroutine());
            }
        }

        //Dash Mode
        if (dashSwitch == 4)
        {
            chargeSoundState = 0;
            rb.AddForce(enemyScript.lookDirrection * 50, ForceMode.Impulse);
            StartCoroutine(DashEndCoroutine());
        }
    }

    public IEnumerator SpinStart()
    {
    /////////    dust.gameObject.SetActive(true);
        while (dashCoroutineTimer2 < 500)
        {
            yield return new WaitForSeconds(0.1f);
            if (!lockIncrease)
            {
                dashCoroutineTimer2++;
            }
        }
        enemyScript.inputLock = true;
        dashSwitch = 2;
    }
    public IEnumerator DashStart()
    {
     ///////   dust.gameObject.SetActive(false);
      //////  trail.gameObject.SetActive(true);
        while (dashCoroutineTimer < 20)
        {
            yield return new WaitForSeconds(0.1f);
            if (!lockIncrease)
            {
                dashCoroutineTimer++;
            }
        }
        dashSwitch = 4;
    }

    IEnumerator ChargeOSoundCoroutine()//Play First Charge Sound
    {
        if (chargeSoundState == 0)
        {
            //    soundScript.PlaySound("ChargeO");
            soundScript.PlayChargeOpening();
            chargeSoundState = 1;
        }
        yield return new WaitForSeconds(soundScript.chargeOpLength);
        if (chargeSoundState == 1)
        {
            chargeSoundState = 2;
        }
    }
    IEnumerator ChargeLSoundCoroutine()//Play Loop Charge Sound
    {
        if (chargeSoundState == 2)
        {
            //   soundScript.PlaySound("ChargeL");
            soundScript.PlayChargeLoop();
            chargeSoundState = 3;
        }
        yield return new WaitForSeconds(soundScript.chargeOpLength);
        if (chargeSoundState == 3)
        {
            chargeSoundState = 2;
        }
    }

    IEnumerator DashEndCoroutine()//End Dash and Play Dash Sound
    {
        if (!didRushSoundPlayed)
        {
            //    soundScript.PlaySound("Dash");
            soundScript.PlayDash();
            didRushSoundPlayed = true;
        }
        yield return new WaitForSeconds(0.5f);
        //  rb.velocity = Vector3.zero;
        didRushSoundPlayed = false;
        enemyScript.inputLock = false;
      ///////  trail.gameObject.SetActive(false);
        dashSwitch = -1;
        yield return new WaitForSeconds(0.5f);
    }
}
