using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{
    public GameManager gameManager;
    public Death death;
    public AudioManager audioManager;
    public GameObject inputField;
    public Animator walkAnim;
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
    public Transform minotaur;
    public float deathRange;
    public float distanceFromMinotaur = Mathf.Infinity;
    private  int layerMask = 1 << 2;
    



    private Vector3 newPos;
    private bool moving;
    private void Start()
    {
        layerMask = ~layerMask;
        moving = false;
    }

    private void Update()
    {
       MovePlayer();
       CheckDistance();
    }
    void CheckMovement(Vector3 direction)
    {
        if (!moving)
        {
            
            float moveSpaces = stepsNum * 10;
            RaycastHit hit;
            
            Physics.Raycast(player.transform.position, direction,  out hit, Mathf.Infinity, layerMask);

           
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
      /*  if (cannotGoThere==true)
        {
            print("im ehere");
            logInput.Remove(logInput.Last());
        }*/
        string[] words = steps.Split(' ');
        int stepsInt = Int32.Parse(words[0]);
        direction = words[1];
        stepsNum = stepsInt;

        if (direction.Equals(north, StringComparison.OrdinalIgnoreCase)) //north
        {
            CheckMovement(Vector3.forward);
            if (cannotGoThere == true)
            {
                print("im ehere");
                logInput.Remove(logInput.Last());
            }
        }

        if (direction.Equals(west, StringComparison.OrdinalIgnoreCase)) //east
        {
            CheckMovement(Vector3.left);
            if (cannotGoThere == true)
            {
                print("im ehere");
                logInput.Remove(logInput.Last());
            }
        }
        if (direction.Equals(south, StringComparison.OrdinalIgnoreCase)) //south
        {
            CheckMovement(Vector3.back);
            if (cannotGoThere == true)
            {
                print("im ehere");
                logInput.Remove(logInput.Last());
            }
        }

        if (direction.Equals(east, StringComparison.OrdinalIgnoreCase)) //west
        {
            CheckMovement(Vector3.right);
            if (cannotGoThere == true)
            {
                print("im ehere");
                logInput.Remove(logInput.Last());
            }
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
                audioManager.StartSteps();
                walkAnim.SetTrigger("isWalking");
                RotatePlayer(newPos - player.transform.position);
            }

        }
        else
        {
            walkAnim.SetTrigger("isNotWalking");
            audioManager.StopSteps();
        }

    }
    void RotatePlayer(Vector3 direction)
    {
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.LookRotation(direction.normalized),rotationSpeed);
    }

   
    public void CheckDistance()
    {
        distanceFromMinotaur = Vector3.Distance(player.transform.position, minotaur.transform.position);
        if (distanceFromMinotaur <= deathRange)
        {
            print("dead");
            death.DieAnim();
        }
    }


  


}
