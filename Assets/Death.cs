using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public GameManager gameManager;
    public Animator animator;

    public void DieAnim()
    {
        animator.SetTrigger("Death");
    }

    public void Die()
    {
        SceneManager.LoadScene(3);
    }


}
