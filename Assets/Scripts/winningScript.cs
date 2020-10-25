using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winningScript : MonoBehaviour
{
    public GameObject playerPosition;
    public GameObject winningCube;


    // Update is called once per frame
    void Update()
    {
        Vector3 winningSquare = winningCube.transform.position;
        if (playerPosition.transform.position == winningSquare)
        {
            print("win");
        }

    }
}
