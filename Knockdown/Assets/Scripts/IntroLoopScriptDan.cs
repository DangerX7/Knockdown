using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using E7.Introloop;

public class IntroLoopScriptDan : MonoBehaviour
{
    private MasterScript masterScript;
    private SaveTest jsonScript;
    private AudioSource track1, track2, track3, track4;
    private bool firstSearch;
    [SerializeField] private int trackNumber;
    [SerializeField] private IntroloopAudio Chapter_1;
    [SerializeField] private IntroloopAudio Chapter_2;
    [SerializeField] private IntroloopAudio Chapter_3;
    [SerializeField] private IntroloopAudio Chapter_4;
    [SerializeField] private IntroloopAudio Chapter_5;
    [SerializeField] private IntroloopAudio Control;
    [SerializeField] private IntroloopAudio Dodgeball;
    [SerializeField] private IntroloopAudio Gauntlet;
    [SerializeField] private IntroloopAudio Map_Inclinate;
    [SerializeField] private IntroloopAudio Rotating_Map_Levels_And_Arcade;
    [SerializeField] private IntroloopAudio Boss_1;
    [SerializeField] private IntroloopAudio Boss_2;
    [SerializeField] private IntroloopAudio Boss_3;
    [SerializeField] private IntroloopAudio Boss_4;
    [SerializeField] private IntroloopAudio Boss_5;
    [SerializeField] private IntroloopAudio Boss_5X;
    [SerializeField] private IntroloopAudio Boss_G;
    [SerializeField] private IntroloopAudio Boss_S;
    [SerializeField] private IntroloopAudio Map_And_Skin_Menu;
    [SerializeField] private IntroloopAudio Title_Screen;
    [SerializeField] private IntroloopAudio Extra;
    [SerializeField] private IntroloopAudio Credits;


    [SerializeField] private IntroloopAudio maidBattle;

    [Space]
    [SerializeField] private IntroloopAudio assault;

    [Range(0, 2f)] [SerializeField] private float assaultFade;

    [Space] [SerializeField] private IntroloopAudio compete;

    [Range(0, 2f)] [SerializeField] private float competeFade;

    [Space]
    [Tooltip("This is not connected to anything in the scene, but to the prefab asset that" +
             "has AudioSource on it as a template. Now it is easy to adjust your template " +
             "from the Project pane.")]
    [SerializeField] private AudioSource templateForDemoSubclassPlayer;
    public void Awake()
    {
        masterScript = GameObject.Find("MASTER OBJECT").GetComponent<MasterScript>();
        jsonScript = GameObject.Find("MASTER OBJECT").GetComponent<SaveTest>();
        if (!jsonScript.so.dontRestartMusic)
        {
            switch (trackNumber)
            {
                case 1:
                    Chapter1Bgm();
                    break;
                case 2:
                    Chapter2Bgm();
                    break;
                case 3:
                    Chapter3Bgm();
                    break;
                case 4:
                    Chapter4Bgm();
                    break;
                case 5:
                    Chapter5Bgm();
                    break;
                case 6:
                    ControlBgm();
                    break;
                case 7:
                    DodgeballBgm();
                    break;
                case 8:
                    GauntletBgm();
                    break;
                case 9:
                    Map_InclinateBgm();
                    break;
                case 10:
                    Rotating_Map_Levels_And_ArcadeBgm();
                    break;
                case 11:
                    Boss_1Bgm();
                    break;
                case 12:
                    Boss_2Bgm();
                    break;
                case 13:
                    Boss_3Bgm();
                    break;
                case 14:
                    Boss_4Bgm();
                    break;
                case 15:
                    Boss_5Bgm();
                    break;
                case 16:
                    Boss_GBgm();
                    break;
                case 17:
                    Boss_SBgm();
                    break;
                case 18:
                    Map_And_Skin_MenuBgm();
                    break;
                case 19:
                    Title_ScreenBgm();
                    break;
                case 20:
                    ExtraBgm();
                    break;
                case 21:
                    EndingCredits();
                    break;
            }
        }
        jsonScript.Save();
    }

