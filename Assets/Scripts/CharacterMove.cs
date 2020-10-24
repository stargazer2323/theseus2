using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{

    public GameObject inputField;
    public Animator cantMoveAnim;
    public string steps;
    public int stepsNum;
    public GameObject player;
    public string direction;
    public string north = "north";
    public string south = "south";
    public string east = "east";
    public string west = "west";
    RaycastHit hit;
    public List<String> logInput = new List<String>();
    public bool cannotGoThere;
    public float moveSpeed = 3;
    public float rotationSpeed = 3;

   
    private Vector3 newPos;
    private bool moving;
    private void Start()
    {
        moving = false;
    }

    private void Update()
    {
       MovePlayer();
    }
    void CheckMovement(Vector3 direction)
    {
        if (!moving)
        {

            float moveSpaces = stepsNum * 10;
            RaycastHit hit;

            Physics.Raycast(player.transform.position, direction, out hit);

            print("collider " + hit.collider.name);
            if (hit.distance <= moveSpaces)
            {
                cantMoveAnim.SetTrigger("cantMove");
                print("cant move in " + direction);
                cannotGoThere = true;
            }
            else
            {
                var currentPos = player.transform.position;
                newPos = currentPos + (direction * moveSpaces);
                moving = true;

            }
        }
    }


    public void CheckInput()
    {

        steps = inputField.GetComponent<Text>().text;
        logInput.Add(steps);
        string[] words = steps.Split(' ');
        int stepsInt = Int32.Parse(words[0]);
        direction = words[1];
        stepsNum = stepsInt;

        if (direction.Equals(north, StringComparison.OrdinalIgnoreCase)) //north
        {
            CheckMovement(Vector3.forward);
        }

        if (direction.Equals(west, StringComparison.OrdinalIgnoreCase)) //east
        {
            CheckMovement(Vector3.left);
        }
        if (direction.Equals(south, StringComparison.OrdinalIgnoreCase)) //south
        {
            CheckMovement(Vector3.back);
        }

        if (direction.Equals(east, StringComparison.OrdinalIgnoreCase)) //west
        {
            CheckMovement(Vector3.right);
        }
    }

    public void MovePlayer()
    {
        if (moving)
        {

            player.transform.position = Vector3.MoveTowards(player.transform.position, newPos, moveSpeed * Time.deltaTime);
            if (player.transform.position == newPos)
            {
                moving = false;
            }
            else
            {
                RotatePlayer(newPos - player.transform.position);
            }

        }

    }
     void RotatePlayer(Vector3 direction)
    {
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.LookRotation(direction.normalized),rotationSpeed);
    }


}
