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
    public GameObject cube;
    public string direction;
    public string north = "north";
    public string south = "south";
    public string east = "east";
    public string west = "west";
    RaycastHit hit;
    public List<String> logInput = new List<String>();
    public bool cannotGoThere;


    private void Start()
    {


    }

    public void PlayerMove()
    {

        steps = inputField.GetComponent<Text>().text;
        logInput.Add(steps);
        string[] words = steps.Split(' ');
        int stepsInt = Int32.Parse(words[0]);
        direction = words[1];
        stepsNum = stepsInt;
         



        if (direction.Equals(north, StringComparison.OrdinalIgnoreCase)) //Moves to north
        {
            float moveSpaces = stepsNum * 10;

            RaycastHit hitNorth;
            Physics.Raycast(cube.transform.position, Vector3.forward, out hitNorth);

            var currentPos = cube.transform.position;
            var newPosW = currentPos + Vector3.forward * moveSpaces;
            if (hitNorth.distance <= moveSpaces)
            {
                cantMoveAnim.SetTrigger("cantMove");
                print("cannot Move here ");
                cannotGoThere = true;
            }
            else
            {
                cube.transform.position = newPosW;
                currentPos = newPosW;
            }
        }


        if (direction.Equals(west, StringComparison.OrdinalIgnoreCase)) // a moves player left one space 
        {
            float moveSpaces = stepsNum * 10;

            RaycastHit hitWest;
            Physics.Raycast(cube.transform.position, Vector3.left, out hitWest);

            var currentPos = cube.transform.position;
            var newPosW = currentPos + Vector3.left * moveSpaces;
            if (hitWest.distance <= moveSpaces)
            {
                cantMoveAnim.SetTrigger("cantMove");
                print("cannot Move here "); 
                cannotGoThere = true;
            }
            else
            {

                cube.transform.position = newPosW;
                currentPos = newPosW;
            }
        }

        if (direction.Equals(east, StringComparison.OrdinalIgnoreCase))
        {
            float moveSpaces = stepsNum * 10;

            RaycastHit hitEast;
            Physics.Raycast(cube.transform.position, Vector3.right, out hitEast);

            var currentPos = cube.transform.position;
            var newPosW = currentPos + Vector3.right * moveSpaces;
            if (hitEast.distance <= moveSpaces)
            {
                cantMoveAnim.SetTrigger("cantMove");
                print("cannot Move here ");
                cannotGoThere = true;
            }
            else
            {
                cube.transform.position = newPosW;
                currentPos = newPosW;
            }
        }

        if (direction.Equals(south, StringComparison.OrdinalIgnoreCase)) // s moves player back one space 
        {
            float moveSpaces = stepsNum * 10;

            RaycastHit hitSouth;
            Physics.Raycast(cube.transform.position, Vector3.back, out hitSouth);

            var currentPos = cube.transform.position;
            var newPosW = currentPos + Vector3.back * moveSpaces;
            if (hitSouth.distance <= moveSpaces)
            {
                cantMoveAnim.SetTrigger("cantMove");
                print("cannot Move here ");
                cannotGoThere = true;
            }
            else
            {
                cube.transform.position = newPosW;
                currentPos = newPosW;
            }
            print("im here");
        }
    }



}