    private void Update()
    {
        if (!firstSearch)
        {
            if (GameObject.Find("AudioSource 1x") == null)
            {
                track1 = GameObject.Find("AudioSource 1").GetComponent<AudioSource>();
                track1.name = "AudioSource 1x";
            }
            else
            {
                track1 = GameObject.Find("AudioSource 1x").GetComponent<AudioSource>();
            }
            track2 = GameObject.Find("AudioSource 1").GetComponent<AudioSource>();
            if (GameObject.Find("AudioSource 2x") == null)
            {
                track3 = GameObject.Find("AudioSource 2").GetComponent<AudioSource>();
                track3.name = "AudioSource 2x";
            }
            else
            {
                track3 = GameObject.Find("AudioSource 2x").GetComponent<AudioSource>();
            }
            track4 = GameObject.Find("AudioSource 2").GetComponent<AudioSource>();
            firstSearch = true;
        }
        track1.volume = jsonScript.so.BGMvol;
        track2.volume = jsonScript.so.BGMvol;
        track3.volume = jsonScript.so.BGMvol;
        track4.volume = jsonScript.so.BGMvol;
    }

    #region BGM Play Methods
    public void Chapter1Bgm()
    {
        IntroloopPlayer.Instance.Play(Chapter_1);
    }

    public void Chapter2Bgm()
    {
        IntroloopPlayer.Instance.Play(Chapter_2);
    }

    public void Chapter3Bgm()
    {
        IntroloopPlayer.Instance.Play(Chapter_3);
    }

    public void Chapter4Bgm()
    {
        IntroloopPlayer.Instance.Play(Chapter_4);
    }

    public void Chapter5Bgm()
    {
        IntroloopPlayer.Instance.Play(Chapter_5);
    }

    public void ControlBgm()
    {
        IntroloopPlayer.Instance.Play(Control);
    }

    public void DodgeballBgm()
    {
        IntroloopPlayer.Instance.Play(Dodgeball);
    }

    public void GauntletBgm()
    {
        IntroloopPlayer.Instance.Play(Gauntlet);
    }

    public void Map_And_Skin_MenuBgm()
    {
        IntroloopPlayer.Instance.Play(Map_And_Skin_Menu);
    }

    public void Map_InclinateBgm()
    {
        IntroloopPlayer.Instance.Play(Map_Inclinate);
    }

    public void Rotating_Map_Levels_And_ArcadeBgm()
    {
        IntroloopPlayer.Instance.Play(Rotating_Map_Levels_And_Arcade);
    }

    public void Title_ScreenBgm()
    {
        IntroloopPlayer.Instance.Play(Title_Screen);
    }

    public void Boss_1Bgm()
    {
        IntroloopPlayer.Instance.Play(Boss_1);
    }

    public void Boss_2Bgm()
    {
        IntroloopPlayer.Instance.Play(Boss_2);
    }

    public void Boss_3Bgm()
    {
        IntroloopPlayer.Instance.Play(Boss_3);
    }

    public void Boss_4Bgm()
    {
        IntroloopPlayer.Instance.Play(Boss_4);
    }

    public void Boss_5Bgm()
    {
        IntroloopPlayer.Instance.Play(Boss_5);
    }
    public void Boss_5BgmX()
    {
        IntroloopPlayer.Instance.Play(Boss_5X);
    }

    public void Boss_GBgm()
    {
        IntroloopPlayer.Instance.Play(Boss_G);
    }

    public void Boss_SBgm()
    {
        IntroloopPlayer.Instance.Play(Boss_S);
    }

    public void ExtraBgm()
    {
        IntroloopPlayer.Instance.Play(Extra);
    }

    public void EndingCredits()
    {
        IntroloopPlayer.Instance.Play(Credits);
    }
    #endregion


    public void PauseBgm()
    {
        IntroloopPlayer.Instance.Pause();
    }

    public void ResumeBgm()
    {
        IntroloopPlayer.Instance.Resume();
    }

    public void StopBgm()
    {
        IntroloopPlayer.Instance.Stop();
    }
}
