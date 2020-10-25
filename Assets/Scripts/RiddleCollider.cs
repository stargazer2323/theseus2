using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleCollider : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.OpenFootStepRiddle();
        }
    }
}
