using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnergyScript : MonoBehaviour
{
    #region Variables Set
    private SpawnManagerScript spawnManagerScript;
    private MasterScript masterScript;
    private SoundsScript soundScript;
    public EnergyBar energyBar1, energyBar2, energyBar3, energyBar4;
    public TextMeshProUGUI energyText1, energyText2, energyText3, energyText4;
    public float maxEnergy1 = 150;
    public float currentEnergy1 = 150;
    public float maxEnergy2 = 150;
    public float currentEnergy2 = 150;
    public float maxEnergy3 = 150;
    public float currentEnergy3 = 150;
    public float maxEnergy4 = 150;
    public float currentEnergy4 = 150;
    public bool setEnergy;
    public bool dizzy1;
    public int dizzySoundCheck1;
    public bool dizzy2;
    public int dizzySoundCheck2;
    public bool dizzy3;
    public int dizzySoundCheck3;
    public bool dizzy4;
    public int dizzySoundCheck4;
    public bool destroyCheck;

    private GameObject player1, player2, player3, player4;
    private PlayerScript playerScript1, playerScript2, playerScript3, playerScript4;
    #endregion

    private void Start()
    {
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
        if (GameObject.Find("MASTER OBJECT") != null)
        {
            masterScript = GameObject.Find("MASTER OBJECT").GetComponent<MasterScript>();
        }
        soundScript = GameObject.Find("Sound").GetComponent<SoundsScript>();
    }
    // Update is called once per frame
    void Update()
    {
        #region Remove Energy Bars
        // Remove energy bars and texts for 2 and 3 players modes
        if (!destroyCheck)
        {
            switch (masterScript.multiplayerMode)
            {
                case 12:
                case 22:
                case 42:
                case 50:
                    Destroy(energyBar3.gameObject);
                    Destroy(energyBar4.gameObject);
                    Destroy(energyText3.gameObject);
                    Destroy(energyText4.gameObject);
                    break;
                case 13:
                case 23:
                    Destroy(energyBar4.gameObject);
                    Destroy(energyText4.gameObject);
                    break;
                case 32:
                case 33:
                case 34:
                    Destroy(energyBar1.gameObject);
                    Destroy(energyBar2.gameObject);
                    Destroy(energyBar3.gameObject);
                    Destroy(energyBar4.gameObject);
                    Destroy(energyText1.gameObject);
                    Destroy(energyText2.gameObject);
                    Destroy(energyText3.gameObject);
                    Destroy(energyText4.gameObject);
                    break;
            }
            destroyCheck = true;
        }
        #endregion

        #region Read Energy Values
        if (setEnergy)
        {
            currentEnergy1 = maxEnergy1;
            currentEnergy2 = maxEnergy2;
            currentEnergy3 = maxEnergy3;
            currentEnergy4 = maxEnergy4;
            energyBar1.SetMaxEnergy(maxEnergy1);
            if (masterScript.multiplayerMode > 0)
            {
                energyBar2.SetMaxEnergy(maxEnergy2);
                energyBar3.SetMaxEnergy(maxEnergy3);
                energyBar4.SetMaxEnergy(maxEnergy4);
            }
            setEnergy = false;
        }
        #endregion

        #region Check For Dizzy Sound
        if (dizzy1 && dizzySoundCheck1 == 0)
        {
        /////////    soundScript.PlaySound("Dizzy");
        //    soundScript.PlayDizzy();
            dizzySoundCheck1 = 1;
        }
        if (dizzySoundCheck1 == 1 && spawnManagerScript.isGamePaused)
        {
         //   soundScript.SoundStop();
            dizzySoundCheck1 = 2;
        }
        if (dizzySoundCheck1 == 2 && !spawnManagerScript.isGamePaused)
        {
         //   soundScript.SoundResume();
            dizzySoundCheck1 = 1;
        }

        if(!dizzy1)
        {
            dizzySoundCheck2 = 0;
        }
        if (dizzy2 && dizzySoundCheck2 == 0)
        {
       ////////////     soundScript.PlaySound("Dizzy");
            //   soundScript.PlayDizzy();
            dizzySoundCheck2 = 1;
        }
        if (dizzySoundCheck2 == 1 && spawnManagerScript.isGamePaused)
        {
          //  soundScript.SoundStop();
            dizzySoundCheck2 = 2;
        }
        if (dizzySoundCheck2 == 2 && !spawnManagerScript.isGamePaused)
        {
         //   soundScript.SoundResume();
            dizzySoundCheck2 = 1;
        }
        if (!dizzy2)
        {
            dizzySoundCheck2 = 0;
        }

        if (dizzy3 && dizzySoundCheck3 == 0)
        {
        ////////    soundScript.PlaySound("Dizzy");
            //   soundScript.PlayDizzy();
            dizzySoundCheck3 = 1;
        }
        if (dizzySoundCheck3 == 1 && spawnManagerScript.isGamePaused)
        {
        //    soundScript.SoundStop();
            dizzySoundCheck3 = 2;
        }
        if (dizzySoundCheck3 == 2 && !spawnManagerScript.isGamePaused)
        {
          //  soundScript.SoundResume();
            dizzySoundCheck3 = 1;
        }
        if (!dizzy3)
        {
            dizzySoundCheck3 = 0;
        }

        if (dizzy4 && dizzySoundCheck4 == 0)
        {
        /////////    soundScript.PlaySound("Dizzy");
            //   soundScript.PlayDizzy();
            dizzySoundCheck4 = 1;
        }
        if (dizzySoundCheck4 == 1 && spawnManagerScript.isGamePaused)
        {
          //  soundScript.SoundStop();
            dizzySoundCheck4 = 2;
        }
        if (dizzySoundCheck4 == 2 && !spawnManagerScript.isGamePaused)
        {
         //   soundScript.SoundResume();
            dizzySoundCheck4 = 1;
        }
        if (!dizzy4)
        {
            dizzySoundCheck4 = 0;
        }
        #endregion
    }
    void FixedUpdate()
    {
        #region Find and Read PLayer Data
        //Find Players
        player1 = GameObject.Find("Player");
        if (masterScript.multiplayerMode > 0)
        {
            player2 = GameObject.Find("Player 2");
        }
        if (masterScript.multiplayerMode == 13 || masterScript.multiplayerMode == 14 ||
            masterScript.multiplayerMode == 23 || masterScript.multiplayerMode == 24)
        {
            player3 = GameObject.Find("Player 3");
        }
        if (masterScript.multiplayerMode == 14 || masterScript.multiplayerMode == 24)
        {
            player4 = GameObject.Find("Player 4");
        }
        //Get players scripts
        if (player1 != null)
        {
            playerScript1 = player1.GetComponent<PlayerScript>();
        }
        if (player2 != null)
        {
            playerScript2 = player2.GetComponent<PlayerScript>();
        }
        if (player3 != null)
        {
            playerScript3 = player3.GetComponent<PlayerScript>();
        }
        if (player4 != null)
        {
            playerScript4 = player4.GetComponent<PlayerScript>();
        }
        #endregion

        #region Energy Recover
        //Increase Energy
        if (currentEnergy1 < maxEnergy1 && !dizzy1 && !spawnManagerScript.isGamePaused && !playerScript1.dead)
        {
            currentEnergy1 += 2f * Time.deltaTime * maxEnergy1 / 100;
        }
        energyBar1.SetEnergy(currentEnergy1);

        if (masterScript.multiplayerMode > 0)
        {
            if (currentEnergy2 < maxEnergy2 && !dizzy2 && !spawnManagerScript.isGamePaused && !playerScript2.dead)
            {
                currentEnergy2 += 2f * Time.deltaTime * maxEnergy2 / 100;
            }
            energyBar2.SetEnergy(currentEnergy2);
        }

        if (masterScript.multiplayerMode == 13 || masterScript.multiplayerMode == 14 ||
            masterScript.multiplayerMode == 23 || masterScript.multiplayerMode == 24)
        {
            if (currentEnergy3 < maxEnergy3 && !dizzy3 && !spawnManagerScript.isGamePaused && !playerScript3.dead)
            {
                currentEnergy3 += 2f * Time.deltaTime * maxEnergy3 / 100;
            }
            energyBar3.SetEnergy(currentEnergy3);
        }

        if (masterScript.multiplayerMode == 14 || masterScript.multiplayerMode == 24)
        {
            if (currentEnergy4 < maxEnergy4 && !dizzy4 && !spawnManagerScript.isGamePaused && !playerScript4.dead)
            {
                currentEnergy4 += 2f * Time.deltaTime * maxEnergy4 / 100;
            }
            energyBar4.SetEnergy(currentEnergy4);
        }
        #endregion
    }

    #region Energy Reduce
    public void DecreaseEnergy1(float loss)
    {
        if (currentEnergy1 > 0)
        {
            currentEnergy1 -= loss;
        }
        //   energyBar.SetEnergy(currentEnergy);
    }
    public void DecreaseEnergy2(float loss)
    {
        if (currentEnergy2 > 0)
        {
            currentEnergy2 -= loss;
        }
    }
    public void DecreaseEnergy3(float loss)
    {
        if (currentEnergy3 > 0)
        {
            currentEnergy3 -= loss;
        }
    }
    public void DecreaseEnergy4(float loss)
    {
        if (currentEnergy4 > 0)
        {
            currentEnergy4 -= loss;
        }
    }
    #endregion

}
