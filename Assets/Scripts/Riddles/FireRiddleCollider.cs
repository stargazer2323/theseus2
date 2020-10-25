using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRiddleCollider : MonoBehaviour
{
        public GameManager gameManager;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                print("fire");
                gameManager.OpenFireRiddle();
            }
        }

}
