using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    FMOD.Studio.EventInstance menuMusicEvent;
    FMOD.Studio.EventInstance startGameEvent;
    FMOD.Studio.EventInstance ambienceEvent;




    //busses
    FMOD.Studio.Bus TitleBus;



    [Tooltip("make this true if is main title scene")]
    public bool isTitleScene = false;
    [Tooltip("make this true if is Maze scene")]
    public bool isMaze = false;

    private void Start()
    {
        TitleBus = FMODUnity.RuntimeManager.GetBus("bus:/Title");
        menuMusicEvent = FMODUnity.RuntimeManager.CreateInstance("event:/MenuMusic");
        startGameEvent = FMODUnity.RuntimeManager.CreateInstance("event:/StartGameUI");
        ambienceEvent = FMODUnity.RuntimeManager.CreateInstance("");


        if (isTitleScene)
        {
            menuMusicEvent.start();
        }
        if (isMaze)
        {
            ambienceEvent.start();
        }
        
    }
    

    public void StopMenuMusic()
    {
        startGameEvent.start();
        TitleBus.setVolume(0);
    }
}
