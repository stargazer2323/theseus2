using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    FMOD.Studio.EventInstance menuMusicEvent;
    FMOD.Studio.EventInstance startGameEvent;
    FMOD.Studio.EventInstance ambienceEvent;
    FMOD.Studio.EventInstance playerSteps;
    FMOD.Studio.EventInstance winMusic;
   
    FMOD.Studio.Bus titleBus;
    FMOD.Studio.Bus stepBus;


    [Tooltip("make this true if is main title scene")]
    public bool isTitleScene = false;
    [Tooltip("make this true if is Maze scene")]
    public bool isMaze = false;
    [Tooltip("make this true if is win scene")]
    public bool isWin = false;
    [Tooltip("make this true if is death scene")]
    public bool isLose = false;


    private void Start()
    {
        GetInstances();
        stepBus.setVolume(0);
        StartSounds();
    }
    
    public void StartSteps()
    {
        stepBus.setVolume(1);
    }

    public void StopSteps()
    {
        stepBus.setVolume(0);
    }

    public void StopMenuMusic()
    {
        startGameEvent.start();
        titleBus.setVolume(0);
    }

  
    public void StartSounds()
    {
        if (isTitleScene)
        {
            menuMusicEvent.start();
        }
        if (isMaze)
        {
            playerSteps.start();
            ambienceEvent.start();
        }
        if (isWin)
        {
            print("music");
            stepBus.setVolume(0);
            titleBus.setVolume(1);
            winMusic.start();
        }
        if (isLose)
        {
            stepBus.setVolume(0);
        }
    }


    public void GetInstances()
    {
        //busses
        titleBus = FMODUnity.RuntimeManager.GetBus("bus:/Title");
        stepBus = FMODUnity.RuntimeManager.GetBus("bus:/Walking");

        //events
        menuMusicEvent = FMODUnity.RuntimeManager.CreateInstance("event:/MenuMusic");
        startGameEvent = FMODUnity.RuntimeManager.CreateInstance("event:/StartGameUI");
        ambienceEvent = FMODUnity.RuntimeManager.CreateInstance("event:/Ambience");
        playerSteps = FMODUnity.RuntimeManager.CreateInstance("event:/PlayerSteps");
        winMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Win music");
    }

}
