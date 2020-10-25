using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator betterLuck;
    public Animator correct;
    [Header("Footstep")]
    public GameObject footStepLights;
    public GameObject footStepRiddle;
    public bool footStepTriggered;
    [Header("Fire")]
    public GameObject fireLights;
    public GameObject fireRiddle;
    public bool fireTriggered;
    [Header("Fire")]
    public GameObject mirrorLights;
    public GameObject mirrorRiddle;
    public bool mirrorTriggered;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }
    public void WinGame()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Die()
    {
        SceneManager.LoadScene(3);
    }

   //footstep riddle
    public void OpenFootStepRiddle()
    {
        if (!footStepTriggered)
        {
            footStepRiddle.SetActive(true);
            footStepTriggered = true;
        }
    }
    public void FootStepRiddleWin()
    {
        footStepRiddle.SetActive(false);
        footStepLights.SetActive(true);
        correct.SetTrigger("correct");
    }

    public void FootstepRiddleLose()
    {
        footStepRiddle.SetActive(false);
        betterLuck.SetTrigger("StartRunning");
    }

    //for the fire riddle
    public void OpenFireRiddle()
    {
        if (!fireTriggered)
        {
            fireRiddle.SetActive(true);
            fireTriggered = true;
        }
    }
    public void FireRiddleWin()
    {
        fireRiddle.SetActive(false);
       fireLights.SetActive(true);
        correct.SetTrigger("correct");
    }

    public void FireRiddleLose()
    {
        fireRiddle.SetActive(false);
        betterLuck.SetTrigger("StartRunning");
    }

    //for the mirror riddle
    public void OpenMirrorRiddle()
    {
        if (!mirrorTriggered)
        {
            mirrorRiddle.SetActive(true);
            mirrorTriggered = true;
        }
    }
    public void MirrorRiddleWin()
    {
        mirrorRiddle.SetActive(false);
        mirrorLights.SetActive(true);
        correct.SetTrigger("correct");
    }

    public void MirrorRiddleLose()
    {
        mirrorRiddle.SetActive(false);
        betterLuck.SetTrigger("StartRunning");
    }
}
