using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class MusicScript : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip track1Op, track2Op, bossTrackOp, versusTrackOp, gauntletTrackOp;
    public GameObject track1Loop, track2Loop, bossTrackLoop, versusTrackLoop, gauntletTrackLoop;
    public int trackNumber;
    public bool hasIntroPlayed;
    public bool bossHasAppeared;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        #region Set Opening Track
        track1Op = Resources.Load<AudioClip>("track_1_OP");
        track2Op = Resources.Load<AudioClip>("track_2_OP");
        bossTrackOp = Resources.Load<AudioClip>("boss_track_OP");
        versusTrackOp = Resources.Load<AudioClip>("versus_track_OP");
        gauntletTrackOp = Resources.Load<AudioClip>("gauntlet_OP");

        switch (trackNumber)
        {
            case 1:
                audioSource.clip = track1Op;
                break;
            case 2:
                audioSource.clip = track2Op;
                break;
            case 3:
                audioSource.clip = bossTrackOp;
                break;
            case 4:
                audioSource.clip = versusTrackOp;
                break;
            case 5:
                audioSource.clip = gauntletTrackOp;
                break;
        }
        #endregion

        audioSource.Play();
        Invoke("IntroCut", audioSource.clip.length);
    }

    #region Set Loop Track
    private void IntroCut()
    {
            switch (trackNumber)
            {
                case 1:
                track1Loop.gameObject.SetActive(true);
                    break;
                case 2:
                track2Loop.gameObject.SetActive(true);
                    break;
                case 3:
                bossTrackLoop.gameObject.SetActive(true);
                    break;
                case 4:
                versusTrackLoop.gameObject.SetActive(true);
                    break;
                case 5:
                gauntletTrackLoop.gameObject.SetActive(true);
                    break;
        }
    }
    #endregion

    private void Update()
    {
        if (bossHasAppeared)
        {
            track1Loop.gameObject.SetActive(false);
            track2Loop.gameObject.SetActive(false);
            bossTrackLoop.gameObject.SetActive(true);
            versusTrackLoop.gameObject.SetActive(false);
        }
    }

}
