﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject footStepLights;
    public GameObject footStepRiddle;
    public Animator betterLuck;


    public void WinGame()
    {
        SceneManager.LoadScene(2);
    }

    public void Die()
    {
        SceneManager.LoadScene(3);
    }
   

    public void FootStepRiddleWin()
    {
        footStepRiddle.SetActive(false);
        footStepLights.SetActive(true);
    }

    public void FootstepRiddleLose()
    {
        footStepRiddle.SetActive(false);
        betterLuck.SetTrigger("");
    }

}
