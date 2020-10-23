using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    FMOD.Studio.EventInstance menuMusicEvent;
    public bool isTitleScene = false;



    private void Start()
    {
        menuMusicEvent = FMODUnity.RuntimeManager.CreateInstance("event:/MenuMusic");
    
    }
    public void PlayMenuMusic()
    {
        menuMusicEvent.start();
    }

    public void StopMenuMusic()
    {

        menuMusicEvent.release();
    }
}
