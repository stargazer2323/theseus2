using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject footStepLights;
    public GameObject footStepRiddle;
    public Animator betterLuck;
    public Animator correct;

    public void WinGame()
    {
        SceneManager.LoadScene(2);
    }

    public void Die()
    {
        SceneManager.LoadScene(3);
    }
   
    public void OpenFootStepRiddle()
    {
        footStepRiddle.SetActive(true);
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

}
