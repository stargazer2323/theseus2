using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject instructions;
    public AudioManager audioManager;

    private void Start()
    {
        
    }


    public void StartGame()
    {
        audioManager.StopMenuMusic();
        SceneManager.LoadScene(1);
    }

    public void OpenInstructions()
    {
        audioManager.InstructOpen();
        instructions.SetActive(true);
    }

    public void CloseInstructions()
    {
        audioManager.InstructClose();
        instructions.SetActive(false);
    }
}
