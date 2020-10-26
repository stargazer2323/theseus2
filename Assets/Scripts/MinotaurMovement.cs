using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class MinotaurMovement : MonoBehaviour
{
    // in this script we move the minotaur the same steps as the player .We implement the animation for the movement 
    // Also when the player hits a wall the minotaur does not move 
    
   
    public Animator walkAnim;
    public GameObject player;
    public NavMeshAgent agent;
    public GameObject minotaur;
    public Vector3 minotaurPosition;
    public CharacterMove move = new CharacterMove();

    bool minotaurMoving = false;
    // Update is called once per frame
    private void Start()
    {

        minotaurPosition = minotaur.transform.position;
       
    }


    private void Update()
    {
        AnimateWalk();
        if (minotaurMoving) 
        {
            int moveSq= move.stepsNum*10;
            print(moveSq);
                if (Math.Abs( minotaurPosition.x - minotaur.transform.position.x )> moveSq||Math.Abs( minotaurPosition.z-minotaur.transform.position.z)>moveSq)
                {
                    print(minotaur.transform.position);
                    minotaur.GetComponent<NavMeshAgent>().isStopped = true;
                    minotaurMoving = false;

                    print("minotaur last  position" + minotaurPosition.z);
                    

                }            
        }
    }


    public void MinotaurM()
    {
        
        minotaurMoving = true;
        minotaur.GetComponent<NavMeshAgent>().isStopped = false;
        Vector3 positionOfPlayer = GameObject.Find("Player").transform.position;

        
       
          //print("minotaur first position position"+minotaurPosition);

         

            agent.SetDestination(positionOfPlayer);
        if (move.cannotGoThere == true)
        {
            minotaur.GetComponent<NavMeshAgent>().isStopped = true;
            move.cannotGoThere = false;
        }

            minotaurPosition = minotaur.transform.position;
       
    }
    public void nearPlayer()
    {
        if (agent.remainingDistance < 5)
        {
            string nearYou = "You can feel hes breath";
            print(nearYou);
        }


    }

    public void AnimateWalk()
    {
        if (minotaurMoving)
        {
            walkAnim.SetTrigger("Walk");
        }
        else if (!minotaurMoving)
        {
            walkAnim.SetTrigger("DontWalk");
        }
    }

}
