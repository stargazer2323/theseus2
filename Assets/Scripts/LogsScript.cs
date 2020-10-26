using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogsScript : MonoBehaviour
{
    public CharacterMove movementInput = new CharacterMove();
    public Text textLog;
    string displayLogs;
    string displayLogs2;
    int lenghtOfList;

   
    public void logsText()
    {
        //prints the movement of the player .If the list is beyond size 20 it prints the last five inputs

            displayLogs = " ";
        if (movementInput.logInput.Count < 15)
        {
            foreach (var steps in movementInput.logInput)
            {
                displayLogs = displayLogs + steps + "\n";

            }
        }
        else
        {
            displayLogs = movementInput.logInput[movementInput.logInput.Count - 5] + "\n" + movementInput.logInput[movementInput.logInput.Count - 4] + "\n" + movementInput.logInput[movementInput.logInput.Count - 3] + "\n" + movementInput.logInput[movementInput.logInput.Count - 2] + "\n" + movementInput.logInput[movementInput.logInput.Count - 1] ;
        }
            textLog.text = displayLogs;

        
      
        
    }

}
