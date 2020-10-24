using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    FMOD.Studio.EventInstance menuMusicEvent;
    [Tooltip("make this true if is main title screen")]
    public bool isTitleScene = false;



    private void Start()
    {
        menuMusicEvent = FMODUnity.RuntimeManager.CreateInstance("event:/MenuMusic");
        if (isTitleScene)
        {
            menuMusicEvent.start();
        }
        
    }
    

    public void StopMenuMusic()
    {

        menuMusicEvent.release();
    }
}
