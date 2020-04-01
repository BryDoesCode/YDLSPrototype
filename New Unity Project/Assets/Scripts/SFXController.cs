using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public AudioClip showerSFX;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    public void SFXPlayer (string sfxName)
    {
        switch (sfxName)
        {
            case "showerSFX":
                audioSource.PlayOneShot(showerSFX);
                Debug.Log("Played Shower SFX");
                break;
            default:
                Debug.Log("Unkown SFX: " + sfxName);
                break;
        }
    }

}
