using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsScript : MonoBehaviour
{
    private MasterScript masterScript;
    private SaveTest jsonScript;
    public AudioSource audioSource;
    public AudioClip win, fall, jump, drunkPill, gameOver, hit1, hit2, hit3, chargeO, chargeL, dash, teleport, dizzy, shockWave,
        chMod, chCat, modSl, death, cheat, unlock;
    public float chargeOpLength;
    public float chargeLoopLength;

    // Start is called before the first frame update
    void Start()
    {
        masterScript = GameObject.Find("MASTER OBJECT").GetComponent<MasterScript>();
        jsonScript = GameObject.Find("MASTER OBJECT").GetComponent<SaveTest>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = chargeO;
        chargeOpLength = audioSource.clip.length;
    }

    private void Update()
    {
        audioSource.volume = jsonScript.so.SFXvol;
    }

    public void PlayChargeOpening()
    {
        audioSource.clip = chargeO;
        audioSource.Play();
    }
    public void PlayChargeLoop()
    {
        audioSource.clip = chargeL;
        audioSource.Play();
    }
    public void PlayDash()
    {
        audioSource.clip = dash;
        audioSource.Play();
    }
    public void PlayChangeMode()
    {
        audioSource.clip = chMod;
        audioSource.Play();
    }
    public void PlayChangeCategory()
    {
        audioSource.clip = chCat;
        audioSource.Play();
    }
    public void PlayModeSelect()
    {
        audioSource.clip = modSl;
        audioSource.Play();
    }
    public void SoundStop()
    {
        audioSource.Pause();
    }
    public void SoundResume()
    {
        audioSource.Play();
    }
    public void PlayDizzy()
    {
        audioSource.clip = dizzy;
        audioSource.Play();
    }
    #region Play Sound
    public void PlaySound (string sfx)
    {
        switch (sfx)
        {
            case "WinX" :
                audioSource.PlayOneShot(win);
                break;
            case "Fall" :
                audioSource.PlayOneShot(fall);
                break;
            case "Jump" :
                audioSource.PlayOneShot(jump);
                break;
            case "Dizzy":
                audioSource.PlayOneShot(dizzy);
                break;
            case "Drunk" :
                audioSource.PlayOneShot(drunkPill);
                break;
            case "GameOver" :
                audioSource.PlayOneShot(gameOver);
                break;
            case "Hit1" :
                audioSource.PlayOneShot(hit1);
                break;
            case "Hit2" :
                audioSource.PlayOneShot(hit2);
                break;
            case "Hit3" :
                audioSource.PlayOneShot(hit3);
                break;
            case "ChargeO":
                audioSource.PlayOneShot(chargeO);
                break;
            case "ChargeL":
                audioSource.PlayOneShot(chargeL);
                break;
            case "Dash":
                audioSource.PlayOneShot(dash);
                break;
            case "Teleport":
                audioSource.PlayOneShot(teleport);
                break;
            case "ShockWave":
                audioSource.PlayOneShot(shockWave);
                break;
            case "Death":
                audioSource.PlayOneShot(death);
                break;
            case "Yeah":
                audioSource.PlayOneShot(cheat);
                break;
            case "Unlock":
                audioSource.PlayOneShot(unlock);
                break;
        }
    }
    #endregion
}
