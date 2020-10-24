using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    FMOD.Studio.EventInstance menuMusicEvent;
    FMOD.Studio.EventInstance startGameEvent;
    FMOD.Studio.EventInstance ambienceEvent;
    FMOD.Studio.EventInstance playerSteps;
    
    




    //busses
    FMOD.Studio.Bus titleBus;
    FMOD.Studio.Bus stepBus;


    [Tooltip("make this true if is main title scene")]
    public bool isTitleScene = false;
    [Tooltip("make this true if is Maze scene")]
    public bool isMaze = false;

    private void Start()
    {
        titleBus = FMODUnity.RuntimeManager.GetBus("bus:/Title");
        stepBus = FMODUnity.RuntimeManager.GetBus("bus:/Walking");
        stepBus.setVolume(0);
        menuMusicEvent = FMODUnity.RuntimeManager.CreateInstance("event:/MenuMusic");
        startGameEvent = FMODUnity.RuntimeManager.CreateInstance("event:/StartGameUI");
        ambienceEvent = FMODUnity.RuntimeManager.CreateInstance("event:/Ambience");
        playerSteps = FMODUnity.RuntimeManager.CreateInstance("event:/PlayerSteps");
        
        if (isTitleScene)
        {
            menuMusicEvent.start();
        }
        if (isMaze)
        {
            playerSteps.start();
           ambienceEvent.start();
        }
        
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

  
}
