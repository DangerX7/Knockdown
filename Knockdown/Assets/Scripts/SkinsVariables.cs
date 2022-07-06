using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class SkinsVariables : MonoBehaviour
{
    public GameObject costTextObj, diamondObj, infinity;
    private MasterScript masterScript;
    private SaveTest jsonScript;
    public TextMeshProUGUI strengthText, speedText, energyText, costText;
    public string cost;
    public int strength;
    public int speed;
    public int energy;
    public int price = 0;

    private void Start()
    {
        if (GameObject.Find("MASTER OBJECT") != null)
        {
            masterScript = GameObject.Find("MASTER OBJECT").GetComponent<MasterScript>();
            jsonScript = GameObject.Find("MASTER OBJECT").GetComponent<SaveTest>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        strengthText.text = "" + strength;
        speedText.text = "" + speed;
        if (jsonScript.so.playerSkin !=130)
        {
            energyText.text = "" + energy;
            infinity.SetActive(false);
        }
        else
        {
            energyText.text = "";
            infinity.SetActive(true);
        }
        costText.text = cost;
        #region Skin Info
        switch (jsonScript.so.playerSkin)
        {
            case 1:
                cost = "0";
                costTextObj.SetActive(false);
                diamondObj.SetActive(false);
                strength = 50;
                speed = 100;
                energy = 100;
                break;
            case 2:
                cost = "Finish Level 1";
                costTextObj.SetActive(true);
                diamondObj.SetActive(false);
                strength = 30;
                speed = 125;
                energy = 90;
                break;
            case 3:
                price = 100;
                cost = "Buy it for " + price;
                costTextObj.SetActive(true);
                diamondObj.SetActive(true);
                strength = 100;
                speed = 80;
                energy = 110;
                break;
            case 4:
                price = 400;
                cost = "Buy it for " + price;
                costTextObj.SetActive(true);
                diamondObj.SetActive(true);
                strength = 40;
                speed = 160;
                energy = 80;
                break;
            case 5:
                price = 500;
                cost = "Buy it for " + price;
                costTextObj.SetActive(true);
                diamondObj.SetActive(true);
                strength = 80;
                speed = 120;
                energy = 120;
                break;
            case 6:
                price = 800;
                cost = "Buy it for " + price;
                costTextObj.SetActive(true);
                diamondObj.SetActive(true);
                strength = 60;
                speed = 200;
                energy = 100;
                break;
            case 7:
                price = 1000;
                cost = "Buy it for " + price;
                costTextObj.SetActive(true);
                diamondObj.SetActive(true);
                strength = 150;
                speed = 100;
                energy = 70;
                break;
            case 8:
                price = 1200;
                cost = "Buy it for " + price;
                costTextObj.SetActive(true);
                diamondObj.SetActive(true);
                strength = 100;
                speed = 120;
                energy = 110;
                break;
            case 9:
                price = 2000;
                cost = "Buy it for " + price;
                costTextObj.SetActive(true);
                diamondObj.SetActive(true);
                strength = 200;
                speed = 200;
                energy = 200;
                break;
            case 10:
                cost = "Defeat Boss 1";
                costTextObj.SetActive(true);
                diamondObj.SetActive(false);
                strength = 200;
                speed = 60;
                energy = 140;
                break;
            case 11:
                cost = "Defeat Boss 2";
                costTextObj.SetActive(true);
                diamondObj.SetActive(false);
                strength = 120;
                speed = 120;
                energy = 150;
                break;
            case 12:
                cost = "Defeat Boss 3";
                costTextObj.SetActive(true);
                diamondObj.SetActive(false);
                strength = 300;
                speed = 40;
                energy = 60;
                break;
            case 13:
                cost = "Defeat Boss 4";
                costTextObj.SetActive(true);
                diamondObj.SetActive(false);
                strength = 160;
                speed = 140;
                energy = 180;
                break;
            case 14:
                cost = "Defeat Boss 5";
                costTextObj.SetActive(true);
                diamondObj.SetActive(false);
                strength = 220;
                speed = 180;
                energy = 250;
                break;
            case 15:
                cost = "Defeat Survival Boss";
                costTextObj.SetActive(true);
                diamondObj.SetActive(false);
                strength = 300;
                speed = 100;
                energy = 160;
                break;
            case 16:
                cost = "Defeat Gauntlet Boss";
                costTextObj.SetActive(true);
                diamondObj.SetActive(false);
                strength = 40;
                speed = 300;
                energy = 220;
                break;
            case 101:
                price = 3000;
                cost = "Buy it for " + price;
                costTextObj.SetActive(true);
                diamondObj.SetActive(true);
                strength = 200;
                speed = 240;
                energy = 300;
                break;
            case 102:
                price = 1800;
                cost = "Buy it for " + price;
                costTextObj.SetActive(true);
                diamondObj.SetActive(true);
                strength = 230;
                speed = 100;
                energy = 150;
                break;
            case 103:
                price = 2300;
                cost = "Buy it for " + price;
                costTextObj.SetActive(true);
                diamondObj.SetActive(true);
                strength = 100;
                speed = 300;
                energy = 140;
                break;
            case 104:
                price = 4000;
                cost = "Buy it for " + price;
                costTextObj.SetActive(true);
                diamondObj.SetActive(true);
                strength = 220;
                speed = 220;
                energy = 500;
                break;
            case 111:
                price = 5000;
                cost = "Buy it for " + price;
                costTextObj.SetActive(true);
                diamondObj.SetActive(true);
                strength = 300;
                speed = 300;
                energy = 300;
                break;
            case 112:
                price = 2400;
                cost = "Buy it for " + price;
                costTextObj.SetActive(true);
                diamondObj.SetActive(true);
                strength = 260;
                speed = 200;
                energy = 240;
                break;
            case 121:
                price = 1600;
                cost = "Buy it for " + price;
                costTextObj.SetActive(true);
                diamondObj.SetActive(true);
                strength = 140;
                speed = 220;
                energy = 210;
                break;
            case 122:
                price = 600;
                cost = "Buy it for " + price;
                costTextObj.SetActive(true);
                diamondObj.SetActive(true);
                strength = 90;
                speed = 110;
                energy = 150;
                break;
            case 123:
                price = 300;
                cost = "Buy it for " + price;
                costTextObj.SetActive(true);
                diamondObj.SetActive(true);
                strength = 88;
                speed = 90;
                energy = 90;
                break;
            case 124:
                price = 1400;
                cost = "Buy it for " + price;
                costTextObj.SetActive(true);
                diamondObj.SetActive(true);
                strength = 150;
                speed = 170;
                energy = 190;
                break;
            case 125:
                price = 3600;
                cost = "Buy it for " + price;
                costTextObj.SetActive(true);
                diamondObj.SetActive(true);
                strength = 360;
                speed = 140;
                energy = 200;
                break;
            case 126:
                price = 2700;
                cost = "Buy it for " + price;
                costTextObj.SetActive(true);
                diamondObj.SetActive(true);
                strength = 400;
                speed = 40;
                energy = 100;
                break;
            case 127:
                price = 1100;
                cost = "Buy it for " + price;
                costTextObj.SetActive(true);
                diamondObj.SetActive(true);
                strength = 90;
                speed = 150;
                energy = 320;
                break;
            case 128:
                price = 2200;
                cost = "Buy it for " + price;
                costTextObj.SetActive(true);
                diamondObj.SetActive(true);
                strength = 210;
                speed = 170;
                energy = 250;
                break;
            case 129:
                price = 3300;
                cost = "Buy it for " + price;
                costTextObj.SetActive(true);
                diamondObj.SetActive(true);
                strength = 180;
                speed = 340;
                energy = 180;
                break;
            case 130:
                price = 10000;
                cost = "Buy it for " + price;
                costTextObj.SetActive(true);
                diamondObj.SetActive(true);
                strength = 320;
                speed = 260;
                energy = 0;
                break;
        }
        #endregion
    }
}
