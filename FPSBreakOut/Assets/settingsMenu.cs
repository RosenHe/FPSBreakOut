using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class settingsMenu : MonoBehaviour
{
    public AudioMixer am;
   public void SetVolume (float volume)
    {
        Debug.Log(volume);
        am.SetFloat("mainVol", volume);
    }
}
