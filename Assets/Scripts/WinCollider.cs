using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCollider : MonoBehaviour
{
    public GameManager gameManager;
    

    private void OnTriggerEnter (Collider other)
    {
        print(other.gameObject.name);

        if (other.gameObject.CompareTag("Player"))
        {
            print("You Win!");
            gameManager.WinGame();

        }
    }
}
