using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    public bool tutorialLevel;
    public int tutorialState;
    public GameObject tutorialBox1, tutorialBox2, tutorialBox3, tutorialBox4, tutorialBox5, tutorialBox6, tutorialBoxEnter, tutorialEnemy1, tutorialEnemy2,
        tEne3, tEne4, tEne5, tEne6, strengthItem1, strengthItem2, strengthItem3, strengthItem4, strengthItem5;
    public TextMeshProUGUI tutorialText1, tutorialText2, tutorialText3, tutorialText4, tutorialText5, tutorialText6;
    private SpawnManagerScript spawnManagerScript;
    bool whatTextShow;
    // Start is called before the first frame update
    void Start()
    {
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();

        StartCoroutine(ReadText());
    }

    IEnumerator ReadText()
    {
        yield return new WaitForSeconds(0.01f);
        //Get tutorial text
        if (tutorialLevel)
        {
            PlayerController playerScriptT = GameObject.Find("Player").GetComponent<PlayerController>();
            tutorialText1.text = "Welcome to Knockdown. First thing first, Use Movement Keys to move around. Default Keys are WASD & Left Analog Stick.";
            tutorialText2.text = "Enemies will appear on the map. You need to push them off the arena.";
            tutorialText3.text = "Some enemies are tougher. You need more strength in order to knock them down. " +
                "Press Shift or Triangle to check the balls strength values. Pick some fists to knock them harder.";
            tutorialText4.text = "When you find yourself surrounded just Jump. Use Jump Button to do it. Default Button is Num 2 & X.";
            tutorialText5.text = "Did you find an enemy that is too powerfull? Hold Dash Button to charge your strenght." +
                " and do a spinning dash towards him to blow him off the arena. Default Dash Button is Num 1 & Square";
            tutorialText6.text = "That's all. Go out there and kick some ass!";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Advance()
    {
        tutorialBox1.SetActive(false);
        tutorialBox2.SetActive(false);
        tutorialBox3.SetActive(false);
        tutorialBox4.SetActive(false);
        tutorialBox5.SetActive(false);
        tutorialBox6.SetActive(false);
        tutorialBoxEnter.SetActive(false);
        switch (tutorialState)
        {
            case 0:
                tutorialBox1.SetActive(false);
                tutorialBoxEnter.SetActive(false);
                tutorialState = 1;
                break;
            case 2:
                tutorialBox2.SetActive(false);
                tutorialBoxEnter.SetActive(false);
                tutorialEnemy1.SetActive(true);
                tutorialState = 3;
                break;
            case 4:
                tutorialBox3.SetActive(false);
                tutorialBoxEnter.SetActive(false);
                strengthItem1.SetActive(true);
                strengthItem2.SetActive(true);
                strengthItem3.SetActive(true);
                strengthItem4.SetActive(true);
                strengthItem5.SetActive(true);
                tutorialState = 5;
                break;
            case 6:
                tutorialBox4.SetActive(false);
                tutorialBoxEnter.SetActive(false);
                tEne3.SetActive(true);
                tEne4.SetActive(true);
                tEne5.SetActive(true);
                tutorialState = 7;
                break;
            case 11:
                tutorialBox5.SetActive(false);
                tutorialBoxEnter.SetActive(false);
                tEne6.SetActive(true);
                tutorialState = 12;
                break;
            case 13:
                tutorialBox6.SetActive(false);
                tutorialBoxEnter.SetActive(false);
                spawnManagerScript.UnlockNewLevel();
                SceneManager.LoadScene("Map Menu");
                break;

        }
    }


    public void TutorialEnemyPhase1()
    {
        tutorialBox2.SetActive(true);
        tutorialBoxEnter.SetActive(true);
    }
    public void TutorialEnemyPhase2()
    {
        tutorialEnemy2.SetActive(true);
        tutorialState = 4;
    }
    public void TutorialEnemyPhase3()
    {
        tutorialBox3.SetActive(true);
        tutorialBoxEnter.SetActive(true);
    }
    public void TutorialEnemyPhase4()
    {
        tutorialBox4.SetActive(true);
        tutorialBoxEnter.SetActive(true);
        tutorialState = 6;
    }
    public void TutorialEnemyPhase5()
    {
        tEne3.SetActive(false);
        tEne4.SetActive(false);
        tEne5.SetActive(false);
        tutorialBox5.SetActive(true);
        tutorialBoxEnter.SetActive(true);
        tutorialState = 11;
    }

    public void TutorialEndPhase()
    {
        tutorialBox6.SetActive(true);
        tutorialBoxEnter.SetActive(true);
        tutorialState = 13;
    }
}
